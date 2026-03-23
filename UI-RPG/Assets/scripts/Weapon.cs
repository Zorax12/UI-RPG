using UnityEngine;

public class Weapon : MonoBehaviour
{
  [SerializeField] private float minDamage, maxDamage;
    public string weaponName;

    public virtual float GetDamage() 
    {
        return Random.Range(minDamage, maxDamage);    
    }
}
