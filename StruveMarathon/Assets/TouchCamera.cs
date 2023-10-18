using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject KarttaUI;
    public Vector2 startPos;
    public Vector2 direction;
    private Vector3 maxDist = new Vector3(0, 9.464f, -74.09f);
    private Vector3 minDist = new Vector3(0, 1.9f, -14.4f);
    float touchDist = 0;
    float lastDist = 0;
    public float speed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KarttaUI.activeInHierarchy == false)
        {
            // Track a single touch as a direction control.
            if (Input.touchCount > 1)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
                {
                    lastDist = Vector2.Distance(touch1.position, touch2.position);
                }

                if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
                {
                    float newDist = Vector2.Distance(touch1.position, touch2.position);
                    touchDist = lastDist - newDist;
                    lastDist = newDist;

                    touchDist *= 0.1f;
                    // Your Code Here
                    Camera.main.transform.localPosition += new Vector3(0, touchDist * 0.01f, -touchDist * 0.1f);
                    /*if (Camera.main.transform.localPosition.y < minDist.y)
                    {
                        Camera.main.transform.localPosition = minDist;
                    }
                    else if (Camera.main.transform.localPosition.y > maxDist.y)
                    {
                        Camera.main.transform.localPosition = maxDist;
                    }*/
                }
            }



            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                Camera.main.transform.Translate(0, 0, scroll * speed, Space.Self);


            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {

                float scroll = Input.GetAxis("Mouse ScrollWheel");
                Camera.main.transform.Translate(0, 0, scroll * speed, Space.Self);
            }

            if (Input.touchCount > 0 && Input.touchCount <= 1)
            {

                Touch touch = Input.GetTouch(0);

                startPos = touch.position;
                direction = touch.position - startPos;
                player.transform.Rotate(new Vector3(0, -direction.x * speed, 0));
            }




            if (Input.GetMouseButton(0))
            {
                player.transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X") * speed, 0));
            }
            if (Input.GetKey("w"))
            {
                player.transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                player.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                player.transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                player.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
            }
        }
    }
}
