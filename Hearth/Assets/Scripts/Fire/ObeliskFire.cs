using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskFire : MonoBehaviour
{
    public float minLightRange, maxLightRange, minParticleRate, maxParticleRate;

    public ParticleSystem fireParticleSystem;
    public Light torchLight;

    public ObeliskDuder obeliskStats;
    //todo connect ratio to obelisk time

    [Range(0, 1)]
    public float strengthPercentage; 


    // Update is called once per frame
    void Update()
    {
        strengthPercentage = obeliskStats.timer / obeliskStats.maxTime; 

        if(strengthPercentage < 0)
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
