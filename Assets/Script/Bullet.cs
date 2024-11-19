using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    public IShootable shooter;

    public abstract void OnHitWith(Character character);

    public abstract void Move();

     private void OnTriggerEnter2D(Collider2D other)
     {
         OnHitWith(other.GetComponent<Character>());
         Destroy(this.gameObject, 12f);
    }
}

