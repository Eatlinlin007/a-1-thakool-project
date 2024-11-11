using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : Character
{
    private int damageHit;
    public int DamageHit
    {
        get
        {
            return damageHit;
        }
        set
        {
            damageHit = value;
        }
    }
    public abstract void Behaviour();
}
