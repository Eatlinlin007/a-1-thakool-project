using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public Animator anim;
    [SerializeField] HealthBar healthBar;


    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Die();
            return true;
        }
        else return false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
       // Debug.Log($"{this.name} took {damage} damage; Remaining Health: {this.Health}");
         healthBar.UpdateHealthBar(health);

         IsDead();
    }
    public virtual void Init(int newHealth)
    {
        Health = newHealth;
         healthBar.SetMaxHealth(newHealth);

        anim = GetComponent<Animator>();


    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
