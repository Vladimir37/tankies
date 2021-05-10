using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{
    private Direction direction;

    private Rigidbody2D myRigidbody;

    private int health;

    private int speed;

    private bool isMoved;

    public Direction MyDirection => direction;

    // Start is called before the first frame update
    public virtual void Start()
    {
        isMoved = false;
        speed = 5;
        myRigidbody = GetComponent<Rigidbody2D>();
        direction = DirectionManager.Instance.Directions[CardinalPoint.North];
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //
    }

    protected void Move()
    {
        myRigidbody.velocity = MyDirection.MyDirectionVector.normalized * speed;
    }

    protected void Stop()
    {
        myRigidbody.velocity = Vector2.zero;
    }

    protected void ChangeDirection(Direction newDirection)
    {
        if (MyDirection == newDirection)
        {
            return;
        }
        
        if (MyDirection.MyOrientation != newDirection.MyOrientation)
        {
            // TODO выравнивание по тайлам
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, newDirection.MyRotation));

        direction = newDirection;
    }
}
