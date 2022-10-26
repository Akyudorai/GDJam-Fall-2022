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
    public GameObject projectilePos;
    CapsuleCollider2D collider;
    public GameObject mainCamera;
    public Sprite kainat;

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
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.69f, 0.08f);
            if (isGrounded())
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
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0.65f, 0.08f);
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

        if(Input.GetKeyDown(KeyCode.E))
        {
            //GetComponent<FireBall>().LaunchFireBall(projectilePos.transform, rb);
        }

        if(Input.GetMouseButtonUp(0))
        {
            Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.Normalize();

            GetComponent<FireBall>().LaunchFireBall(projectilePos.transform, -direction);

        }
        //mainCamera.GetComponent<Transform>().position = new Vector3(this.gameObject.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
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
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground") {
            Debug.Log("Ground Collision!");
            StartCoroutine(cameraShakeRef.Shake(0.5f, 1f));
        }
    }

    public IEnumerator KainatWakesUp()
    {
        GetComponent<SpriteRenderer>().sprite = kainat;
        GetComponent<Transform>().localScale = GetComponent<Transform>().localScale * 0.5f;
        GetComponent<Transform>().position = new Vector3(this.gameObject.transform.position.x, 10f, this.gameObject.transform.position.z);
        yield return new WaitForSeconds(3);
        GameObject.Find("GameManager").GetComponent<Points>().EndGame();
    }

}
