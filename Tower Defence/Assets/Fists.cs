using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fists : MonoBehaviour
{
    public GameObject fistsObject;  // Renamed the variable

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey("1"))
        {
            Animator animator = fistsObject.GetComponent<Animator>();
            animator.SetTrigger("Attack");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Animator animator = fistsObject.GetComponent<Animator>();
            animator.SetTrigger("Special");
        }
    }
}