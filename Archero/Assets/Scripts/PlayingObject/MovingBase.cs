using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBase : BaseMonoBehaviour
{
    [SerializeField] protected State state;
    [SerializeField] protected Rigidbody rigidbody;
    public float maxSpeed;
    protected float speed;
    [HideInInspector] public Vector3 direction = new Vector3();

}
