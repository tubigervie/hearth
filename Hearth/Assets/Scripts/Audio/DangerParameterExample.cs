using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/// <summary>
/// Expected to be attached on the game object with the event emitter which has
/// the "threat" parameter.
/// </summary>
public class DangerParameterExample : MonoBehaviour
{
    private StudioEventEmitter emitter;

    public float threat;

    public void OnEnable()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    public void Update()
    {
        emitter.SetParameter("threat", threat);
    }
}
