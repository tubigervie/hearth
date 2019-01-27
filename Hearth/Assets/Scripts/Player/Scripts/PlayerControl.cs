using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl singleton;
	public float speed = 5;
	public float maxSpeed;
	
	private Rigidbody rigidBody;
    CameraManager cameraManager;
    public bool dead;

    private void Awake()
    {
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cameraManager = CameraManager.singleton;
        cameraManager.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
		if (cameraManager.followPlayer == false)
		{
			Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
			pos.x = Mathf.Clamp01(pos.x);
			pos.y = Mathf.Clamp01(pos.y);
			transform.position = Camera.main.ViewportToWorldPoint(pos);
		}
    }
	
	void FixedUpdate()
	{
        if(!dead)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rigidBody.MovePosition(transform.position + movement * speed * Time.deltaTime);
        }
        /*
		if (rigidBody.velocity.magnitude <= maxSpeed)
		{
			rigidBody.AddForce(movement * speed);
		}
		else if (rigidBody.velocity.magnitude > maxSpeed)
		{
			rigidBody.velocity = (rigidBody.velocity.normalized * maxSpeed);
		}
		*/
        cameraManager.Tick();
	}
}
