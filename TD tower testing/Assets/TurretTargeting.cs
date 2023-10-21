using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask Enemy;
    public Transform rotPoint;
    public float degreesPerSecond;
    public GameObject targetEnemy;
    public GameObject ShootParticle;
    public bool CanAttack = true;
    public float Damage;
    public float shootCoolDown;
    public float Range;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Range, Enemy))
        {
            if (CanAttack)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Range, Color.green);
                StartCoroutine(damageRaycast());
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Range, Color.white);
        }
        
        Vector3 targetsDirection = GetTargetPosition() - this.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(targetsDirection);
        rotPoint.rotation = Quaternion.RotateTowards(rotPoint.rotation, lookRot, Time.deltaTime * degreesPerSecond);
    }
    Vector3 GetTargetPosition()
    {
        return targetEnemy.transform.position;
    }
    IEnumerator damageRaycast()
    {
        print("asdsad");
        CanAttack = false;
        EnemyHealth enemyHealth = targetEnemy.gameObject.GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage(Damage);
        Instantiate(ShootParticle, transform.position, transform.position, transform.position);
        yield return new WaitForSeconds (shootCoolDown);
        CanAttack = true;
    }
}
