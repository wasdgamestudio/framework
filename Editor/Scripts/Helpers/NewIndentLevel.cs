using System;
using UnityEditor;

public class NewIndentLevel : IDisposable
{
    readonly int prevIndentLevel;

    public NewIndentLevel(int indentLevel)
    {
        prevIndentLevel = EditorGUI.indentLevel;
        EditorGUI.indentLevel = indentLevel;
    }

    void IDisposable.Dispose() => Dispose();
    public void Dispose()
    {
        EditorGUI.indentLevel = prevIndentLevel;
    }
}