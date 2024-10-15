using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 lastTapPos;
    private float delta;
    private Vector3 startRotation;
    void Awake()
    {
        // startRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Vector2 curTapPos = Input.mousePosition;
            if (lastTapPos == Vector2.zero) {
                lastTapPos = curTapPos;
            }
            delta =  curTapPos.x - lastTapPos.x;
            lastTapPos = curTapPos;
            transform.Rotate(Vector3.up * -1 * delta);
        } else if (Input.GetMouseButtonUp(0)) {
            lastTapPos = Vector2.zero;
        }
    }
}
