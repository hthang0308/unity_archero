using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public MapManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    [SerializeField] protected MapInfo mapInit;
    [HideInInspector] public MapInfo curMap;
    public CameraControl cameraControl;

    public void Awake()
    {
        ChangeMap();
    }

    public void ChangeMap()
    {
        if (mapInit == null)
            return;
        if (curMap != null)
            Destroy(curMap.gameObject);
        curMap = Instantiate(mapInit);
        GameManager.instance.enemies = curMap.enemies;
        GameManager.instance.player.transform.SetPositionAndRotation(curMap.startingPos.position, Quaternion.identity);
        cameraControl.SetClamp(curMap.startingPos.position.z, curMap.endingPos.transform.position.z);
        mapInit = curMap.nextMap;

    }


}
