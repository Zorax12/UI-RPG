using UnityEngine;

public class PosionEnemy : Enemy
{
    [SerializeField] private float minPoisonDamage = 5f;
    [SerializeField] private float maxPoisonDamage = 10f;
    [SerializeField] private int poisonCharges = 2;

    public override string ExtraInfoText
    {
        get
        {
            return "Poison: " + minPoisonDamage.ToString("F0") + " - " + maxPoisonDamage.ToString("F0");
        }
    }

    public override void DealDamageToPlayer(Player player)
    {
        float damage = RollDamage();

        if (poisonCharges > 0)
        {
            poisonCharges--;
            damage += Random.Range(minPoisonDamage, maxPoisonDamage);
        }

        player.TakeEnemyDamage(damage, IgnoresShield);
    }
}
