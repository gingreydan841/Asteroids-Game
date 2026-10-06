using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 direction;
    public AsteroidGenerator generator;
    public float asteroidRotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asteroidRotationSpeed = Random.Range(-100f, 100f);
        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(0, 0, asteroidRotationSpeed * Time.deltaTime); // rotates on z axis -> spins
        WrapScreen();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            generator.asteroidCount--;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
