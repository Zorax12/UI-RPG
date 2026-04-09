using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Weapon activeWeapon;

    [SerializeField] private Magic[] spells;
    [SerializeField] private Magic activeSpell;

    [SerializeField] private float maxPlayerHealth = 100f;

    [SerializeField] private float maxShieldHealth = 30f;
    [SerializeField] private float shieldRepairAmount = 10f;
    [SerializeField] private int maxShieldRepairs = 3;

    [SerializeField] private int maxMana = 100;
    [SerializeField] private int manaRegenAmount = 20;
    [SerializeField] private int maxManaRegen = 3;

    private float shieldHealth;
    private int shieldRepairs;
    private int mana;
    private int manaRegen;

    private bool shieldActive;

    private int selectedWeaponID = 0;
    private int selectedSpellID = 0;

    public string ActiveWeaponName
    {
        get { return activeWeapon.weaponName; }
    }

    public string ActiveWeaponStats
    {
        get { return activeWeapon.MinDamage.ToString("F0") + " - " + activeWeapon.MaxDamage.ToString("F0"); }
    }

    public string ActiveWeaponAbility
    {
        get { return activeWeapon.AbilityDescription; }
    }

    public string ActiveSpellName
    {
        get { return activeSpell.SpellName; }
    }

    public string ActiveSpellStats
    {
        get { return activeSpell.MinDamage.ToString("F0") + " - " + activeSpell.MaxDamage.ToString("F0"); }
    }
    
    public string ActiveSpellEffect
    {
        get { return activeSpell.EffectDescription; }
    }

    public int Mana
    {
        get { return mana; }
    }

    public float ShieldHealth
    {
        get { return shieldHealth; }
    }

    public bool ShieldActive
    {
        get { return shieldActive; }
    }

    public int RemainingShieldRepairs
    {
        get { return shieldRepairs; }
    }

    public int RemainingManaRegen
    {
        get { return manaRegen; }
    }

    public void ResetForNewLevel()
    {
        health = maxPlayerHealth;
        InitializeShield();
        InitializeMana();

        selectedWeaponID = 0;
        selectedSpellID = 0;
        activeWeapon = weapons[0];
        activeSpell = spells[0];

        ResetWeaponCharges();
    }

    private void ResetWeaponCharges()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            PoisonWeapon poisonWeapon = weapons[i] as PoisonWeapon;
            if (poisonWeapon != null)
            {
                poisonWeapon.ResetPoisonCharges();
            }
        }
    }

    public override void Attack(Character toHit)
    {
        toHit.TakeDamage(activeWeapon);

        HealWeapon healWeapon = activeWeapon as HealWeapon;
        if (healWeapon != null)
        {
            Heal(healWeapon.HealAmount);
        }
    }

    public bool CastActiveSpell(Character target)
    {
        if (activeSpell == null)
            return false;

        if (mana < activeSpell.ManaCost)
            return false;

        mana -= activeSpell.ManaCost;

        if (activeSpell.TargetsSelf)
        {
            HealMagic healSpell = activeSpell as HealMagic;
            if (healSpell == null)
                return false;

            Heal(healSpell.GetHealAmount());
        }
        else
        {
            target.TakeMagicDamage(activeSpell.GetDamage());
        }

        return true;
    }

    public void SwitchWeapon()
    {
        selectedWeaponID = (++selectedWeaponID) % weapons.Length;
        activeWeapon = weapons[selectedWeaponID];
    }

    public void SwitchSpell()
    {
        if (spells == null || spells.Length == 0)
            return;

        selectedSpellID = (++selectedSpellID) % spells.Length;
        activeSpell = spells[selectedSpellID];
    }

    public void InitializeShield()
    {
        shieldHealth = maxShieldHealth;
        shieldRepairs = maxShieldRepairs;
        shieldActive = false;
    }

    public void InitializeMana()
    {
        mana = maxMana;
        manaRegen = maxManaRegen;
    }

    public void ActivateShield()
    {
        shieldActive = true;
    }

    public void DeactivateShield()
    {
        shieldActive = false;
    }

    public void RejuvenateMana()
    {
        if (manaRegen <= 0)
            return;
        
        manaRegen--;
        mana += manaRegenAmount;

        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }

    public void TakeDamageToShield(float damage)
    {
        shieldHealth -= damage;

        if (shieldHealth < 0)
        {
            shieldHealth = 0;
        }
    }

    public void TakeDirectDamage(float damage)
    {
        health -= damage;
    }

    public void TakeEnemyDamage(float damage, bool ignoreShield)
    {
        if (!shieldActive || ignoreShield || shieldHealth <= 0)
        {
            TakeDirectDamage(damage);
            return;
        }

        if (damage <= shieldHealth)
        {
            TakeDamageToShield(damage);
            return;
        }

        float leftoverDamage = damage - shieldHealth;
        TakeDamageToShield(shieldHealth);
        TakeDirectDamage(leftoverDamage);
    }

    public void TakeEnemyMagicDamage(float damage)
    {
        TakeEnemyDamage(damage + 5f, false);
    }

    public void RepairShield()
    {
        if (shieldRepairs <= 0)
            return;

        shieldRepairs--;
        shieldHealth += shieldRepairAmount;

        if (shieldHealth > maxShieldHealth)
        {
            shieldHealth = maxShieldHealth;
        }
    }

    private void Start()
    {
        activeWeapon = weapons[0];
        activeSpell = spells[0];
        InitializeShield();
        InitializeMana();
    }
}
