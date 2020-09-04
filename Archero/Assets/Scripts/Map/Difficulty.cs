using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : BaseMonoBehaviour
{
    public MapInfo mapInfo;
    [SerializeField] List<LivingObjectInfo> livingObject;
    [SerializeField] List<LivingData> data;
    public LivingData LoadDifficulty(LivingObjectInfo info)
    {
        for (int i=0;i<livingObject.Count;i++)
            if (livingObject[i].name==info.name)
                return data[i];
        Debug.Log("null");
        return null;
    }
}
