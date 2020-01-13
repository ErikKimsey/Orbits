using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDeviceType : MonoBehaviour
{
    //This is the Text for the Label at the top of the screen
    private static string m_DeviceType;

    private void Start() {

        //Check if the device running this is a console
        if (SystemInfo.deviceType == DeviceType.Console)
        {
            //Change the text of the label
            m_DeviceType = "Console";
        }

        //Check if the device running this is a desktop
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            m_DeviceType = "Desktop";
        }

        //Check if the device running this is a handheld
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            m_DeviceType = "Handheld";
        }

        //Check if the device running this is unknown
        if (SystemInfo.deviceType == DeviceType.Unknown)
        {
            m_DeviceType = "Unknown";
        }
    }

    public string GetDeviceType(){
      return m_DeviceType;
    }
}
