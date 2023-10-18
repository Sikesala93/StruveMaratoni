using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//point luokka laskentaa varten
public class Point
{
    public double X;
    public double Y;
}
public class Paikannin : MonoBehaviour
{
    public Vector3 m_alkutilanne;
    public Vector3 m_laskentatulos;
    

    private const int TileSize = 256;
    private const int EarthRadius = 6378137;
    private const double InitialResolution = 2 * Math.PI * EarthRadius / TileSize;
    private const double OriginShift = 2 * Math.PI * EarthRadius / 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Point lopputulos = LatLonToMeters(m_alkutilanne.x, m_alkutilanne.z);
            m_laskentatulos = new Vector3( (float)(lopputulos.X/1000), 2, (float)(lopputulos.Y/1000));//new Vector3((float)2872.048,0, (float)10009.58);
            gameObject.transform.position = m_laskentatulos;//66.5081 25.72913
        }
        
        Point lopputulospuhelin = LatLonToMeters(gameObject.GetComponent<StruveLocation>().locationX, gameObject.GetComponent<StruveLocation>().locationZ);
        m_laskentatulos = new Vector3((float)(lopputulospuhelin.X / 1000), 0, (float)(lopputulospuhelin.Y / 1000));
        gameObject.transform.position = m_laskentatulos;
        
    }

    //Converts given lat/lon in WGS84 Datum to XY in Spherical Mercator EPSG:900913
    public static Point LatLonToMeters(double lat, double lon)
    {
        var p = new Point();
        p.X = lon * OriginShift / 180;
        p.Y = Math.Log(Math.Tan((90 + lat) * Math.PI / 360)) / (Math.PI / 180);
        p.Y = p.Y * OriginShift / 180;
        return p;
    }
}
