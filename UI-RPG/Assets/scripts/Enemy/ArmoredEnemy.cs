using UnityEngine;

public class ArmoredEnemy : Enemy
{
    [SerializeField] private float armorHealth = 20f;

    public float ArmorHealth
    {
        get { return armorHealth; }
    }

    public float TotalHealth
    {
        get { return health + armorHealth; }
    }

    public override string ExtraInfoText
    {
        get
        {
            return "Armor: " + armorHealth.ToString("F0");

        }
    }

    public override void TakeDamage(float damage)
    {
        float remainingDamage = damage;

        if (armorHealth > 0)
        {
            float armorDamage = Mathf.Min(armorHealth, remainingDamage);
            armorHealth -= armorDamage;
            remainingDamage -= armorDamage;
        }

        if (remainingDamage > 0)
        {
            base.TakeDamage(remainingDamage);
        }
    }

    public override void TakeDamage(Weapon weapon)
    {
        float damage = weapon.GetDamage() - 5f;
        if (damage < 0f)
            damage = 0f;

        TakeDamage(damage);
    }

    public override void TakeMagicDamage(float damage)
    {
        TakeDamage(damage + 5f);
    }
}
