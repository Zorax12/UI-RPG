using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemyManager enemyManager;

    [SerializeField] private TMP_Text playerName, playerHp, playerWeapon, weaponStats, weaponAbility;
    [SerializeField] private TMP_Text spellText, spellStats, spellEffectText, manaText, manaRejuvText;

    [SerializeField] private TMP_Text shieldText, shieldRepairText ;

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

        spellText.text = player.ActiveSpellName;
        spellStats.text = "Spell damage: " + player.ActiveSpellStats;
        spellEffectText.text = "Spell effect: " + player.ActiveSpellEffect;
        manaText.text = "Mana: " + player.Mana.ToString();
        manaRejuvText.text = player.RemainingManaRegen.ToString();

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

    public void SwitchSpell()
    {
        if (isGameOver)
            return;

        player.SwitchSpell();
        UpdateUI();
    }

    private void TriggerEnemyTurn(Enemy currentEnemy)
    {
        if (currentEnemy == null)
            return;

        MagicEnemy magicEnemy = currentEnemy as MagicEnemy;
        if (magicEnemy != null && magicEnemy.TryHealInsteadOfAttack())
        {
            magicEnemy.Heal(magicEnemy.GetHealAmount());
            enemyManager.UpdateEnemyUI();
            UpdateUI();
            return;
        }

        currentEnemy.DealDamageToPlayer(player);
        player.DeactivateShield();
        UpdateUI();

        if (player.health <= 0)
        {
            TriggerGameOver();
        }
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

        TriggerEnemyTurn(currentEnemy);
    }

    public void CastButton()
    {
        if (isGameOver)
            return;

        Enemy currentEnemy = enemyManager.CurrentEnemy;

        if (currentEnemy == null)
            return;

        float healthBeforeCast = player.Health;
        int manaBeforeCast = player.Mana;

        bool castSuccess = player.CastActiveSpell(currentEnemy);

        if (!castSuccess)
        {
            UpdateUI();
            return;
        }

        enemyManager.UpdateEnemyUI();

        if (!player.ActiveSpellEffect.Equals("None") && player.Health > healthBeforeCast)
        {
            UpdateUI();
            return;
        }

        if (enemyManager.IsCurrentEnemyDead())
        {
            enemyManager.SpawnEnemy();
            UpdateUI();
            return;
        }

        TriggerEnemyTurn(currentEnemy);
    }

    public void RejuvenateButton()
    {
        if (isGameOver)
            return;

        player.RejuvenateMana();
        UpdateUI();
    }

    public void DefendButton()
    {
        if (isGameOver)
            return;

        Enemy currentEnemy = enemyManager.CurrentEnemy;

        if (currentEnemy == null)
            return;

        player.ActivateShield();

        MagicEnemy magicEnemy = currentEnemy as MagicEnemy;
        if (magicEnemy != null && magicEnemy.TryHealInsteadOfAttack())
        {
            magicEnemy.Heal(magicEnemy.GetHealAmount());
            enemyManager.UpdateEnemyUI();
            player.DeactivateShield();
            UpdateUI();
            return;
        }

        currentEnemy.DealDamageToPlayer(player);
        player.DeactivateShield();
        UpdateUI();

        if (player.health <= 0)
        {
            TriggerGameOver();
        }
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
