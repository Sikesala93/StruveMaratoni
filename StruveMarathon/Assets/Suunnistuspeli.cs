using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Suunnistuspeli : MonoBehaviour
{
    public Button dig;
    public Text points_text;
    public GameObject digger;
    private bool playerOnZone = false;
    private int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        dig.onClick.AddListener(DigForPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DigForPoints()
    {
        Debug.Log("Dug for points");
        if(playerOnZone == true)
        {
            points++;
            points_text.text = "Points: " + points;
            MoveZone();
        }
    }

    void MoveZone()
    {
        transform.position = new Vector3(Random.Range(2851.515f, 2876.95f), -0.376f, Random.Range(10004.36f, 10019.86f));
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.gameObject == digger)
        {
            Debug.Log("Digger is on zone");
            playerOnZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == digger)
        {
            Debug.Log("Digger left zone");
            playerOnZone = false;
        }
    }
}
