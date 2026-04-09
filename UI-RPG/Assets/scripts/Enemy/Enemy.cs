using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float minDamage, maxDamage;

    public virtual string ExtraInfoText
    {
        get { return ""; }
    }

    public virtual bool IgnoresShield
    {
        get { return false; }
    }

    public float RollDamage()
    {
        return Random.Range(minDamage, maxDamage);
    }

    public virtual void DealDamageToPlayer(Player player)
    {
        float damage = RollDamage();
        player.TakeEnemyDamage(damage, IgnoresShield);
    }

    public override void Attack(Character toHit)
    {
        float damage = RollDamage();
        toHit.TakeDamage(damage);
    }
}
