using UnityEngine;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    public PlayerStats player;

    [Header("UI References")]
    public TMP_Text healthText;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text speedText;
    public TMP_Text manaText;

    private void Start()
    {
        if (player != null)
        {
            player.onStatsChanged += UpdateUI;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (player == null) return;

        healthText.text = $"Health: {player.GetStat(StatType.Health)}";
        attackText.text = $"Attack: {player.GetStat(StatType.Attack)}";
        defenseText.text = $"Defense: {player.GetStat(StatType.Defense)}";
        speedText.text = $"Speed: {player.GetStat(StatType.Speed)}";
        manaText.text = $"Mana: {player.GetStat(StatType.Mana)}";
    }
}