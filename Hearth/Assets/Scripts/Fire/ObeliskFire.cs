using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Torch))]
public class ObeliskFire : MonoBehaviour
{
    public float minLightRange, maxLightRange, minParticleRate, maxParticleRate;

    Torch torch; 
    //todo connect ratio to obelisk time

    [Range(0, 1)]
    public float strengthPercentage; 

    void Start()
    {
        torch = GetComponent<Torch>(); 
    }

    // Update is called once per frame
    void Update()
    {
        torch.torchLight.range = minLightRange + (maxLightRange - minLightRange) * strengthPercentage;
        var emission = torch.fireParticleSystem.emission;
        emission.rateOverTime = minParticleRate + (maxParticleRate - minParticleRate) * strengthPercentage;  
    }
}
