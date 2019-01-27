using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniObeliskDuders : ObeliskDuder
{
    // Start is called before the first frame update
	public ObeliskDuder obelisk;
    public BoxCollider obCollider;

    void Start()
    {
        SessionManager.singleton.obelisks.Add(this);
        torch = obelisk.torch;
        obCollider = GetComponent<BoxCollider>();
        obCollider.isTrigger = false;

        obFire.torchLight.enabled = false;
        obFire.fireParticleSystem.Stop();
        obFire.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ObeliskDuder.timer > 0 && obelisk.torch.lit != true)
        {
            obelisk.torch.setLit(!obelisk.torch.lit);
        }
        else if (ObeliskDuder.timer > 0 && obelisk.torch.lit == true && obelisk.torch.litTimeRemaining < obelisk.torch.maxDuration)
        {
            obelisk.torch.litTimeRemaining += obelisk.torch.timeGainedOnFuelAddition == 0 ? obelisk.torch.maxDuration - obelisk.torch.litTimeRemaining : obelisk.torch.timeGainedOnFuelAddition;
        }
        float woodAmount = SessionManager.singleton.woodCount;
        if (woodAmount != 0)
        {
            //Debug.Log(timer);
            ObeliskDuder.timer += woodAmount * obelisk.woodTime;
            //Debug.Log(timer);
            ObeliskDuder.timer = Mathf.Clamp(ObeliskDuder.timer, 0, ObeliskDuder.maxTime);

            PlayLightTorchSound();
        }
        SessionManager.singleton.woodCount = 0;

    }
    
    private void PlayLightTorchSound()
    {
        AudioManager audioMgr = AudioManager.Get();
        GameObject soundInstance = GameObject.Instantiate(audioMgr.feedFlameLightPrefab, audioMgr.transform);
        GameObject.Destroy(soundInstance, 10.0f);
    }
}
