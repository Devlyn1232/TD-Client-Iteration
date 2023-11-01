using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    RaycastHit hit;
    public float degreesPerSecond;
    //public GameObject targetEnemy;
    public bool EnemyInRange;
    public GameObject ShootParticle;
    public ParticleSystem particleSystem;
    public bool CanAttack = true;
    public float Damage;
    public float shootCoolDown;
    public LayerMask EnemyLayerMask;
    public Transform EnemyCheck;
    public float range = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyInRange = Physics.CheckSphere(transform.position, range, EnemyLayerMask);
        if(EnemyInRange)
        {
            //send raycast to see im the enemy is able to be thit
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, EnemyLayerMask) && hit.collider.CompareTag("enemy"))
            {
                if (CanAttack)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Mathf.Infinity, Color.green);
                    // Start the coroutine
                    StartCoroutine(damageRaycast());
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.red);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.white);
            }
            //rotates gun to target
            Vector3 targetsDirection = GetTargetPosition() - this.transform.position;
            Quaternion lookRot = Quaternion.LookRotation(targetsDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, Time.deltaTime * degreesPerSecond);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,1,0,.3f);
        Gizmos.DrawWireSphere(transform.position, range);
    }
    Vector3 GetTargetPosition()
    {
        //get the targets position
        return FindClosestEnemy().transform.position;
    }
    public GameObject FindClosestEnemy()
        {
            // lists all the enemys with the enemy tag
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("enemy");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }
    IEnumerator damageRaycast()
    {
        CanAttack = false;
        //damage enemy
        EnemyHealth enemyHealth = FindClosestEnemy().gameObject.GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage(Damage);
        //visualisation
        ParticleSystem.ShapeModule psShape = particleSystem.shape;
        ParticleSystem psMain = particleSystem;
        psShape.position = new Vector3(0, 0, range / 2);
        psShape.scale = new Vector3(0, 0, range);
        psMain.maxParticles = Mathf.RoundToInt(range * 10);
        Instantiate (ShootParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        //cooldown
        yield return new WaitForSeconds (shootCoolDown);
        CanAttack = true;
    }
}