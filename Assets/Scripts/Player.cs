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
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
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
}
