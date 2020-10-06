using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    public float horizontalBoundry;
    public float horizontalSpeed;
    public float maxSpeed;

    private Vector3 touchEnd;
    private Rigidbody2D m_rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        touchEnd = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _Checkbounds();
        _FireBullet();
    }
    private void _FireBullet()
    {
        // delay bullet fire every 40 frames
        if(Time.frameCount % 40 == 0)
        {
            bulletManager.GetBullet(transform.position);
        }
    }
    private void _Move()
    {
        float direction = 0.0f;
       

        //Touch input
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.x)
            {
                // direction is positive
                direction = 1.0f;
            }
            if (worldTouch.x < transform.position.x)
            {
                // direction is negative
                direction = -1.0f;
            }

            touchEnd = worldTouch;
        }

        
        //var worldTouch = Camera.main.ScreenToWorldPoint(firstTouch.position);
       

        // Keyboard input 
        if(Input.GetAxis("Horizontal") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }
        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        //Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
        //m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
        //m_rigidBody.velocity *= 0.99f;

        if(touchEnd.x != 0.0f)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchEnd.x, 0.1f), transform.position.y);
        }
    }

    private void _Checkbounds()
    {
        // check right bounds
        if(transform.position.x >= horizontalBoundry)
        {
            transform.position = new Vector3(horizontalBoundry, transform.position.y);
        }
        // Check left bounds
        if (transform.position.x <= -horizontalBoundry)
        {
            transform.position = new Vector3(-horizontalBoundry, transform.position.y);
        }
    }
}
