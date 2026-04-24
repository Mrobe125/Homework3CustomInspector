using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    [Header("Base Stats")]
    public float baseHealth = 100;
    public float baseAttack = 10;
    public float baseDefense = 5;
    public float baseSpeed = 3;
    public float baseMana = 50;

    [Header("Equipment Slots")]
    public List<EquipmentData> equippedItems = new List<EquipmentData>();

    private Dictionary<StatType, float> finalStats = new Dictionary<StatType, float>();

    public delegate void OnStatsChanged();
    public event OnStatsChanged onStatsChanged;

    private void Awake()
    {
        RecalculateStats();
    }

    public void RecalculateStats()
    {
        finalStats.Clear();

        finalStats[StatType.Health] = baseHealth;
        finalStats[StatType.Attack] = baseAttack;
        finalStats[StatType.Defense] = baseDefense;
        finalStats[StatType.Speed] = baseSpeed;
        finalStats[StatType.Mana] = baseMana;

        foreach (var item in equippedItems)
        {
            if (item == null) continue;

            foreach (var mod in item.modifiers)
            {
                finalStats[mod.statType] += mod.value;
            }
        }

        onStatsChanged?.Invoke();
    }

    public float GetStat(StatType stat)
    {
        return finalStats.ContainsKey(stat) ? finalStats[stat] : 0;
    }
}