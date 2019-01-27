using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements keyboard commands to allow testing features. 
/// </summary>
public class TestController : MonoBehaviour
{


    public Torch torch;
    public ObeliskFire obeliskFire;  
    // Update is called once per frame
    void Update()
    {
        //toggles torchlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            torch.setLit(!torch.lit); 
        }

        //simulates adding firewood to the obelisk
        if (Input.GetKeyDown(KeyCode.O))
        {
            //obeliskFire.torch.setLit(true);
        }
    }
}
