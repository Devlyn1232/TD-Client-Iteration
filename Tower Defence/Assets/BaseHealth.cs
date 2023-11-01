using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float startHealth = 100;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
