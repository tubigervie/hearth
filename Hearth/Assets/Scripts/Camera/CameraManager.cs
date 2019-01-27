using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager singleton;
    public Transform target;
    public float smoothDampTime; 

    public bool followPlayer = false; 

    float defaultY = 15;
    Vector3 previousTransform;
    private void Awake()
    {
        singleton = this;
    }

    public void Init(PlayerControl player)
    {
        target = player.transform;
        
    }

    Vector3 cameraVel; 
    public void Tick()
    {
        if(followPlayer)
        {
            Vector3 newPos = target.position;
            newPos.y = defaultY;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref cameraVel, smoothDampTime); 
        }
    }
}
