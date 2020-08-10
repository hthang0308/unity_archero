using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public int id;
    public HealthBase health;
    public AttackControl attackControl;
    public PlayerMoving movement;
    public DamageSourceBase dmgSource;
    public Status status;
    public ExperiencePoint experience;
    FixedJoystick inputMoving;

    public PlayerManager(PlayerInfo info)
    {
        health = info.health;
        attackControl = info.attackControl;
        movement = info.movement as PlayerMoving;
        dmgSource = info.dmgSource;
        status = info.status;
        experience = info.experience;
        inputMoving = GameManager.instance.movingInput;
    }

    public void GetInput()
    {
        movement.GetInput(inputMoving.Horizontal, inputMoving.Vertical);
    }

}
