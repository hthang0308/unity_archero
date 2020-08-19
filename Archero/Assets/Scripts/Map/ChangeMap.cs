using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : BaseMonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInfo>() != null)
        {
            Debug.Log("ChangeMap");
        }
    }

}
