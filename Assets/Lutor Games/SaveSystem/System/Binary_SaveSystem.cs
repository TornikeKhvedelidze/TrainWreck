using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Collections;
using LutorGames.SaveSystem;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrivateLT.NOACCESS
{

    public class Binary_SaveSystem : MonoBehaviour
    {
        [SerializeField] private bool _debugOn;

        private readonly bool _dontDestroy = true;
        private readonly float _constantSaveInterval = 10;

        private static Binary_SaveSystem _instance;
        private static readonly object fileLock = new object();
        private static Dictionary<string, List<ISaveable>> _dictionary = new();

        public static Action OnSave;
        public static Action OnIntantSave;

        public static Binary_SaveSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Binary_SaveSystem>();
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(Binary_SaveSystem).Name);
                        _instance = singletonObject.AddComponent<Binary_SaveSystem>();
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as Binary_SaveSystem;

                if (!_dontDestroy) return;

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Application.quitting += InvokeInstantSave;

            StartCoroutine(ConstantSave_Coroutine());
        }

        private void OnApplicationPause(bool pause)
        {
            InvokeInstantSave();
        }

        public static async Task SaveAsync<T>(T element, string persistentDataPath) where T : ISaveable
        {
            await Task.Run(() => Save(element, persistentDataPath));
        }

        private static void Save<T>(T element, string path) where T : ISaveable
        {
            lock (fileLock)
            {
                var type = typeof(T);

                LoadAllElementOfType(element, path);

                if (!_dictionary.ContainsKey(type.Name))
                {
                    _dictionary[type.Name] = new List<ISaveable>();
                }

                var desiredList = _dictionary[type.Name];
                var desiredElement = desiredList.Find(h => h.SaveId == element.SaveId);

                if (desiredElement != null)
                {
                    desiredList.Remove(desiredElement);
                }

                desiredList.Add(element);

                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, desiredList);
                }

                TryDebug($"Saved Id: {element.SaveId} at: {path}");
            }
        }

        public static void InstantSave<T>(T element) where T : ISaveable
        {
            var type = typeof(T);
            var path = GetFilePath(type.Name);

            LoadAllElementOfType(element, GetFilePath(path));

            if (!_dictionary.ContainsKey(type.Name))
            {
                _dictionary[type.Name] = new List<ISaveable>();
            }

            var desiredList = _dictionary[type.Name];
            var desiredElement = desiredList.Find(h => h.SaveId == element.SaveId);

            if (desiredElement != null)
            {
                desiredList.Remove(desiredElement);
            }

            desiredList.Add(element);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, desiredList);
            }

            TryDebug($"InstantSaved Id: {element.SaveId} at: {path}");
        }

        public static bool TryLoad<T>(T element, out T desiredElement) where T : class, ISaveable
        {
            var type = typeof(T);
            var filePath = GetFilePath(type.Name);

            LoadAllElementOfType(element, filePath);

            if (!_dictionary.ContainsKey(type.Name))
            {
                _dictionary[type.Name] = new List<ISaveable>();
            }

            var desiredList = _dictionary[type.Name];
            desiredElement = desiredList.Find(h => h.SaveId == element.SaveId) as T;

            if (desiredElement != null)
            {
                TryDebug($"Loaded Id: {desiredElement.SaveId}");
                return true;
            }

            TryDebug($"Couldn't Loaded Id: {element.SaveId}");
            return false;
        }

        private static void LoadAllElementOfType<T>(T element, string path) where T : ISaveable
        {
            lock (fileLock)
            {
                var type = typeof(T);

                if (File.Exists(path))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        _dictionary[type.Name] = formatter.Deserialize(stream) as List<ISaveable>;
                    }
                }
            }
        }


#if UNITY_EDITOR
        [MenuItem("Tools/Lutor Games/SaveSystem/Clear All Data")]
#endif
        public static void ClearAllInfo()
        {
            string[] files = Directory.GetFiles(Application.persistentDataPath);

            foreach (string file in files)
            {
                File.Delete(file);
            }

            Debug.Log($"Cleared all saved information");
        }

        private static string GetFilePath(string typeName)
        {
            return Path.Combine(Application.persistentDataPath, typeName + ".dat");
        }

        public static string PrecomputeFilePath()
        {
            return Application.persistentDataPath;
        }

        private static void TryDebug(string value)
        {
            if (!Instance._debugOn) return;

            Debug.Log(value);
        }

        public static void InvokeSave()
        {
            OnSave?.Invoke();
        }

        public static void InvokeInstantSave()
        {
            OnIntantSave?.Invoke();
        }

        IEnumerator ConstantSave_Coroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_constantSaveInterval);

                InvokeSave();
            }
        }

#if UNITY_EDITOR
        [MenuItem("Tools/Lutor Games/SaveSystem/Open Save Folder")]
        public static void OpenPersistentDataPathFolder()
        {
            string path = Application.persistentDataPath;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            System.Diagnostics.Process.Start("explorer.exe", path.Replace("/", "\\"));
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
            System.Diagnostics.Process.Start("open", path);
#elif UNITY_EDITOR_LINUX || UNITY_STANDALONE_LINUX
            System.Diagnostics.Process.Start("xdg-open", path);
#endif
        }
#endif
    }
}
