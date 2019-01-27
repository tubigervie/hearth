using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

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
    public GameObject terribleWeatherPrefab;

    private GameObject terribleWeatherInstance;

    private float currentThreatPct = 0.0f;

    public void Start()
    {
        if (windAmbiencePrefab != null)
        {
            GameObject.Instantiate(windAmbiencePrefab, this.transform);
        }

        if (terribleWeatherPrefab != null)
        {
            terribleWeatherInstance =
                GameObject.Instantiate(terribleWeatherPrefab, this.transform);
        }
    }

    public void Update()
    {
        float targetThreatPct = SessionManager.singleton.darknessTimer < 4.9f
            ? 1.0f
            : 0.0f;
        if (currentThreatPct < targetThreatPct)
        {
            currentThreatPct = 
                Mathf.MoveTowards(currentThreatPct, targetThreatPct, Time.deltaTime);
        }
        else if (currentThreatPct > targetThreatPct)
        {
            // Decay faster.
            currentThreatPct =
                Mathf.MoveTowards(currentThreatPct, targetThreatPct, 0.5f * Time.deltaTime);
        }
        SetTerribleWeatherIntensity(currentThreatPct);
    }

    private void SetTerribleWeatherIntensity(float value)
    {
        if (terribleWeatherInstance != null)
        {
            StudioEventEmitter emitter = terribleWeatherInstance.GetComponent<StudioEventEmitter>();
            emitter.SetParameter("threat", value);
        }
    }
}
