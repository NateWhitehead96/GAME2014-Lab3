using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundry;
   

    // Update is called once per frame
    void Update()
    {
        _Move();
        _Checkbounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(0.0f, verticalBoundry);
    }

    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed);
    }

    private void _Checkbounds()
    {
        // if the background is lower than the bottom of the screen
        if(transform.position.y <= -verticalBoundry)
        {
            _Reset();
        }
    }
}
