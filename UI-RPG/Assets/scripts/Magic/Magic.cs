using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] private float minDamage, maxDamage;
    [SerializeField] private int manaCost = 10;
    [SerializeField] private string spellName;

    public string SpellName
    {
        get { return spellName; }
    }

    public int ManaCost
    {
        get { return manaCost; }
    }

    public float MinDamage
    {
        get { return minDamage; }
    }

    public float MaxDamage
    {
        get { return maxDamage; }
    }

    public virtual string EffectDescription
    {
        get { return "None"; }
    }

    public virtual bool TargetsSelf
    {
        get { return false; }
    }

    public virtual float GetDamage()
    {
        return Random.Range(minDamage, maxDamage);
    }
}
