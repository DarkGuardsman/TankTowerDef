using UnityEngine;
using System.Collections;
using UnityEditor;

//[CustomPropertyDrawer(typeof(EnemyWave))]
public class WavePropDrawer : PropertyDrawer
{

    //https://docs.unity3d.com/ScriptReference/PropertyDrawer.html
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Calculate rects
        Rect amountRect = new Rect(position.x, position.y, 30, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("setsToSpawn"), GUIContent.none);

        EditorGUI.EndProperty();
    }
}