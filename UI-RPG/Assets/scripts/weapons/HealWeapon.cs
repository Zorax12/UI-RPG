using UnityEngine;

public class HealWeapon : Weapon
{
    [SerializeField] private float healAmount = 4f;

    public override string AbilityDescription
    {
        get { return "heal " + healAmount.ToString("F0"); }
    }

    public float HealAmount
    {
        get { return healAmount; }
    }
}
