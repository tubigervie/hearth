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

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        startingCameraTransform = Camera.main.transform; 
    }
    private void Update()
    {
        Camera.main.transform.position = startingCameraTransform.position;

        if (od.firstWoodEntered && canvasGroup.alpha == 1)
        {
            startGame();
        }
    }
    CanvasGroup canvasGroup;




    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeOutTime;
            yield return null;
        }
    }

    public void startGame()
    {
        StartCoroutine("FadeOut");
        Camera.main.GetComponentInParent<CameraManager>().followPlayer = true;
        Destroy(gameObject, fadeOutTime);
    }
}

