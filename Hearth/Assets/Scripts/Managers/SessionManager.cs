using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionManager : MonoBehaviour
{
    public static SessionManager singleton;

    public List<ObeliskDuder> obelisks = new List<ObeliskDuder>();
    public ObeliskDuder mainObelisk;

    [Header("In Inventory")]
    public int woodCount = 0;
    public int gemCount = 0;
    float minDistance = 5;

    [Header("Timers")]
    public float darknessTimer = 5;
    public float torchTimer = 30;

    [SerializeField] Image blackScreen;
    Vector3 startPosition;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.canvasRenderer.SetAlpha(0);
        startPosition = PlayerControl.singleton.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForObelisks()
    {
        bool r = false;
        Vector3 playerPos = PlayerControl.singleton.transform.position;
        for (int i = 0; i < obelisks.Count; ++i)
        {
            if(Vector3.Distance(playerPos, obelisks[i].transform.position) <= obelisks[i].obFire.torchLight.range * .3f && ObeliskDuder.timer > 0)
            {
                r = true;
            }
        }

        if(r)
        {
            Debug.Log("close");
            darknessTimer = 5;
        }
        else
        {
            Debug.Log("far");
            darknessCountdown(Time.deltaTime);
        }
    }

    public void AddItem(string id)
    {
        Item i = null;
        i = ResourceManager.singleton.GetResourceItem(id);
        if(i != null)
        switch(i.itemType)
        {
            case ItemType.wood:
                woodCount += i.value;
                break;
            case ItemType.crystal:
                gemCount += i.value;
                   gemCount = Mathf.Clamp(gemCount, 0, 4);
                for (int x = 0; x < gemCount; ++x)
                {
                    mainObelisk.gemArray[x].SetActive(true);
                }
                if(gemCount == 4)
                {
                    EndSequence.singleton.EndGame();
                }
                break;
        }
    }
	
	public void darknessCountdown(float time)
	{

        darknessTimer -= time;
        if (darknessTimer <= 0)
        {
            PlayerControl.singleton.dead = true;
            blackScreen.CrossFadeAlpha(1, 1, false);
            Invoke("Respawn", 3);
        }
    }

    void Respawn()
    {
        PlayerControl.singleton.transform.position = startPosition;
        blackScreen.CrossFadeAlpha(0, 1, false);
        PlayerControl.singleton.dead = false;
        darknessTimer = 5;
        ObeliskDuder.timer = ObeliskDuder.maxTime;

    }

    
}
