using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    public GameObject turretPrefab;
    public GameObject turretOverlayPrefab;
    private GameObject turretOverlay;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Input.GetMouseButtonDown(0))
        {
            
        }
        // Check if 1 is being held down
        if (Input.GetKey("1"))
        {
            // Cast a ray to visualise where the turret is palced
            if (Physics.Raycast(ray, out hit))
            {
                if (turretOverlay == null)
                {
                    turretOverlay = Instantiate(turretOverlayPrefab, hit.point, Quaternion.identity);
                }
                else
                {
                    turretOverlay.transform.position = hit.point;
                }

                // When clicked summon real turret
                PlayerStats playerStats = player.gameObject.GetComponent<PlayerStats>();
                if (Input.GetKey("1") && Input.GetMouseButtonDown(0) && playerStats.Money >= 100)
                {
                    Instantiate(turretPrefab, turretOverlay.transform.position, Quaternion.identity);
                    Destroy(turretOverlay);
                    playerStats.GainMoney(-100);
                }
            }
            else
            {
                if (turretOverlay != null)
                {
                    Destroy(turretOverlay);
                }
            }
        }
        else
        {
            // If 1 is not held destroy turret overlay
            if (turretOverlay != null)
            {
                Destroy(turretOverlay);
            }
        }
    }
}
