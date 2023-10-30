using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemy : MonoBehaviour
{
    public bool canSummon;
    public float summonEnemySpeed;
    public GameObject Enemy;
    // Update is called once per frame
    void Update()
    {
        if (canSummon)
        {
            StartCoroutine(summonEnemy());
        }
        
    }
    IEnumerator summonEnemy()
    {
        canSummon = false;
        Instantiate (Enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        yield return new WaitForSeconds (summonEnemySpeed);
        canSummon = true;
    }
}
