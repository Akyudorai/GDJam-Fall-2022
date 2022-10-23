using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Destructable : Destructable
{
    public int pointsValue = 10;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDeath()
    {
        Points.points.AddPoints(pointsValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fireball") || collision.gameObject.CompareTag("Player"))
        {
            OnDeath();
            Destroy(this.gameObject);
        }
        
    }
}
