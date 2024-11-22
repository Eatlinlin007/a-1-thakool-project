using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : Trap
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[1];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;
    private void Start()
    {
        DamageHit = 100;
        speed = 0.75f;
        range = 10;
        checkDelay = 0;

    }
    private void Update()
    {
        //Move spikehead to destination only if attacking
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                Type();
        }
    }
    public override void Type()
    {
        CalculateDirections();

        //Check if spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
                Destroy(this.gameObject, 12f);
            }
        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; //Right direction

    }

}