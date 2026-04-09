using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float health;
    private float maxHealth;
    [SerializeField] private string charName;

    void Awake()
    {
        maxHealth = health;
    }

    public string CharName 
    {
        get { return charName; }
    }

    public float Health 
    {
        get { return health; }    
    }

    public abstract void Attack(Character toHit);

    public virtual void TakeDamage(float damage) 
    {
        health = health - damage;
        Debug.Log(charName + " got hit for " + damage + " damage! " + "Current health: " + health);
    }

    public virtual void TakeDamage(Weapon weapon)
    {
        float damage = weapon.GetDamage();
        health = health - damage;
    }

    public virtual void TakeMagicDamage(float damage)
    {
        TakeDamage(damage);
    }
    
    public void Heal(float amount)
    {
        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
