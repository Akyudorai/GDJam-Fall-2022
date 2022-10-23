using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayerMask;
    Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float airForce = 100f;
    CapsuleCollider2D collider;

    [Header("Camera Shake")]
    public CameraShake cameraShakeRef;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            if(isGrounded())
            {
                rb.velocity = new Vector2(-speed, 0f);
            }
            else
            {
                rb.AddForce(new Vector2(-airForce, 0f) * Time.deltaTime);
            }
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            if (isGrounded())
            {
                rb.velocity = new Vector2(speed, 0f);
            }
            else
            {
                rb.AddForce(new Vector2(airForce, 0f) * Time.deltaTime);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private bool isGrounded()
    {
        float extraHeightTest = .05f;
        RaycastHit2D raycastHit = Physics2D.Raycast(collider.bounds.center, Vector2.down, collider.bounds.extents.y + extraHeightTest, groundLayerMask);
        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(collider.bounds.center, Vector2.down * (collider.bounds.extents.y + extraHeightTest), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground") {
            Debug.Log("Ground Collision!");
            StartCoroutine(cameraShakeRef.Shake(.15f, .4f));
        }
    }

}
