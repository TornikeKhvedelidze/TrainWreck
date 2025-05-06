#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class EditorUtilityTool : MonoBehaviour
{
    static EditorUtilityTool()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if (go != null && go.name.StartsWith("@"))
        {
            EditorGUI.DrawRect(selectionRect, Color.white);

            string text = go.name.Substring(1);

            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                normal = { textColor = Color.black },
                alignment = TextAnchor.MiddleCenter,
                fontStyle = FontStyle.Bold
            };

            EditorGUI.LabelField(selectionRect, text, style);
        }
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;

        if (e != null && e.type == EventType.MouseDown && e.button == 2)
        {
            Debug.Log("Middle mouse click detected in Scene view");

            GameObject selected = Selection.activeGameObject;

            if (selected != null)
            {
                Undo.RecordObject(selected, "Toggle Active State");
                selected.SetActive(!selected.activeSelf);
                EditorUtility.SetDirty(selected);
                EditorSceneManager.MarkSceneDirty(selected.scene); // Optional: ensures scene shows as dirty
                e.Use();
            }
        }
    }
}

#endif
