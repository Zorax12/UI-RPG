using UnityEngine;

public class PoisonWeapon : Weapon
{
    public float poisonDamage;
    public int poisonCount;
    public override float GetDamage() 
    { 
        float damage = base.GetDamage();
        if (poisonCount > 0) 
        {
        poisonCount--;
            damage += poisonDamage;
        }
        return damage;
    }
}
