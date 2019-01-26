using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class Torch : MonoBehaviour
{
    public float maxDuration; 
    public float litTimeRemaining;
    public bool lit; 

    public UnityEvent onLit; 


    [SerializeField]
    ParticleSystem fireParticleSystem;
    [SerializeField]
    Light torchLight;

    public void setLit(bool _lit = true)
    {
        if(_lit)
        {
            litTimeRemaining = maxDuration;
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
        if(lit)
        {
            if (litTimeRemaining > 0) litTimeRemaining -= Time.deltaTime; 
            else setLit(false);  
        }
    }
}
