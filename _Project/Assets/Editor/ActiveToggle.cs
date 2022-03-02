using UnityEditor;
using UnityEngine;

public static class ActiveToggle
{
    private const int WIDTH = 16;

    [InitializeOnLoadMethod]
    private static void Example()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnGUI;
    }

    private static void OnGUI(int instanceID, Rect selectionRect)
    {
        var go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if (go == null)
        {
            return;
        }

        var pos = selectionRect;
        pos.x = pos.xMax - WIDTH;
        pos.width = WIDTH;

        var newActive = GUI.Toggle(pos, go.activeSelf, string.Empty);

        if (newActive == go.activeSelf)
        {
            return;
        }

        go.SetActive(newActive);
    }
}