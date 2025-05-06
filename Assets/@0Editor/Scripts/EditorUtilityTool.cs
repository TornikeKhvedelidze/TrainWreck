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
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
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

    private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        Event e = Event.current;

        if (e != null && e.type == EventType.MouseDown && e.button == 2 && selectionRect.Contains(e.mousePosition))
        {
            GameObject clickedObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (clickedObject != null)
            {
                Undo.RecordObject(clickedObject, "Toggle Active State");
                clickedObject.SetActive(!clickedObject.activeSelf);
                EditorUtility.SetDirty(clickedObject);
                EditorSceneManager.MarkSceneDirty(clickedObject.scene);
                e.Use();
            }
        }
    }
}

#endif
