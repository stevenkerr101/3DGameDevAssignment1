using UnityEngine;
using System.Collections;
using TMPro;
/* ----------------------------------------
* class to demonstrate how to control a 
* character using Character Controller and the Mecanim system
*/
public class BasicController: MonoBehaviour {
	// Variable for the character's Animator component
	private Animator anim;

	// Variable for the character's Character Controller component
	private CharacterController controller;

	public GameObject player;
	
	// float variable for dampening speed values
	public float transitionTime = .25f;
	
	// float variable for speed limit
	private float speedLimit = 1.0f;

	
	//float variable for the vertical speed of the character
	private float verticalSpeed = 0f;
	
	// float variable for character's velocity on X-axis
	private float xVelocity = 0f;
	
	// float variable for character's velocity on X-axis
	private float zVelocity = 0f;

	public GameObject AK;
	public GameObject Rocket;

	public GameObject FiringPointAK;
	public GameObject FiringPointSMAW;

	public GameObject AKbullet;
	public GameObject SMAWbullet;

	public float Bullet_Forward_Force;

	public Camera firstPersonCam;
	public Camera thirdPersonCam;
	public Camera rightCam;
	public Camera leftCam;

	public AudioSource footsteps;

	
	void Start () {
		controller = GetComponent<CharacterController>();
		
		anim = GetComponent<Animator>();

		

		firstPersonCam.enabled = true;
		thirdPersonCam.enabled = false;
		rightCam.enabled = false;
		leftCam.enabled = false;

		AK.SetActive(false);
		Rocket.SetActive(false);
	}
	
	/* ----------------------------------------
	 * Whenever Directional controls are used, update variables from the Animator
	 */
	void Update () {
		
		// IF Character Controller is grounded...
		if (controller.isGrounded) {


			if (Input.GetKey(KeyCode.F))
			{
				firstPersonCam.enabled = true;
				thirdPersonCam.enabled = false;
				rightCam.enabled = false;
				leftCam.enabled = false;
			}

			if (Input.GetKey(KeyCode.G))
			{
				firstPersonCam.enabled = false;
				thirdPersonCam.enabled = true;
				rightCam.enabled = false;
				leftCam.enabled = false;
			}

			if (Input.GetKey(KeyCode.H))
			{
				firstPersonCam.enabled = false;
				thirdPersonCam.enabled = false;
				rightCam.enabled = true;
				leftCam.enabled = false;
			}

			if (Input.GetKey(KeyCode.J))
			{
				firstPersonCam.enabled = false;
				thirdPersonCam.enabled = false;
				rightCam.enabled = false;
				leftCam.enabled = true;
			}

			if (Input.GetButtonDown("Fire1"))
			{
				if(AK.activeSelf == true)
                {
					GameObject Temporary_Bullet_Handler;
					Temporary_Bullet_Handler = Instantiate(AKbullet, FiringPointAK.transform.position, FiringPointAK.transform.rotation) as GameObject;

					Temporary_Bullet_Handler.transform.Rotate(Vector3.left * -90);

					Rigidbody Temporary_RigidBody;
					Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

					Temporary_RigidBody.AddForce(FiringPointAK.transform.forward * Bullet_Forward_Force);

					Destroy(Temporary_Bullet_Handler, 10.0f);
				} else if (Rocket.activeSelf == true)
                {
					GameObject Temporary_Bullet_Handler;
					Temporary_Bullet_Handler = Instantiate(SMAWbullet, FiringPointSMAW.transform.position, FiringPointSMAW.transform.rotation) as GameObject;

					Rigidbody Temporary_RigidBody;
					Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

					Temporary_RigidBody.AddForce(FiringPointSMAW.transform.forward * Bullet_Forward_Force);
					
					Destroy(Temporary_Bullet_Handler, 10f);
				}
				
			}

			if (Input.GetKey (KeyCode.Q)) {
				
				anim.SetBool ("TurnLeft", true);
				
				transform.Rotate (Vector3.up * (Time.deltaTime * -90.0f), Space.World);
				
			} else {
				
				anim.SetBool ("TurnLeft", false);	
			}
			
			if (Input.GetKey (KeyCode.E)) {
				
				anim.SetBool ("TurnRight", true);
				
				transform.Rotate (Vector3.up * (Time.deltaTime * 90.0f), Space.World);
				
			} else {
				anim.SetBool ("TurnRight", false);	
			}
			
			
			if (Input.GetKey (KeyCode.RightShift) || Input.GetKey (KeyCode.LeftShift))
				speedLimit = 0.5f;
			else 
				speedLimit = 1.0f;	


			float h = Input.GetAxis ("Horizontal");
			
			float v = Input.GetAxis ("Vertical");
			
			float xSpeed = h * speedLimit;	
			
			float zSpeed = v * speedLimit;	
			
			float speed = Mathf.Sqrt (h * h + v * v);

		
			if (v != 0 )
				xSpeed = 0;
			
			if (v != 0)
				this.transform.Rotate (Vector3.up * h, Space.World);

			anim.SetFloat ("zSpeed", zSpeed, transitionTime, Time.deltaTime);
			
			anim.SetFloat ("xSpeed", xSpeed, transitionTime, Time.deltaTime);
			
			anim.SetFloat ("Speed", speed, transitionTime, Time.deltaTime);

			if (speed > 0 && footsteps.isPlaying == false)
			{
				footsteps.Play();
			}

			else 
			{
				footsteps.Pause();
			}
		}
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickupAK")
        {
			//other.gameObject.SetActive(false);
			AK.SetActive(true);
			Rocket.SetActive(false);
        }
		else if (other.tag == "PickupSMAW")
		{
			//other.gameObject.SetActive(false);
			Rocket.SetActive(true);
			AK.SetActive(false);
		}
	}


    void OnAnimatorMove(){
		Vector3 deltaPosition = anim.deltaPosition;
		
		if (controller.isGrounded) {
			xVelocity = controller.velocity.x;

			zVelocity = controller.velocity.z;
		} else { 
			deltaPosition.x = xVelocity * Time.deltaTime;

			deltaPosition.z = zVelocity * Time.deltaTime;	

		}

		deltaPosition.y = verticalSpeed * Time.deltaTime;

		controller.Move (deltaPosition);
		verticalSpeed += Physics.gravity.y * Time.deltaTime;	

		if ((controller.collisionFlags & CollisionFlags.Below) != 0) {
			verticalSpeed = 0;	
		}

		
	}

}
