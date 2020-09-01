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
            if (equipments.cloth.Equipment)
                equipments.cloth.Equipment.Affect(player);
            if (equipments.weapon.Equipment)
                equipments.weapon.Equipment.Affect(player);
            if (equipments.spirit.Equipment)
                equipments.spirit.Equipment.Affect(player);
            if (equipments.ring.Equipment)
                equipments.ring.Equipment.Affect(player);
            Destroy(equipments.parentGameObject);
            equipments = null;
        }
        //ignore collider boss voi nguoi choi
        Physics.IgnoreLayerCollision(18, 13, true);
        Physics.IgnoreLayerCollision(18, 16, true);
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
}
