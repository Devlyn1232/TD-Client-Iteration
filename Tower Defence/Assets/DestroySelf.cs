using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float LifeTime;
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

}
