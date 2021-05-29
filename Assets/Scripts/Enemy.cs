using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    private Orientation targetAxis;

    private float targetPoint;

    public Vector3 Position => transform.position;

    public override void Update()
    {
        if (IsMoved)
        {
            CheckPositionReached();
        }
        
        // DEBUG
        TestEnemyMove();
        // END DEBUG
        
        base.Update();
    }
    
    // DEBUG тестовые кнопки для проверки езды ИИ
    private void TestEnemyMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveTo(Orientation.Vertical, 7);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveTo(Orientation.Vertical, -4);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveTo(Orientation.Horizontal, -5);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveTo(Orientation.Horizontal, 4);
        }
    }
    // END DEBUG

    public void Init()
    {
        // DEBUG DATA
        TankInitialize(DirectionManager.Instance.Directions[CardinalPoint.South], 3, 5, 1);
    }
    
    public void MoveTo(Orientation axis, float point)
    {
        Vector3 currentPosition = transform.position;

        targetAxis = axis;
        targetPoint = point;

        if (axis == Orientation.Vertical)
        {
            if (currentPosition.y > point)
            {
                ChangeDirection(DirectionManager.Instance.Directions[CardinalPoint.South]);
            }
            else
            {
                ChangeDirection(DirectionManager.Instance.Directions[CardinalPoint.North]);
            }
        }
        else if (axis == Orientation.Horizontal)
        {
            if (currentPosition.x > point)
            {
                ChangeDirection(DirectionManager.Instance.Directions[CardinalPoint.West]);
            }
            else
            {
                ChangeDirection(DirectionManager.Instance.Directions[CardinalPoint.East]);
            }
        }
        
        Move();
    }

    private void CheckPositionReached()
    {
        Vector3 currentPosition = transform.position;
        float currentPoint;
        
        if (targetAxis == Orientation.Vertical)
        {
            currentPoint = currentPosition.y;
        }
        else if (targetAxis == Orientation.Horizontal)
        {
            currentPoint = currentPosition.x;
        }
        else
        {
            Stop();
            return;
        }

        float distance = Mathf.Abs(targetPoint - currentPoint);
        
        // Если слишком далеко
        if (distance > 0.1)
        {
            return;
        }
        
        if (targetAxis == Orientation.Vertical)
        {
            transform.position = new Vector3(currentPosition.x, targetPoint, currentPosition.z);
        }
        else if (targetAxis == Orientation.Horizontal)
        {
            transform.position = new Vector3(targetPoint, currentPosition.y, currentPosition.z);
        }
        
        Stop();
    }
}
