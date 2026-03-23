using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Character enemy;

    [SerializeField] private TMP_Text playerName, playerHp, playerWeapon;
    [SerializeField] private TMP_Text enemyName, enemyHp;

    void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.CharName;
        playerHp.text = "HP: " + player.health.ToString("F0");
        enemyHp.text = "HP: " + enemy.health.ToString("F0");
        playerWeapon.text = player.ActiveWeaponName;
    }

    public void SwitchWeapon()
    {
        player.SwitchWeapon();
        UpdateUI();
    }

    public void AttackButton() 
    {
        player.Attack(enemy);
        enemy.Attack(player);
        UpdateUI();
    }
}
