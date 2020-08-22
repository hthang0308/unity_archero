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
        CurrentEquipment equipments = CurrentEquipment.instance;
        if (equipments)
        {
            equipments.cloth.equipment.Affect(player);
            equipments.weapon.equipment.Affect(player);
            equipments.spirit.equipment.Affect(player);
            equipments.ring.equipment.Affect(player);
            Destroy(equipments.gameObject);
            equipments = null;
        }

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
