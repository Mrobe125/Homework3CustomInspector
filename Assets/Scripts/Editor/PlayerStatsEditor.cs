using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerStats stats = (PlayerStats)target;

        serializedObject.Update();

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Base Stats", EditorStyles.boldLabel);

        stats.baseHealth = EditorGUILayout.FloatField("Health", stats.baseHealth);
        stats.baseAttack = EditorGUILayout.FloatField("Attack", stats.baseAttack);
        stats.baseDefense = EditorGUILayout.FloatField("Defense", stats.baseDefense);
        stats.baseSpeed = EditorGUILayout.FloatField("Speed", stats.baseSpeed);
        stats.baseMana = EditorGUILayout.FloatField("Mana", stats.baseMana);

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Equipment", EditorStyles.boldLabel);

        SerializedProperty equipmentList = serializedObject.FindProperty("equippedItems");
        EditorGUILayout.PropertyField(equipmentList, true);

        if (equipmentList.arraySize == 0)
        {
            EditorGUILayout.HelpBox("No equipment assigned!", MessageType.Warning);
        }

        EditorGUILayout.EndVertical();

        if (GUILayout.Button("Recalculate Stats"))
        {
            stats.RecalculateStats();
        }

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Final Stats", EditorStyles.boldLabel);

        DrawStat("Health", stats.baseHealth, stats.GetStat(StatType.Health));
        DrawStat("Attack", stats.baseAttack, stats.GetStat(StatType.Attack));
        DrawStat("Defense", stats.baseDefense, stats.GetStat(StatType.Defense));
        DrawStat("Speed", stats.baseSpeed, stats.GetStat(StatType.Speed));
        DrawStat("Mana", stats.baseMana, stats.GetStat(StatType.Mana));

        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }

    void DrawStat(string name, float baseValue, float finalValue)
    {
        Color original = GUI.color;

        if (finalValue > baseValue)
            GUI.color = Color.green;
        else if (finalValue < baseValue)
            GUI.color = Color.red;

        EditorGUILayout.LabelField(name, finalValue.ToString());

        GUI.color = original;
    }
}