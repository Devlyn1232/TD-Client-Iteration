using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIfHit : MonoBehaviour
{
    public float damage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyHealth playerHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
