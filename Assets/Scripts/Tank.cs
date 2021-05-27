using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : Damageable
{
    private Direction direction;

    private Rigidbody2D myRigidbody;
    
    [SerializeField]
    private Transform tankSprite;

    [SerializeField]
    private GameObject bulletPrefab;
    
    private int speed;

    private float attackCooldown;

    private float timeFromLastAttack;

    private bool isMoved;

    public Direction MyDirection => direction;

    // Start is called before the first frame update
    public virtual void Start()
    {
        isMoved = false;
        myRigidbody = GetComponent<Rigidbody2D>();
        direction = DirectionManager.Instance.Directions[CardinalPoint.North];
    }

    // Update is called once per frame
    public virtual void Update()
    {
        timeFromLastAttack += Time.deltaTime;
        
        if (isMoved)
        {
            myRigidbody.velocity = MyDirection.MyDirectionVector.normalized * speed;
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }

    protected void TankInitialize(int tankHealth, int tankSpeed, float tankFireCooldown)
    {
        HealthInit(tankHealth);
        speed = tankSpeed;
        attackCooldown = tankFireCooldown;
        timeFromLastAttack = tankFireCooldown;
    }

    protected void Move()
    {
        isMoved = true;
    }

    protected void Stop()
    {
        isMoved = false;
    }

    protected void ChangeDirection(Direction newDirection)
    {
        if (MyDirection == newDirection)
        {
            return;
        }
        
        // Позиция при развороте
        if (MyDirection.MyOrientation != newDirection.MyOrientation)
        {
            if (newDirection.MyOrientation == Orientation.Horizontal)
            {
                transform.position = new Vector3(transform.position.x, CalculateTankPosition(transform.position.y), 0);
            }
            else if (newDirection.MyOrientation == Orientation.Vertical)
            {
                transform.position = new Vector3(CalculateTankPosition(transform.position.x), transform.position.y, 0);
            }
        }
        
        direction = newDirection;
        tankSprite.rotation = Quaternion.Euler(new Vector3(0, 0, MyDirection.MyRotation));
    }

    protected void Attack()
    {
        if (timeFromLastAttack >= attackCooldown)
        {
            timeFromLastAttack = 0;

            Bullet bullet = Instantiate(bulletPrefab, CalculateBulletPosition(), Quaternion.identity).GetComponent<Bullet>();
            bullet.Initialize(MyDirection, 10);
        }
    }
    
    private float CalculateTankPosition(float position)
    {
        return (float)Math.Round(position * 2, MidpointRounding.AwayFromZero) / 2;
    }

    private Vector3 CalculateBulletPosition()
    {
        Vector3 bulletPosition = transform.position + (Vector3)direction.MyDirectionVector * 0.7f;

        return bulletPosition;
    }
}
