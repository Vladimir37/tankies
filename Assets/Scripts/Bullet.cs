using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    private Animator myAnimator;
    
    private Direction direction;

    private Tank emitter;

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
            myRigidbody.velocity = direction.MyDirectionVector.normalized * speed;
        }
    }

    public void Initialize(Direction bulletDirection, float bulletSpeed, Tank bulletEmitter)
    {
        isHitted = false;
        direction = bulletDirection;
        speed = bulletSpeed;
        emitter = bulletEmitter;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction.MyRotation));
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable target = collision.transform.gameObject.GetComponent<Damageable>();

        if (emitter == target)
        {
            return;
        }
        
        speed = 0;
        Destroy(GetComponent<BoxCollider2D>());
        
        myAnimator.SetTrigger("Hit");

        

        if (target != null)
        {
            target.Hit();
        }
    }
}
