using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StruveMenu : MonoBehaviour
{
    private float Y_Max = 1000;
    private float Y_Min = -1000;
    public GameObject KarttaUI, MainMenu;
    public FreeCam freecam;
    public GameObject kamera;
    public Camera overheadCam;
    private float speed = 250f;
    public Vector2 startPos;
    public Vector2 direction;
    public Button Rova, Saksa, Stuorra, Oravi ,Map, Play;


    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        Rova.onClick.AddListener(StruveCam);
        Saksa.onClick.AddListener(StruveCam);
        Stuorra.onClick.AddListener(StruveCam);
        Oravi.onClick.AddListener(StruveCam);
        Map.onClick.AddListener(MapOn);
        Play.onClick.AddListener(Menu);
    }

    // Update is called once per frame
    void Update()
    {
        if (KarttaUI.activeInHierarchy == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                KarttaUI.transform.Translate(0, -scroll * speed, 0);
                if (KarttaUI.transform.localPosition.y > Y_Max)
                {
                    KarttaUI.transform.localPosition = new Vector3(0, Y_Max, 0);
                }
                if (KarttaUI.transform.localPosition.y < Y_Min)
                {
                    KarttaUI.transform.localPosition = new Vector3(0, Y_Min, 0);
                }

            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {

                float scroll = Input.GetAxis("Mouse ScrollWheel");
                KarttaUI.transform.Translate(0, -scroll * speed, 0);
                if (KarttaUI.transform.localPosition.y > Y_Max)
                {
                    KarttaUI.transform.localPosition = new Vector3(0, Y_Max, 0);
                }
                if (KarttaUI.transform.localPosition.y < Y_Min)
                {
                    KarttaUI.transform.localPosition = new Vector3(0, Y_Min, 0);
                }

            }

            /*
            if (Input.touchCount > 0 && Input.touchCount <= 1)
            {

                Touch touch = Input.GetTouch(0);

                startPos = touch.position;
                direction = touch.position - startPos;
                KarttaUI.transform.Translate(new Vector3(0, -direction.y * speed, 0));
                if (KarttaUI.transform.localPosition.y > Y_Max)
                {
                    KarttaUI.transform.localPosition = new Vector3(0, Y_Max, 0);
                }
                if (KarttaUI.transform.localPosition.y < Y_Min)
                {
                    KarttaUI.transform.localPosition = new Vector3(0, Y_Min, 0);
                }
            }*/
        }
    }

    void StruveCam()
    {
        Vector3 kartta;
        KarttaUI.SetActive(false);
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "RovaButton":
                Debug.Log("rovaniemi");
                kartta = new Vector3(2864.143f, 4, 10012.02f);
                break;
            case "SaksaButton":
                Debug.Log("saksa");
                kartta = new Vector3(2641.448f, 4, 9984.87f);
                break;
            case "StuorraButton":
                Debug.Log("stuorra");
                kartta = new Vector3(2531.172f, 4, 10651.06f);
                break;
            case "OraviButton":
                Debug.Log("Oravi");
                kartta = new Vector3(2839.663f, 4, 8842.016f);
                break;
            default:
                Debug.Log("Default");
                kartta = gameObject.GetComponent<StruveLocation>().transform.position;
                kartta.y = 4;
                break;
        }
        kamera.transform.position = kartta;
        if (overheadCam.enabled == false)
        {
            freecam.FreeCamOn();
        }
        
    }

    void MapOn()
    {
        switch (KarttaUI.activeInHierarchy)
        {
            case true:
                Debug.Log("Map was on");
                KarttaUI.SetActive(false);
                break;
            case false:
                Debug.Log("Map was off");
                KarttaUI.SetActive(true);
                break;
        }
    }

    void Menu()
    {
        MainMenu.SetActive(false);
    }
}