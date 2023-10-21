using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10;
    // Start is called before the first frame update
    void Update()
    {
        
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
