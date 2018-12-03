using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    public float latitude = 0;
    public float longitude = 0;
    public Quaternion heading;
    // Use this for initialization
    //void Start()
    //{
    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //    //StartCoroutine(StartLocationService());
    //}

    //private IEnumerator StartLocationService()
    //{
    //    print("hello");
    //    if (Input.location.isEnabledByUser)
    //    {
    //        Debug.Log("User has not enabled GPS");
    //        yield break;
    //    }

    //    Input.location.Start();
    //    int maxWait = 20;
    //    while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
    //    {
    //        yield return new WaitForSeconds(1);
    //        maxWait--;
    //    }

    //    if(maxWait <= 0)
    //    {
    //        Debug.Log("Timed out");
    //        yield break;
    //    }

    //    if(Input.location.status == LocationServiceStatus.Failed)
    //    {
    //        Debug.Log("Unable to determine location");
    //        yield break;
    //    }

    //    latitude = Input.location.lastData.latitude;
    //    longitude = Input.location.lastData.longitude;
    //}

    // Update is called once per frame
    void Update()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        heading = Quaternion.Euler(0, 0, -Input.compass.trueHeading);
        
    }

    IEnumerator Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        print("here");
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.compass.enabled = true;
        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            //latitude = Input.location.lastData.latitude;
            //longitude = Input.location.lastData.longitude;
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
    }
}
