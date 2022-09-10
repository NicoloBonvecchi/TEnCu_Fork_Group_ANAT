using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerPCAndMouse : Utility.CameraManager._3D.CameraManager
{
    int counter = 0;
    protected override void ManageInput()
    {
        if(Input.GetMouseButton(0))
        {
            print("You are zoomming in by: " +counter);
            Zoom(1);
        }
        else
            Zoom(-1);
    }
}
