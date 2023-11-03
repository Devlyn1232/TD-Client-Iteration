using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float startHealth;
    public float currentHealth;
    public float collisionDamage;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        player = GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            // Get the Base.baseHealth component from the collided object
            BaseHealth baseHealth = collision.gameObject.GetComponent<BaseHealth>();

            if (baseHealth != null)
            {
                // Determine the amount of collision damage based on health
                if (baseHealth.currentHealth <= currentHealth)
                {
                    collisionDamage = baseHealth.currentHealth;  
                }
                else
                {
                    collisionDamage = currentHealth;
                }

                // Apply damage to both player character and base
                TakeDamage(collisionDamage);
                
                
                baseHealth.TakeDamage(collisionDamage);
            }
        }
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        PlayerStats playerStats = player.gameObject.GetComponent<PlayerStats>();
        playerStats.GainMoney(Mathf.RoundToInt(damage));
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
