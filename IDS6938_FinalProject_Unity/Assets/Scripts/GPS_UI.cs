using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS_UI : MonoBehaviour
{

    public Text latitude;
    public Text longitude;
    public GameObject compass;

    private float damping = 10;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        latitude.text = GetLat();
        longitude.text = GetLon();
        compass.transform.rotation = Quaternion.Lerp(compass.transform.rotation, GPS.Instance.heading, Time.deltaTime * damping);
        
    }

    public string GetLat()
    {
        return "Lat: " + GPS.Instance.latitude.ToString();
    }

    public string GetLon()
    {
        return "Lon: " + GPS.Instance.longitude.ToString();
    }
}
