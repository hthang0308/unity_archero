using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public DynamicJoystick movingInput;
    [SerializeField] protected PlayerInfo player;
    PlayerMoving moving;

    void Start()
    {
        moving = player.playerMoving;
    }

    // Update is called once per frame
    void Update()
    {
        moving.GetInput(movingInput.Horizontal, movingInput.Vertical);
    }
}
