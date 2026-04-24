using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Equipment", menuName = "RPG/Equipment")]
public class EquipmentData : ScriptableObject
{
    public string equipmentName;
    public Sprite icon;

    [Header("Stat Modifiers")]
    public List<StatModifier> modifiers = new List<StatModifier>();
}