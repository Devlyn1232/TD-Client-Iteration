using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    public float killtime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, killtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
