using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float minDamage, maxDamage;

    public override void Attack(Character toHit)
    {
        float damage = Random.Range(minDamage, maxDamage);
        toHit.TakeDamage(damage);
    }
}
