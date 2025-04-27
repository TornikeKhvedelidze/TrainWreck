using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

[InitializeOnLoad]
public class ProjectWindowItemHighlighter
{
    // Static constructor that hooks up the callback
    static ProjectWindowItemHighlighter()
    {
        // Subscribe to the event that draws items in the Project window
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
    }

    // This function is called for each item in the Project window
    private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
    { 
        // Get the asset path from the GUID
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);

        // Extract the filename from the asset path
        string fileName = System.IO.Path.GetFileName(assetPath);

        // Check if the filename starts with an underscore (_)
        if (fileName.StartsWith("@"))
        {
            // Remove the underscore from the displayed name
            string displayName = fileName.Substring(1); // Skip the first character (_)

            // Set the background color to #292929
            Color darkGray = new Color32(41, 41, 41, 255); // RGB for #292929
            EditorGUI.DrawRect(selectionRect, darkGray);

            // Load the icon from Assets/Icons
            string iconPath = $"Assets/@0Editor/Icons/{displayName}.png"; // Assuming icons are PNG files
            Texture2D icon = AssetDatabase.LoadAssetAtPath<Texture2D>(iconPath);

            // Calculate centered text position
            GUIStyle centeredStyle = new GUIStyle(EditorStyles.label);
            centeredStyle.alignment = TextAnchor.MiddleLeft; // Align text to the left
            centeredStyle.padding.left = 25; // Add padding to make room for the icon

            // Draw a thinner border
            Color borderColor = new Color32(31, 31, 31, 255); // RGB for #292929
            Rect borderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width, selectionRect.height/1.2f);
            EditorGUI.DrawRect(borderRect, borderColor);

            // Draw the icon if it exists
            if (icon != null)
            {
                // Draw the icon to the left of the text
                Rect iconRect = new Rect(selectionRect.x + 5, selectionRect.y + 2, 16, 16); // Adjust position and size
                GUI.DrawTexture(iconRect, icon, ScaleMode.ScaleToFit);
            }

            // Draw the name without the leading underscore
            EditorGUI.LabelField(selectionRect, displayName, centeredStyle);
        }
    }
}
#endif
