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

    

    public PlayerInfo player;
    [HideInInspector] public List<LivingObjectInfo> enemies;
    

    public void Awake()
    {
    }

    

    public void RemoveEnemy(LivingObjectInfo enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            MapManager.instance.curMap.endingPos.SetActive(true);
            GoldCoinPool.instance.GetExperience();
        }
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
