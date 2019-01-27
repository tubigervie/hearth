using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskDuder : MonoBehaviour
{
    public static ObeliskDuder singleton;
    SessionManager Sesh;
    public float timer;
    public float maxTime = 180f;
    public float woodTime = 30f;
    bool lit;
    public Torch torch;

    public bool firstWoodEntered;

    public GameObject[] gemArray;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Sesh = SessionManager.singleton;
        for (int i = 0; i < Sesh.gemCount; ++i)
        {
            gemArray[i].SetActive(true);
        }
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        countDown();
    }
    void FixedUpdate()
    {

    }

    void countDown()
    {
        float d = Time.deltaTime;
        if (timer <= 0)
        {
            Sesh.darknessCountdown(d);

        }
        else
        {
            Sesh.darknessTimer = 5;
            timer -= d;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer > 0 && torch.lit != true && firstWoodEntered)
        {
            torch.setLit(!torch.lit);
        }
        else if(torch.lit != true && !firstWoodEntered && Sesh.woodCount > 0)
        {
            torch.setLit(!torch.lit);
        }
        else if (timer > 0 && torch.lit == true && torch.litTimeRemaining < torch.maxDuration)
        {
            torch.litTimeRemaining += torch.timeGainedOnFuelAddition == 0 ? torch.maxDuration - torch.litTimeRemaining : torch.timeGainedOnFuelAddition;
        }
        float woodAmount = SessionManager.singleton.woodCount;
        Debug.Log("trigger entered");
        if (woodAmount != 0)
        {
            Debug.Log(timer);
            timer += woodAmount * woodTime;
            Debug.Log(timer);
            firstWoodEntered = true;
            timer = Mathf.Clamp(timer, 0, 180);
        }
        SessionManager.singleton.woodCount = 0;
    }

    public void DisplayCurrentGems()
    {
        for (int i = 0; i < Sesh.gemCount; ++i)
        {
            gemArray[i].SetActive(true);
        }
    }



}
