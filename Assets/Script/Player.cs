using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    void Start()
    {
        Init(100);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Trap trap = collision.gameObject.GetComponent<Trap>();
        if (trap != null)
        {
            OnHitWith(trap);
        }
    }
    public void OnHitWith(Trap trap)
    {
        TakeDamage(trap.DamageHit);
    }
}
