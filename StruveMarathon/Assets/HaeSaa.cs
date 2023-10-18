using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HaeSaa : MonoBehaviour
{

    Text m_lampotila;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Gethaesaadata");
        m_lampotila = GameObject.Find("Lampotila").GetComponent<Text>();
    }

    IEnumerator Gethaesaadata() {
        using (UnityWebRequest www = UnityWebRequest.Get("http://54.227.13.167/struve2021/haesaadata.php")) {
            yield return new WaitForSeconds(1f);
            Debug.Log("Gethaesaadata käynnistetty");

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

