using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float speed;
	public float maxSpeed;
	
	private Rigidbody rigidBody;
	
	
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		if (rigidBody.velocity.magnitude <= maxSpeed)
		{
			rigidBody.AddForce(movement * speed);
		}
		else if (rigidBody.velocity.magnitude > maxSpeed)
		{
			rigidBody.velocity = (rigidBody.velocity.normalized * maxSpeed);
		}
	}
}
