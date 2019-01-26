using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements keyboard commands to allow testing features. 
/// </summary>
public class TestController : MonoBehaviour
{


    public Torch torch;
    // Update is called once per frame
    void Update()
    {
        //toggles torchlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            torch.setLit(!torch.lit); 
        }
    }
}
