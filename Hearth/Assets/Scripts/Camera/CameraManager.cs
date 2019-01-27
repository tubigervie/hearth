using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager singleton;
    public Transform target;
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

    public void Tick()
    {
        Vector3 newPos = target.position;
        newPos.y = defaultY;
        transform.position = newPos;
    }
}
