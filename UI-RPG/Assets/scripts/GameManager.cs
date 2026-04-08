using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemyManager enemyManager;

    [SerializeField] private TMP_Text playerName, playerHp, playerWeapon, weaponStats, weaponAbility;

    [SerializeField] private TMP_Text shieldText;
    [SerializeField] private TMP_Text shieldRepairText;

    [SerializeField] private GameObject gameOverPanel;

    private bool isGameOver;

    void Start()
    {
        isGameOver = false;
        gameOverPanel.SetActive(false);
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerName.text = player.CharName;
        playerHp.text = "HP: " + player.health.ToString("F0");
        playerWeapon.text = player.ActiveWeaponName;
        weaponStats.text = "Damage: " + player.ActiveWeaponStats;
        weaponAbility.text = "Weapon ability: " + player.ActiveWeaponAbility;

        shieldText.text = "Shield: " + player.ShieldHealth.ToString("F0");
        shieldRepairText.text = player.RemainingShieldRepairs.ToString();

        enemyManager.UpdateEnemyUI();
    }

    private void TriggerGameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void SwitchWeapon()
    {
        if (isGameOver)
            return;

        player.SwitchWeapon();
        UpdateUI();
    }

    public void AttackButton()
    {
        if (isGameOver)
            return;

        Enemy currentEnemy = enemyManager.CurrentEnemy;

        if (currentEnemy == null)
            return;

        player.Attack(currentEnemy);
        enemyManager.UpdateEnemyUI();

        if (enemyManager.IsCurrentEnemyDead())
        {
            enemyManager.SpawnEnemy();
            UpdateUI();
            return;
        }

        float enemyDamage = currentEnemy.RollDamage();
        player.TakeDamage(enemyDamage);
        UpdateUI();

        if (player.health <= 0)
        {
            TriggerGameOver();
        }
    }

    public void DefendButton()
    {
        if (isGameOver)
            return;

        Enemy currentEnemy = enemyManager.CurrentEnemy;

        if (currentEnemy == null)
            return;

        float enemyDamage = currentEnemy.RollDamage();
        player.TakeDamageToShield(enemyDamage);
        UpdateUI();
    }

    public void RepairShieldButton()
    {
        if (isGameOver)
            return;

        player.RepairShield();
        UpdateUI();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
