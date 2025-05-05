#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class HierarchyCustomEditor : MonoBehaviour
{
    static HierarchyCustomEditor()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if (go == null) return;

        // Middle click toggle
        Event e = Event.current;
        if (e != null && selectionRect.Contains(e.mousePosition) && e.type == EventType.MouseDown && e.button == 2)
        {
            Undo.RecordObject(go, "Toggle Active State");
            go.SetActive(!go.activeSelf);
            EditorUtility.SetDirty(go);
            EditorSceneManager.MarkSceneDirty(go.scene);
            e.Use();
        }

        // Custom styling for @-prefixed GameObjects
        if (go.name.StartsWith("@"))
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
}

#endif
