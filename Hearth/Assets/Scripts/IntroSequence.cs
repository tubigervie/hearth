using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class IntroSequence : MonoBehaviour
{
    public float fadeOutTime; 
    Transform startingCameraTransform;
    public Image titleBanner;
    public ObeliskDuder od;  

    
    private void Start()
    {
        startingCameraTransform = Camera.main.transform; 
    }
    private void Update()
    {
        Camera.main.transform.position = startingCameraTransform.position;

        if (od.firstWoodEntered)
            startGame(); 
    }

    public void startGame()
    {
        titleBanner.CrossFadeAlpha(0, fadeOutTime, false);
        Camera.main.GetComponentInParent<CameraManager>().followPlayer = true;
        Destroy(gameObject, fadeOutTime);
    }
}

