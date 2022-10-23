using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPos;
    public Vector2 fireBallForce = new Vector2(80f, -3f);
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
            direction = new Vector2(fireBallForce.x, fireBallForce.y);
        }
        else
        {
            direction = new Vector2(-fireBallForce.x, fireBallForce.y);
        }
        _fireBall.GetComponent<Rigidbody2D>().AddForce(direction);
        _fireBall.GetComponent<Rigidbody2D>().AddTorque(4f);
    }
    
}
