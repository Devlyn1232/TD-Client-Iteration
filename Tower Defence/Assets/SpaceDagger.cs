using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDagger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject daggerObject;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey("1"))
        {
            Animator animator = daggerObject.GetComponent<Animator>();
            animator.SetTrigger("Attack");
        }
    }
}
