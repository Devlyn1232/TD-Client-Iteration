using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemieAi : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent enemy;
    GameObject Base;
    //public float damage;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Base = GameObject.FindWithTag("Base");
    }

    // Update is called once per frame
    void Update()
    {
        if (Base != null)
        {
            enemy.SetDestination(Base.transform.position);
        }
    }
}
