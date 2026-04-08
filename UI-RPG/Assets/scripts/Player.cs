using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Weapon activeWeapon;

    [SerializeField] private float maxShieldHealth = 30f;
    [SerializeField] private float shieldRepairAmount = 10f;
    [SerializeField] private int maxShieldRepairs = 3;

    private float shieldHealth;
    private int shieldRepairs;

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

    public float ShieldHealth
    {
        get { return shieldHealth; }
    }

    public int RemainingShieldRepairs
    {
        get { return shieldRepairs; }
    }

    private int selectedWeaponID = 0;

    public override void Attack(Character toHit)
    {
        toHit.TakeDamage(activeWeapon);
    }

    public void SwitchWeapon()
    {
        selectedWeaponID = (++selectedWeaponID) % weapons.Length;
        activeWeapon = weapons[selectedWeaponID];
    }

    public void InitializeShield()
    {
        shieldHealth = maxShieldHealth;
        shieldRepairs = maxShieldRepairs;
    }

    public void TakeDamageToShield(float damage)
    {
        shieldHealth -= damage;

        if (shieldHealth < 0)
        {
            shieldHealth = 0;
        }
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
        InitializeShield();
    }
}
