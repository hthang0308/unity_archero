using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameManager()
    {
        if (instance == null)
            instance = this;
    }

    public PlayerInfo player;
    public PlayerManager playerManager;
    public FixedJoystick movingInput;

    void Awake()
    {
        playerManager = new PlayerManager(player);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    //maybe temporary handle the input
    void GetInput()
    {
        playerManager.GetInput();
    }
}
