using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    private Dictionary<KeyCode, CardinalPoint> controlButtons = new Dictionary<KeyCode, CardinalPoint>()
    {
        {KeyCode.W, CardinalPoint.North},
        {KeyCode.A, CardinalPoint.West},
        {KeyCode.S, CardinalPoint.South},
        {KeyCode.D, CardinalPoint.East}
    };
        
    // Start is called before the first frame update
    public override void Start()
    {
        // DEBUG
        TankInitialize(DirectionManager.Instance.Directions[CardinalPoint.North], 5, 5, 0.3f);
        
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    
    private void OnGUI()
    {
        Event e = Event.current;
    
        if (e.isKey && e.keyCode != KeyCode.None && controlButtons.ContainsKey(e.keyCode))
        {
            if (e.type == EventType.KeyDown)
            {
                ChangeDirection(DirectionManager.Instance.Directions[controlButtons[e.keyCode]]);
                Move();
            }
            else if (e.type == EventType.KeyUp)
            {
                if (DirectionManager.Instance.Directions[controlButtons[e.keyCode]] == MyDirection)
                {
                    Stop();
                }
            }
        }
    }
    
    public override void Death()
    {
        base.Death();
        
        GameManager.Instance.LoseTheGame(GameManager.DefeatTypes.TankDestroyed);
    }
}
