using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(menuName = "LivingData/Player")]
public class PlayerData : LivingData
{
    [Header("Lv Exp")]
    [Space(20)]
    [SerializeField] float expLvUp = 30f;
    [Header("Player Style Attack")]
    [SerializeField] protected float startingDelay = 0.1f;
    [SerializeField] protected int numberShots = 1;
    //Front
    [SerializeField] protected int frontShot = 1;
    [SerializeField] protected float frontShotDeltaPos = 5f;

    //Diagonal
    [SerializeField] protected int diagonalShot = 0;
    [SerializeField] protected float diagonalShotAngle = 10f;
    [Header("Arrow Set Up")]
    [Space(20)]
    [SerializeField] protected float distance = 20f;

    public float ExpLvUp { get => expLvUp; }
    public float StartingDelay { get => startingDelay; }
    public int NumberShots { get => numberShots; }
    public int FrontShot { get => frontShot; }
    public float FrontShotDeltaPos { get => frontShotDeltaPos; }
    public int DiagonalShot { get => diagonalShot; }
    public float DiagonalShotAngle { get => diagonalShotAngle; }
    public float Distance { get => distance; }

}
