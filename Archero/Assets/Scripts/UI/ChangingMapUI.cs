using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingMapUI : BaseMonoBehaviour
{
    public void StartChangingMap()
    {
        Time.timeScale = 0;
    }

    public void ChangeMap()
    {
        MapManager.instance.ChangeMap();
    }

    public void FinishChangingMap()
    {
        Time.timeScale = 1f;
    }

    public void Finished()
    {
        gameObject.SetActive(false);
    }
}
