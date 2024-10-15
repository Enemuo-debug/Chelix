using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private float offset;
    void Awake()
    {
        offset = FindObjectOfType<PlayerController>().transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, FindObjectOfType<PlayerController>().transform.position.y - offset, transform.position.z);
    }
}
