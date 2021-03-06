﻿using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Collections;

public class Arduino : MonoBehaviour
{


    public bool controllerActive = false;
    public int commPort = 3;
    public GameObject player = null;

    private SerialPort serial = null;
    private bool connected = true;

    private bool configured = false;    

    // Use this for initialization
    void Start()
    {
        ConnectToSerial();
    }

    void ConnectToSerial()
    {
        Debug.Log("Attempting Serial: " + commPort);

        // Read this: https://support.microsoft.com/en-us/help/115831/howto-specify-serial-ports-larger-than-com9
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        FireBullet fb = player.GetComponent<FireBullet>();


        if (controllerActive)
            {
                WriteToArduino("Z");                // Ask for the rotation
                String value = ReadFromArduino(50); // read the positions

                if (value != null)                  // check that there is an input
                {                    
                    string[] values = value.Split(',');     // split the values so unity can read them indipendently.

                    if (values.Length == 2)
                    {
                        try
                        {                            
                            pc.updateMovement(float.Parse(values[0])); //movement value
                            if (int.Parse(values[1]) == 0)             //shot value (1/0)
                        {
                            fb.controllerFire();
                        }

                        }
                        catch (FormatException error)
                        {
                            Debug.Log("Start Up");
                        }
                    }
                }
            
        }
            
        
    }

 

    void WriteToArduino(string message)
    {
        serial.WriteLine(message);
        serial.BaseStream.Flush();
    }

    public string ReadFromArduino(int timeout = 0)
    {
        serial.ReadTimeout = timeout;
        try
        {
            return serial.ReadLine();
        }
        catch (TimeoutException e)
        {
            return null;
        }
    }

    //  closes the serial 
    void OnDestroy()
    {
        Debug.Log("Exiting");
        serial.Close();
    }

    // https://forum.unity.com/threads/re-map-a-number-from-one-range-to-another.119437/
    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
