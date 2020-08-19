using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameManager()
    {
        if (instance == null)
        {
            instance = this;
            AnimatorParameters.Init();
        }
    }

    [SerializeField] protected MapInfo curMap;

    public PlayerInfo player;
    public List<LivingObjectInfo> enemies;
    public CameraControl cameraControl;

    public void Awake()
    {
        enemies = curMap.enemies;
        player.transform.SetPositionAndRotation(curMap.startingPos.position, Quaternion.identity);
        cameraControl.SetClamp(curMap.startingPos.position.z, curMap.endingPos.transform.position.z);
    }

    public void RemoveEnemy(LivingObjectInfo enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
            curMap.endingPos.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
