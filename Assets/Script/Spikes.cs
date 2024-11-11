using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Trap
{
    void Start()
    {
        DamageHit = 200;
    }
    
    public override void Behaviour()
    {
        Debug.Log("Hit");
    }

}
