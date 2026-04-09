using UnityEngine;

public class MagicEnemy : Enemy
{
    [SerializeField] private float healChance = 0.3f;
    [SerializeField] private float minHealAmount = 5f;
    [SerializeField] private float maxHealAmount = 10f;

    public override string ExtraInfoText
    {
        get { return "Magic attack\nCan heal itself"; }
    }

    public bool TryHealInsteadOfAttack()
    {
        return Random.value < healChance;
    }

    public float GetHealAmount()
    {
        return Random.Range(minHealAmount, maxHealAmount);
    }

    public override void DealDamageToPlayer(Player player)
    {
        float damage = RollDamage();
        player.TakeEnemyMagicDamage(damage);
    }
}
