using UnityEngine;

public class FastEnemy : Enemy
{
    public override bool IgnoresShield
    {
        get { return true; }
    }

    public override string ExtraInfoText
    {
        get { return "Ignores shield"; }
    }
}
