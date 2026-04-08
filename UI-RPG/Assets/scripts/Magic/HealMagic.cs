using UnityEngine;

public class HealMagic : Magic
{
    [SerializeField] private float minHealAmount = 10f;
    [SerializeField] private float maxHealAmount = 15f;

    public override bool TargetsSelf
    {
        get { return true; }
    }

    public override string EffectDescription
    {
        get { return "heal " + minHealAmount.ToString("F0") + " - " + maxHealAmount.ToString("F0"); }
    }

    public float GetHealAmount()
    {
        return Random.Range(minHealAmount, maxHealAmount);
    }
}
