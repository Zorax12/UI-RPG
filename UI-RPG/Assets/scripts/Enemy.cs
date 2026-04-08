using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float minDamage, maxDamage;

    public float RollDamage()
    {
        return Random.Range(minDamage, maxDamage);
    }

    public override void Attack(Character toHit)
    {
        float damage = RollDamage();
        toHit.TakeDamage(damage);
    }
}
