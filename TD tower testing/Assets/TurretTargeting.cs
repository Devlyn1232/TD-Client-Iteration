using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask Enemy;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, Enemy))
        {
            /*
            if (CanAttack)
            {
                StartCoroutine(bullet());
                CanAttack = false;  
                StartCoroutine(ResetAttackCooldown());
            }
            */
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
