using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FreeCam : MonoBehaviour
{
    public Camera rovaniemiCam;
    public Camera playerCam;
    public Button toggler;
    // Start is called before the first frame update
    void Start()
    {
        toggler.onClick.AddListener(FreeCamOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FreeCamOn()
    {
        Debug.Log("FreeCamOn");
        /*if(EventSystem.current.currentSelectedGameObject.name == "FreeCamToggle")
        {
            rovaniemiCam.transform.position = new Vector3(gameObject.transform.position.x, 4, gameObject.transform.position.z);
        }*/

        switch (rovaniemiCam.enabled)
        {
            case true:
                Debug.Log("Cam was on");
                rovaniemiCam.enabled = false;
                playerCam.enabled = true;
                break;
            case false:
                Debug.Log("Cam was off");
                playerCam.enabled = false;
                rovaniemiCam.enabled = true;
                break;
        }

        

            

    }
}
