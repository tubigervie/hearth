using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SessionManager.singleton.woodCount = 0;
    }
}
    