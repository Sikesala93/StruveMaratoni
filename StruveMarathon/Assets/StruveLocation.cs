using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class Paikkatieto{
    public float latitude;
    public float longitude;
    public float laiteld = 27;
}

public class StruveLocation : MonoBehaviour
{
    Text m_paikkatietostatus;
    Text m_latitude;
    Text m_longitude;
    public double locationX;
    public double locationZ;
    GameObject dialog = null;

    // Start is called before the first frame update
    void Start()
    {
        #if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            dialog = new GameObject();
        }
        #endif

        StartCoroutine("PaikkatietoHandler");

        m_paikkatietostatus = GameObject.Find("PaikkatietoStatus").GetComponent<Text>();
        m_latitude = GameObject.Find("Latitude").GetComponent<Text>();
        m_longitude = GameObject.Find("Longitude").GetComponent<Text>();

        

    }

    IEnumerator PaikkatietoHandler()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Paikkatietohandler käynnistetty:" + Input.location.status);
        m_paikkatietostatus.text = "" + Input.location.status;
    
        if(Input.location.isEnabledByUser == false)
        {
            m_paikkatietostatus.text = "Location ei aktivoidu" + Input.location.status;
            yield break;
        }

        Input.location.Start();

        bool statusSuccess = false;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.5f);
            if(Input.location.status != LocationServiceStatus.Initializing)
            {
                i = 20;
                statusSuccess = true;
            }
        }
        if (statusSuccess == false)
        {
            m_paikkatietostatus.text = "TimeOut, ei saatu yhteyttä ajoissa";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            m_paikkatietostatus.text = "Access denied to device";
        }
        else
        {
            m_paikkatietostatus.text = "Paikkatieto saatu: " + Input.location.lastData.timestamp;
            m_latitude.text = "Latitude saatu: " + Input.location.lastData.latitude;
            m_longitude.text = "Longitude saatu: " + Input.location.lastData.longitude;
            locationX = Input.location.lastData.latitude;
            locationZ = Input.location.lastData.longitude;

            Paikkatieto paikkaserverille = new Paikkatieto();
            paikkaserverille.latitude = Input.location.lastData.latitude;
            paikkaserverille.longitude = Input.location.lastData.longitude;

            string jsonviesti = JsonUtility.ToJson(paikkaserverille);
            Debug.Log(""+jsonviesti);
          
            using (UnityWebRequest www = 
            UnityWebRequest.Put("http://54.174.218.143/struve2021/tallennagpsdata.php", jsonviesti))
        {
            www.SetRequestHeader("Accept","Application/json");
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            
            dialog.AddComponent<LokaatioPaasyOikeusKysely>();
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
#endif

      
    }
}

