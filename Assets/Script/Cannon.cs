using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour,IShootable
{
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform SpawnPoint { get; set; }

    public float bulletWaitTime { get; set; }

    public float bulletTimer { get; set; }


    void Start()
    {
        bulletWaitTime = 0.0f;
        bulletTimer = 9.5f;
        AttackRange = 100;
    }

    private void FixedUpdate()
    {
        bulletWaitTime += Time.fixedDeltaTime;
        Range();
    }

    public void Range()
    {
        Vector2 distance = player.transform.position - transform.position;

        if (distance.magnitude <= attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletWaitTime >= bulletTimer)
        {
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            bulletWaitTime = 0;
        }
    }
}