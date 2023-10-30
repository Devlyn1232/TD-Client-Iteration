using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    public GameObject Turret;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetPosition = hit.point;
                Transform target = hit.transform;

                Instantiate (Turret, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z), target.rotation);
                Debug.Log("Hit position: " + targetPosition);
            }
        }
    }
}
