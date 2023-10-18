using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



public class HaeEsp32Data : MonoBehaviour
{

    Text m_esp32datastatus;
    Text m_latitude;
    Text m_longitude;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GethaeEsp32data");
        m_esp32datastatus = GameObject.Find("Esp32dataStatus").GetComponent<Text>();
        m_latitude = GameObject.Find("Latitude").GetComponent<Text>();
        m_longitude = GameObject.Find("Longitude").GetComponent<Text>();
    }

     IEnumerator GethaeEsp32data() {
        using (UnityWebRequest www = UnityWebRequest.Get("http://54.227.13.167/struve2021/haeEsp32datat.php")) {
            yield return new WaitForSeconds(1f);
            Debug.Log("GethaeEsp32data käynnistetty:"+Input.location.status);
            m_esp32datastatus.text = ""+Input.location.status;

            if(www.isNetworkError|| www.isHttpError) {
                Debug.Log("Network error");
            }
            else {
                Debug.Log(www.downloadHandler.text);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
