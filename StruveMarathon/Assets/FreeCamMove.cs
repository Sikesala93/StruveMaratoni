using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamMove : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector2 startPos;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.touchCount <= 1)
        {

            Touch touch = Input.GetTouch(0);

            startPos = touch.position;
            direction = touch.position - startPos;
            transform.position += new Vector3(-direction.x* speed * Time.deltaTime, 0 , -direction.y* speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed* 20,
                                           0.0f, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed* 20);
        }
        
    }
}
