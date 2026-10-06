using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float propel = 15f;
    public float rotationSpeed = 200f;
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    public Hearts lives;
    private float moveInput;
    private float rotateInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,-rotateInput*rotationSpeed*Time.deltaTime);
        WrapScreen();
    }

    void FixedUpdate()
    {
        if(moveInput > 0)
        {
            rb.AddForce(transform.up * propel);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }

    void OnRotate(InputValue value)
    {
        rotateInput = value.Get<float>();
    }

    void OnShoot(InputValue value)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.up * 0.3f, transform.rotation);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = transform.up * 10f;
    }

    void WrapScreen()
    {
        Camera cam = Camera.main;
        Vector3 vp = cam.WorldToViewportPoint(transform.position);

        if (vp.x > 1)
        {
            vp.x = 0;
        }
        else if (vp.x < 0)
        {
            vp.x = 1;
        }

        if (vp.y > 1)
        {
            vp.y = 0;
        }
        else if (vp.y < 0)
        {
            vp.y = 1;
        }

        transform.position = cam.ViewportToWorldPoint(vp);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            //Debug.Log("Player hit by asteroid!");
            lives.LoseLife();

            if(lives.lives > 0)
            {
                Respawn();
            }
        }
    }

    void Respawn()
    {
        transform.position = Vector3.zero; //moves to center
        rb.linearVelocity = Vector2.zero;  //stops ship movement when respawned
        rb.angularVelocity = 0;
        moveInput = 0;
    }
}
