using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IMovingPlatform
{
    public float Speed { get; set; }
    public int StartingPoint { get; set; }
    [SerializeField] private Transform[] points;
    public Transform[] Points 
    {
        get
        { 
            return points; 
        } 
        set 
        { 
            points = value; 
        } 
    }

    private int i;

    void Start()
    {
        Speed = 2;
        transform.position = Points[StartingPoint].position;
    }

    void Update()
    {
        Moving();
    }

    public void Moving()
    {
        if (Vector2.Distance(transform.position, Points[i].position) < 0.02f)
        {
            i++;
            if (i == Points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Points[i].position, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AttachToPlatform(collision.transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        DetachFromPlatform(collision.transform);
    }

    public void AttachToPlatform(Transform transform)
    {
        transform.SetParent(this.transform);
    }

    public void DetachFromPlatform(Transform transform)
    {
        transform.SetParent(null);
    }
}
