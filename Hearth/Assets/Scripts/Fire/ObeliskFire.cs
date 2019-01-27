using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskFire : MonoBehaviour
{
    public float minLightRange, maxLightRange, minParticleRate, maxParticleRate;

    public ParticleSystem fireParticleSystem;
    public Light torchLight;

    public bool isOn;
    public ObeliskDuder obeliskStats;
    //todo connect ratio to obelisk time

    [Range(0, 1)]
    public float strengthPercentage;

    public void Start()
    {
        SpawnFireplaceSound();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            strengthPercentage = ObeliskDuder.timer / ObeliskDuder.maxTime;

            if (strengthPercentage < 0)
            {
                torchLight.enabled = false;
                fireParticleSystem.Stop();
            }
            else
            {
                torchLight.enabled = true;
                fireParticleSystem.Play();
            }

            torchLight.range = minLightRange + (maxLightRange - minLightRange) * strengthPercentage;
            var emission = fireParticleSystem.emission;
            emission.rateOverTime = minParticleRate + (maxParticleRate - minParticleRate) * strengthPercentage;
        }
    }

    private void SpawnFireplaceSound()
    {
        GameObject obj = GameObject.Instantiate(AudioManager.Get().fireplaceEmitterPrefab, this.transform);
        // Line up fireplace sound emitter to camera along y-plane.
        Debug.Log(new Vector3(this.transform.position.x, 15.0f, this.transform.position.z));
        obj.transform.position = new Vector3(this.transform.position.x, 15.0f, this.transform.position.z);
    }
}
