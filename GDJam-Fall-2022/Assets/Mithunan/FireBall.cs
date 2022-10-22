using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPos;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchFireBall(Transform pos, Rigidbody2D playerRb)
    {
        GameObject _fireBall = Instantiate(fireBall, pos.position, Quaternion.identity);
        if(playerRb.velocity.x > 0)
        {
            direction = new Vector2(5f, 0f);
        }
        else
        {
            direction = new Vector2(-5f, 0f);
        }
        _fireBall.GetComponent<Rigidbody2D>().AddForce(direction);
        _fireBall.GetComponent<Rigidbody2D>().AddTorque(0.4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
