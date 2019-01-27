using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniObeliskDuders : MonoBehaviour
{
    // Start is called before the first frame update
	public ObeliskDuder obelisk;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider other)
    {
		if (obelisk.timer > 0 && obelisk.torch.lit != true)
		{
			obelisk.torch.setLit(!obelisk.torch.lit);
		}
		else if ( obelisk.timer > 0 && obelisk.torch.lit == true && obelisk.torch.litTimeRemaining < obelisk.torch.maxDuration)
		{
			obelisk.torch.litTimeRemaining += obelisk.torch.timeGainedOnFuelAddition  == 0 ? obelisk.torch.maxDuration - obelisk.torch.litTimeRemaining : obelisk.torch.timeGainedOnFuelAddition;
		}
        float woodAmount = obelisk.Sesh.woodCount;
        if(woodAmount != 0)
        {
            //Debug.Log(timer);
            obelisk.timer += woodAmount * obelisk.woodTime;
            //Debug.Log(timer);
            obelisk.timer = Mathf.Clamp(obelisk.timer, 0, obelisk.maxTime); 
        }
        obelisk.Sesh.woodCount = 0;
        
    }
}
