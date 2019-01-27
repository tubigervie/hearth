using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskDuder : MonoBehaviour
{
	SessionManager Sesh;
	public float timer;
	public float maxTime = 180f;
	
    // Start is called before the first frame update
    void Start()
    {
        Sesh = SessionManager.singleton;
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
}
