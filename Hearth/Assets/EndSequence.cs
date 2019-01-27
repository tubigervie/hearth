using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSequence : MonoBehaviour
{
    public static EndSequence singleton;
    public float fadeOutTime;
    Transform currentCameraTransform;
    public Image whiteScreen;
    public ObeliskDuder od;
    Vector3 cameraVel;
    public bool startEndCameraPan;
    public float smoothDampTime = 1;

    public void EndGame()
    {
        Camera.main.GetComponentInParent<CameraManager>().followPlayer = false;
        startEndCameraPan = true;
        currentCameraTransform = Camera.main.transform;
        //titleBanner.CrossFadeAlpha(0, fadeOutTime, false);
    }

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        Debug.Log("WTFFFF");
        whiteScreen.canvasRenderer.SetAlpha(0);
    }

    private void Update()
    {
        if(startEndCameraPan)
        {
            Vector3 newPos = od.transform.position;
            newPos.y = 15;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newPos, Time.deltaTime * 1f);
            if(Vector3.Distance(Camera.main.transform.position, newPos) <= 1f)
            {
                SessionManager.singleton.PlayGem(5);
                startEndCameraPan = false;
                StartCoroutine("ReloadGame");
            }
        }
    }

    IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(1.5f);
        PlayFadeOutSound();
        whiteScreen.CrossFadeAlpha(1, fadeOutTime, false);
        yield return new WaitForSeconds(7);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void PlayFadeOutSound()
    {
        AudioManager audioMgr = AudioManager.Get();
        GameObject soundInstance = GameObject.Instantiate(audioMgr.fadeOutPrefab, audioMgr.transform);
        GameObject.Destroy(soundInstance, 10.0f);
    }
}
