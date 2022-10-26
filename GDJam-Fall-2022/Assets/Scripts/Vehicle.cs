using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public int value;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeath()
    {
        if(dead == false)
        {
            Points.points.AddPoints(value);
        }
        dead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            OnDeath();
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            OnDeath();
            if(this.gameObject.GetComponent<AudioSource>() != null)
            {
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(this.gameObject.GetComponent<AudioSource>().clip);
            }
            Destroy(this.gameObject);
        }

    }
}
