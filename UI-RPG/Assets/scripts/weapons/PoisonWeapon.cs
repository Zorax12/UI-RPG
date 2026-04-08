using UnityEngine;

public class PoisonWeapon : Weapon
{
    [SerializeField] private float minPoisonDamage;
    [SerializeField] private float maxPoisonDamage;
    [SerializeField] private int poisonCount;

    public override string AbilityDescription
    {
        get { return "poison " + minPoisonDamage.ToString("F0") + " - " + maxPoisonDamage.ToString("F0"); }
    }

    public override float GetDamage() 
    { 
        float damage = base.GetDamage();
        if (poisonCount > 0) 
        {
            poisonCount--;
            damage += Random.Range(minPoisonDamage, maxPoisonDamage);
        }
        return damage;
    }
}
