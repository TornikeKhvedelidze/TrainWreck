using LutorGames.Serializables;
using PrivateLT.NOACCESS;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace LutorGames.Serializables
{
    [Serializable]
    public class Vector2_Serializable
    {
        public float x;
        public float y;

        public Vector2_Serializable() { }

        public Vector2_Serializable(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2_Serializable(Vector2 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
        }

        public static implicit operator Vector2(Vector2_Serializable sVector)
        {
            return new Vector2(sVector.x, sVector.y);
        }

        public static implicit operator Vector2_Serializable(Vector2 vector)
        {
            return new Vector2_Serializable(vector);
        }
    }

    [Serializable]
    public class Vector3_Serializable
    {
        public float x;
        public float y;
        public float z;

        public Vector3_Serializable() { }

        public Vector3_Serializable(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3_Serializable(Vector3 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }

        public static implicit operator Vector3(Vector3_Serializable sVector)
        {
            return new Vector3(sVector.x, sVector.y, sVector.z);
        }

        public static implicit operator Vector3_Serializable(Vector3 vector)
        {
            return new Vector3_Serializable(vector);
        }
    }

    [Serializable]
    public class Vector4_Serializable
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4_Serializable() { }

        public Vector4_Serializable(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4_Serializable(Vector4 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
            this.w = vector.w;
        }

        public static implicit operator Vector4(Vector4_Serializable sVector)
        {
            return new Vector4(sVector.x, sVector.y, sVector.z, sVector.w);
        }

        public static implicit operator Vector4_Serializable(Vector4 vector)
        {
            return new Vector4_Serializable(vector);
        }
    }

    [Serializable]
    public class Quaternion_Serializable
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion_Serializable() { }

        public Quaternion_Serializable(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Quaternion_Serializable(Quaternion quaternion)
        {
            this.x = quaternion.x;
            this.y = quaternion.y;
            this.z = quaternion.z;
            this.w = quaternion.w;
        }

        public static implicit operator Quaternion(Quaternion_Serializable sQuaternion)
        {
            return new Quaternion(sQuaternion.x, sQuaternion.y, sQuaternion.z, sQuaternion.w);
        }

        public static implicit operator Quaternion_Serializable(Quaternion quaternion)
        {
            return new Quaternion_Serializable(quaternion);
        }
    }

    [Serializable]
    public class Color_Serializable
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color_Serializable() { }

        public Color_Serializable(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color_Serializable(Color color)
        {
            this.r = color.r;
            this.g = color.g;
            this.b = color.b;
            this.a = color.a;
        }

        public static implicit operator Color(Color_Serializable sColor)
        {
            return new Color(sColor.r, sColor.g, sColor.b, sColor.a);
        }

        public static implicit operator Color_Serializable(Color color)
        {
            return new Color_Serializable(color);
        }
    }

    [Serializable]
    public class Color32_Serializable
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public Color32_Serializable() { }

        public Color32_Serializable(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color32_Serializable(Color32 color)
        {
            this.r = color.r;
            this.g = color.g;
            this.b = color.b;
            this.a = color.a;
        }

        public static implicit operator Color32(Color32_Serializable sColor)
        {
            return new Color32(sColor.r, sColor.g, sColor.b, sColor.a);
        }

        public static implicit operator Color32_Serializable(Color32 color)
        {
            return new Color32_Serializable(color);
        }
    }

    [Serializable]
    public class Rect_Serializable
    {
        public float x;
        public float y;
        public float width;
        public float height;

        public Vector2_Serializable position
        {
            set
            {
                x = value.x; y = value.y;
            }
            get
            {
                return new Vector2(x, y);
            }
        }

        public Rect_Serializable() { }

        public Rect_Serializable(float x, float y, float width, float height)
        {
            Debug.Log($"Get 2 ({x}; {y})");

            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Rect_Serializable(Rect rect)
        {
            this.x = rect.x;
            this.y = rect.y;
            this.width = rect.width;
            this.height = rect.height;
        }

        public static implicit operator Rect(Rect_Serializable sRect)
        {
            return new Rect(sRect.x, sRect.y, sRect.width, sRect.height);
        }

        public static implicit operator Rect_Serializable(Rect rect)
        {
            return new Rect_Serializable(rect);
        }
    }

    [Serializable]
    public class Bounds_Serializable
    {
        public Vector3_Serializable center;
        public Vector3_Serializable size;

        public Bounds_Serializable() { }

        public Bounds_Serializable(Bounds bounds)
        {
            this.center = new Vector3_Serializable(bounds.center);
            this.size = new Vector3_Serializable(bounds.size);
        }

        public static implicit operator Bounds(Bounds_Serializable sBounds)
        {
            return new Bounds(sBounds.center, sBounds.size);
        }

        public static implicit operator Bounds_Serializable(Bounds bounds)
        {
            return new Bounds_Serializable(bounds);
        }
    }

    [Serializable]
    public class Ray_Serializable
    {
        public Vector3_Serializable origin;
        public Vector3_Serializable direction;

        public Ray_Serializable() { }

        public Ray_Serializable(Ray ray)
        {
            this.origin = new Vector3_Serializable(ray.origin);
            this.direction = new Vector3_Serializable(ray.direction);
        }

        public static implicit operator Ray(Ray_Serializable sRay)
        {
            return new Ray(sRay.origin, sRay.direction);
        }

        public static implicit operator Ray_Serializable(Ray ray)
        {
            return new Ray_Serializable(ray);
        }
    }

    [Serializable]
    public class Plane_Serializable
    {
        public Vector3_Serializable normal;
        public float distance;

        public Plane_Serializable() { }

        public Plane_Serializable(Plane plane)
        {
            this.normal = new Vector3_Serializable(plane.normal);
            this.distance = plane.distance;
        }

        public static implicit operator Plane(Plane_Serializable sPlane)
        {
            return new Plane(sPlane.normal, sPlane.distance);
        }

        public static implicit operator Plane_Serializable(Plane plane)
        {
            return new Plane_Serializable(plane);
        }
    }

    [Serializable]
    public class LayerMask_Serializable
    {
        public int mask;

        public LayerMask_Serializable() { }

        public LayerMask_Serializable(LayerMask layerMask)
        {
            this.mask = layerMask.value;
        }

        public static implicit operator LayerMask(LayerMask_Serializable sLayerMask)
        {
            return LayerMask.GetMask(LayerMask.LayerToName(sLayerMask.mask));
        }

        public static implicit operator LayerMask_Serializable(LayerMask layerMask)
        {
            return new LayerMask_Serializable(layerMask);
        }
    }

    [System.Serializable]
    public class Range_Serializable
    {
        public float min;
        public float max;

        public Range_Serializable() { }

        public Range_Serializable(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public static implicit operator Vector2(Range_Serializable range)
        {
            return new Vector2(range.min, range.max);
        }

        public static implicit operator Range_Serializable(Vector2 range)
        {
            return new Range_Serializable(range.x, range.y);
        }
    }


    [System.Serializable]
    public class Transform_Serializable
    {
        public Vector3_Serializable position;
        public Quaternion_Serializable rotation;
        public Vector3_Serializable localPosition;
        public Quaternion_Serializable localRotation;
        public Vector3_Serializable localScale;
        public Vector3_Serializable eulerAngles;
        public Vector3_Serializable localEulerAngles;

        // Default constructor
        public Transform_Serializable()
        {
            position = Vector3.zero;
            rotation = Quaternion.identity;
            localPosition = Vector3.zero;
            localRotation = Quaternion.identity;
            localScale = Vector3.one;
            eulerAngles = Vector3.zero;
            localEulerAngles = Vector3.zero;
        }

        // Constructor with all parameters
        public Transform_Serializable(Vector3 position, Quaternion rotation, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Vector3 eulerAngles, Vector3 localEulerAngles)
        {
            this.position = position;
            this.rotation = rotation;
            this.localPosition = localPosition;
            this.localRotation = localRotation;
            this.localScale = localScale;
            this.eulerAngles = eulerAngles;
            this.localEulerAngles = localEulerAngles;
        }

        // Conversion from Transform to Transform_Serializable
        public static implicit operator Transform_Serializable(Transform transform)
        {
            return new Transform_Serializable(
                transform.position,
                transform.rotation,
                transform.localPosition,
                transform.localRotation,
                transform.localScale,
                transform.eulerAngles,
                transform.localEulerAngles
            );
        }

        // Conversion from Transform_Serializable to Transform
        public static implicit operator Transform(Transform_Serializable serializable)
        {
            GameObject tempObject = new GameObject("Temporary Transform Object");
            Transform tempTransform = tempObject.transform;

            tempTransform.position = serializable.position;
            tempTransform.rotation = serializable.rotation;
            tempTransform.localPosition = serializable.localPosition;
            tempTransform.localRotation = serializable.localRotation;
            tempTransform.localScale = serializable.localScale;
            tempTransform.eulerAngles = serializable.eulerAngles;
            tempTransform.localEulerAngles = serializable.localEulerAngles;

            return tempTransform;
        }
    }

}

namespace LutorGames.SaveSystem
{
    public interface ISaveable
    {
        public string SaveId { get; }
    }

    [Serializable]
    public class SaveableValue<T> : Saveable<SaveableValue<T>>
    {
        public T Value;
    }

    [Serializable]
    public class Base_Saveable<T>
    {
        public string Id;
        public T DefaultValue;

        public Action<T> OnValueChanged;
        public Action OnValueChangedNoArgs;

        private bool _initialised;
        private bool _isValidInitialization => _initialisedTime > Binary_SaveSystem.AwakeTime;
        private DateTime _initialisedTime;
        private readonly SaveableValue<T> SaveableValue = new();

        public T Value
        {
            set
            {
                SaveableValue.Value = value;
                OnValueChanged?.Invoke(value);
                OnValueChangedNoArgs?.Invoke();
                if (!_initialised) return;
                Save();
            }
            get
            {
                if (!_initialised || !_isValidInitialization)
                {
                    Initialise();
                }

                return SaveableValue.Value;
            }
        }

        public void SetValue(T value)
        {
            Value = value;
        }

        public void Clear()
        {
            Value = DefaultValue;
            _initialised = false;
        }

        public void Save()
        {
            SaveableValue.Save();
        }

        private void Initialise(Action<T> onValueChanged = null)
        {
            if (!IsValidName())
            {
                Debug.LogError("Some Saveables Doesn't Have Name, That will cause huge problem");
                return;
            }

            _initialised = false;

            SaveableValue.SaveId = Id;

            if (onValueChanged != null) onValueChanged += OnValueChanged;
            if (onValueChanged != null) onValueChanged += (x) => OnValueChangedNoArgs();

            Value = DefaultValue;
            SaveableValue.Load(out var data);
            Value = data.Value;

            OnValueChanged?.Invoke(data.Value);
            OnValueChangedNoArgs?.Invoke();

            _initialised = true;

            _initialisedTime = DateTime.Now;
        }

        private bool IsValidName()
        {
            return !string.IsNullOrEmpty(Id);
        }
    }


    #region Primitive Predefined Saveables

    [Serializable]
    public class Bool_Saveable : Base_Saveable<bool> { }

    [Serializable]
    public class Int_Saveable : Base_Saveable<int> { }

    [Serializable]
    public class Float_Saveable : Base_Saveable<float> { }

    [Serializable]
    public class Double_Saveable : Base_Saveable<double> { }

    [Serializable]
    public class Char_Saveable : Base_Saveable<char> { }

    [Serializable]
    public class String_Saveable : Base_Saveable<string> { }

    [Serializable]
    public class Byte_Saveable : Base_Saveable<byte> { }

    [Serializable]
    public class SByte_Saveable : Base_Saveable<sbyte> { }

    [Serializable]
    public class Short_Saveable : Base_Saveable<short> { }

    [Serializable]
    public class Long_Saveable : Base_Saveable<long> { }

    [Serializable]
    public class UShort_Saveable : Base_Saveable<ushort> { }

    [Serializable]
    public class UInt_Saveable : Base_Saveable<uint> { }

    [Serializable]
    public class ULong_Saveable : Base_Saveable<ulong> { }

    [Serializable]
    public class BoolList_Saveable : Base_Saveable<List<bool>> { }

    [Serializable]
    public class IntList_Saveable : Base_Saveable<List<int>> { }

    [Serializable]
    public class FloatList_Saveable : Base_Saveable<List<float>> { }

    [Serializable]
    public class DoubleList_Saveable : Base_Saveable<List<double>> { }

    [Serializable]
    public class CharList_Saveable : Base_Saveable<List<char>> { }

    [Serializable]
    public class StringList_Saveable : Base_Saveable<List<string>> { }

    [Serializable]
    public class ByteList_Saveable : Base_Saveable<List<byte>> { }

    [Serializable]
    public class SByteList_Saveable : Base_Saveable<List<sbyte>> { }

    [Serializable]
    public class ShortList_Saveable : Base_Saveable<List<short>> { }

    [Serializable]
    public class LongList_Saveable : Base_Saveable<List<long>> { }

    [Serializable]
    public class UShortList_Saveable : Base_Saveable<List<ushort>> { }

    [Serializable]
    public class UIntList_Saveable : Base_Saveable<List<uint>> { }

    [Serializable]
    public class ULongList_Saveable : Base_Saveable<List<ulong>> { }

    #endregion

    #region Unity-Specific Predefined Saveables

    [Serializable]
    public class Vector2_Saveable : Base_Saveable<Vector2_Serializable> { }

    [Serializable]
    public class Vector3_Saveable : Base_Saveable<Vector3_Serializable> { }

    [Serializable]
    public class Vector4_Saveable : Base_Saveable<Vector4_Serializable> { }

    [Serializable]
    public class Quaternion_Saveable : Base_Saveable<Quaternion_Serializable> { }

    [Serializable]
    public class Color_Saveable : Base_Saveable<Color_Serializable> { }

    [Serializable]
    public class Color32_Saveable : Base_Saveable<Color32_Serializable> { }

    [Serializable]
    public class Rect_Saveable : Base_Saveable<Rect_Serializable> { }

    [Serializable]
    public class Bounds_Saveable : Base_Saveable<Bounds_Serializable> { }

    [Serializable]
    public class Ray_Saveable : Base_Saveable<Ray_Serializable> { }

    [Serializable]
    public class Plane_Saveable : Base_Saveable<Plane_Serializable> { }

    [Serializable]
    public class LayerMask_Saveable : Base_Saveable<LayerMask_Serializable> { }

    [Serializable]
    public class Range_Saveable : Base_Saveable<Range_Serializable> { }


    [Serializable]
    public class Vector2List_Saveable : Base_Saveable<List<Vector2_Serializable>> { }

    [Serializable]
    public class Vector3List_Saveable : Base_Saveable<List<Vector3_Serializable>> { }

    [Serializable]
    public class Vector4List_Saveable : Base_Saveable<List<Vector4_Serializable>> { }

    [Serializable]
    public class QuaternionList_Saveable : Base_Saveable<List<Quaternion_Serializable>> { }

    [Serializable]
    public class ColorList_Saveable : Base_Saveable<List<Color_Serializable>> { }

    [Serializable]
    public class Color32List_Saveable : Base_Saveable<List<Color32_Serializable>> { }

    [Serializable]
    public class RectList_Saveable : Base_Saveable<List<Rect_Serializable>> { }

    [Serializable]
    public class BoundsList_Saveable : Base_Saveable<List<Bounds_Serializable>> { }

    [Serializable]
    public class RayList_Saveable : Base_Saveable<List<Ray_Serializable>> { }

    [Serializable]
    public class PlaneList_Saveable : Base_Saveable<List<Plane_Serializable>> { }

    [Serializable]
    public class LayerMaskList_Saveable : Base_Saveable<List<LayerMask_Serializable>> { }

    [Serializable]
    public class RangeList_Saveable : Base_Saveable<List<Range_Serializable>> { }

    #endregion

    [Serializable]
    public class Transform_Saveable : Base_Saveable<Transform_Serializable> { }

    [Serializable]
    public class Saveable<T> : ISaveable where T : class, ISaveable
    {
        public string SaveId { get; set; }

        string ISaveable.SaveId => SaveId;

        Action OnBeforeSave;
        Action OnSave;
        Action OnBeforLoaded;
        Action OnLoaded;

        public async void Save()
        {
            OnBeforeSave?.Invoke();

            var type = typeof(T);
            var filePath = Path.Combine(Binary_SaveSystem.PrecomputeFilePath(), type.Name + ".dat");

            await Binary_SaveSystem.SaveAsync(this as T, filePath);

            OnSave?.Invoke();
        }

        public void InstantSave()
        {
            OnBeforeSave?.Invoke();

            Binary_SaveSystem.InstantSave(this as T);

            OnSave?.Invoke();
        }

        public void Load(out T loadedInfo, Action onLoaded = null)
        {
            OnBeforLoaded?.Invoke();

            if (!Binary_SaveSystem.TryLoad(this as T, out loadedInfo))
            {
                Save();
                Load(out loadedInfo);
                return;
            }

            onLoaded?.Invoke();
            OnLoaded?.Invoke();

            Binary_SaveSystem.OnSave -= Save;
            Binary_SaveSystem.OnSave += Save;

            Binary_SaveSystem.OnIntantSave -= InstantSave;
            Binary_SaveSystem.OnIntantSave += InstantSave;
        }
    }
}
