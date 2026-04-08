using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float minDamage, maxDamage;
    public string weaponName;

    public float MinDamage
    {
        get { return minDamage; }
    }

    public float MaxDamage
    {
        get { return maxDamage; }
    }

    public virtual string AbilityDescription
    {
        get { return "None"; }
    }

    public virtual float GetDamage() 
    {
        return Random.Range(minDamage, maxDamage);    
    }
}
