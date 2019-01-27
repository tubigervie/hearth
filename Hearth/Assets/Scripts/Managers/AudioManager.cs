using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Get()
    {
        return GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public GameObject fireplaceEmitterPrefab;
    public GameObject windAmbiencePrefab;
    public GameObject feedFlamePrefab;
    public GameObject pickUpWoodPrefab;
    public GameObject gemAPrefab;
    public GameObject gemBPrefab;
    public GameObject gemCPrefab;
    public GameObject gemDPrefab;
    public GameObject gemSequencePrefab;

    public void Start()
    {
        if (windAmbiencePrefab != null)
        {
            GameObject.Instantiate(windAmbiencePrefab, this.transform);
        }
    }
}
