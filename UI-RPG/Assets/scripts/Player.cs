using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Weapon activeWeapon;

    public string ActiveWeaponName 
    {
        get { return activeWeapon.weaponName; }
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

    private void Start()
    {
        activeWeapon = weapons[0];
    }
}
