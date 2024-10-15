using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHelix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 2) == 1) {
            GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
