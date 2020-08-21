using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public DynamicJoystick movingInput;
    [SerializeField] protected PlayerInfo player;
    MovingBase moving;

    void Start()
    {
        moving = player.movement;
    }

    // Update is called once per frame
    void Update()
    {
        moving.direction = new Vector3(movingInput.Horizontal, 0f, movingInput.Vertical);
    }
}
