using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(StatModifier))]
public class StatModifierDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var statType = property.FindPropertyRelative("statType");
        var value = property.FindPropertyRelative("value");

        float halfWidth = position.width / 2;

        EditorGUI.PropertyField(
            new Rect(position.x, position.y, halfWidth, position.height),
            statType, GUIContent.none);

        Color originalColor = GUI.color;

        if (value.floatValue > 0)
            GUI.color = Color.green;
        else if (value.floatValue < 0)
            GUI.color = Color.red;

        EditorGUI.PropertyField(
            new Rect(position.x + halfWidth, position.y, halfWidth, position.height),
            value, GUIContent.none);

        GUI.color = originalColor;

        EditorGUI.EndProperty();
    }
}