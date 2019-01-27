using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class Torch : MonoBehaviour
{
    public float maxDuration; 
    public float litTimeRemaining;

    public float minParticleRate, maxParticleRate;
    /// <summary>
    /// If 0, litTimeRemaining is set to MaxDuration
    /// </summary>
    public float timeGainedOnFuelAddition = 0f; 

    public bool lit; 

    public UnityEvent onLit; 


    [Header("Set Up")]
    public ParticleSystem fireParticleSystem;
    public Light torchLight;

    Animator animator;
    

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }
    public void setLit(bool _lit = true)
    {
        if(_lit)
        {
            litTimeRemaining += timeGainedOnFuelAddition  == 0 ? maxDuration - litTimeRemaining : timeGainedOnFuelAddition;
            torchLight.enabled = true;
            fireParticleSystem.Play();
        }
        else
        {
            litTimeRemaining = 0;
            torchLight.enabled = false;
            fireParticleSystem.Stop();
        }
        lit = _lit;
        onLit.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        litTimeRemaining = Mathf.Clamp(litTimeRemaining, -5, maxDuration); 
        if(lit)
        {
            if (litTimeRemaining > 0) litTimeRemaining -= Time.deltaTime; 
            else setLit(false);

            //animator.SetBool("QuarterTimeLeft", litTimeRemaining < maxDuration / 4);
            //animator.SetBool("Lit", lit); 
        }

        var emission = fireParticleSystem.emission;
        emission.rateOverTime = minParticleRate + (maxParticleRate - minParticleRate) * (litTimeRemaining / maxDuration);
    }   
}
