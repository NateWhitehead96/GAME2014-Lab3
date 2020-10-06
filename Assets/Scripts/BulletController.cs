using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float verticalSpeed;
    public BulletManager bulletManager;
    public float verticalBoundry;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _Checkbounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed);
    }

    private void _Checkbounds()
    {
       if(transform.position.y > verticalBoundry)
       {
            bulletManager.ReturnBullet(gameObject);
       }
    }
}
