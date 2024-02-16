using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    private float minX, maxX;
    void Start()
    {
        speedModifier = 0.01f;
        minX = -0.65f; maxX = 3.4f;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float newX = Mathf.Clamp(transform.position.x - touch.deltaPosition.x * speedModifier, minX, maxX);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            }
        }
    }
}
