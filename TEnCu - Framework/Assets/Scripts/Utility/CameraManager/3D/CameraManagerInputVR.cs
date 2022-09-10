using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerInputVR : Utility.CameraManager._3D.CameraManager
{
    int counter = 0;
    protected override void ManageInput()
    {
        /*
         * 
         * The way the checks are written is a series of if.
         * They will print a simple message to effectively see what button on the
         * VR controller gets pressed and gets detected by that specific method
         * 
         * As follows:
         * 
         * if(Input.checkButtonXControllerForVR(0))
         * print("The input i received came from: button X of the controller\n");
         * 
         * Should there be present more numeric values associated with
         * a specific check method they can be tested with a switch that works
         * in the same way:
         *
         * switch(Input.checkButtonControllerForVR(0....9))
         * {
         *   case 1:
         *    print....
         *    .
         *    .
         *    .
         *   case 9:
         *    print...
         * }
         * 
         * 
        */
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
