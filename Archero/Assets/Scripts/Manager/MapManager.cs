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
    [SerializeField] protected GameObject changingMapCanvas;

    [SerializeField] GameObject endGamePanel;

    public void Awake()
    {
        ChangeMap();
    }

    public void ChangeMap()
    {
        if (curMap != null)
            Destroy(curMap.gameObject);
        if (mapInit==null)
        {
            Debug.Log("bug");
            return;
        }
        curMap = Instantiate(mapInit);
        GameManager.instance.enemies = curMap.enemies;
        GameManager.instance.player.transform.SetPositionAndRotation(curMap.startingPos.position, Quaternion.identity);
        cameraControl.SetClamp(curMap.startingPos.position.z, curMap.endingPos.transform.position.z);
        mapInit = curMap.nextMap;
    }

    public void ChangingMap()
    {
        changingMapCanvas.SetActive(true);
        if (mapInit == null)
        {
            endGamePanel.SetActive(true);
        }
    }
}
