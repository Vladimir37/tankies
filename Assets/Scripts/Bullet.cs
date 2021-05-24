using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    
    private Direction direction;

    private float speed;

    private bool isHitted;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHitted)
        {
            rigidbody.velocity = direction.MyDirectionVector.normalized * speed;
        }
    }

    public void Initialize(Direction bulletDirection, float bulletSpeed)
    {
        isHitted = false;
        direction = bulletDirection;
        speed = bulletSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction.MyRotation));
    }
}
