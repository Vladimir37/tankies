using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private Animator animator;
    
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
        animator = GetComponent<Animator>();
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction.MyRotation));
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed = 0;
        Destroy(GetComponent<BoxCollider2D>());
        
        animator.SetTrigger("Hit");
        
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(collision.transform.gameObject);
        }
    }
}
