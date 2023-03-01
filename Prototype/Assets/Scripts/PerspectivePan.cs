using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePan : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
       if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -145.0f, 30.0f),
                Mathf.Clamp(transform.position.y, 45.0f, 57.0f),
                Mathf.Clamp(transform.position.z, -130.0f, -50.0f));


        }
    }
    
}