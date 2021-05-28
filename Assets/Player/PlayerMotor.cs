using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
	private const float Lane_Distance = 2.0f;
	private float jumpForce = 4f;
	private float gravity = -9.0f;
	private float speed = 7f;
	private int desiredLane = 1;
	public float currentSpeed;
	Vector3 moveVector;

	private CharacterController controller;
	public Animator anim;

	private void Awake()
	{
		Vector3 moveVector = Vector3.zero;
	}
	private void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}
	public void Update()
	{
		if (!GM.isRunning)
			return;
		AliveCheck();
		InputsManager();
		//move to
		Vector3 targetPosition = transform.position.z * Vector3.forward;
		if (desiredLane == 0)
			targetPosition += Vector3.left * Lane_Distance;
		else if (desiredLane == 2)
			targetPosition += Vector3.right * Lane_Distance;

		//movement delta

		moveVector.x = (targetPosition - transform.position).normalized.x * 17f; //14
		//fall
		if (moveVector.y > -10f)
		{
			moveVector.y += gravity * Time.deltaTime * 2;
			//Debug.Log(moveVector.y);

		}
		//speed
		currentSpeed = speed + GM.speed;
		moveVector.z = currentSpeed;

		//move character
		controller.Move(moveVector * Time.deltaTime);

	}
	void InputsManager()
	{
		//inputs

		//pc keyboard
		if (Input.GetButtonDown("Left"))
		{
			MoveLane(false);
		}
		if (Input.GetButtonDown("Right"))
		{
			MoveLane(true);
		}

		//pc mouse + mobile

		if (MobileInput.Instance.SwipeLeft)
			MoveLane(false);
		if (MobileInput.Instance.SwipeRight)
			MoveLane(true);


		//jump

		// pc controlls
		if (IsGrounded())
		{
			anim.SetBool("Grounded", true);
			if (Input.GetKeyDown(KeyCode.Space)|| Input.GetButtonDown("Up")) 
			{
				anim.SetTrigger("Jump");
				moveVector.y = Mathf.Sqrt(jumpForce * -gravity * 2);
			}
		}
		else
		{
			anim.SetBool("Grounded", false);
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Up") || Input.GetButtonDown("Down"))
			{
				moveVector.y = -Mathf.Sqrt(jumpForce * -gravity * 2);
			}
		}


		// mobile
		if (IsGrounded())
		{
			anim.SetBool("Grounded", true);
			if (MobileInput.Instance.SwipeUp)
			{
				anim.SetTrigger("Jump");
				moveVector.y = Mathf.Sqrt(jumpForce * -gravity * 2);
			}
		}
		else
		{
			anim.SetBool("Grounded", false);
			if (MobileInput.Instance.SwipeDown)
			{
				moveVector.y = -Mathf.Sqrt(jumpForce * -gravity * 2);
			}
		}



	}

	private void MoveLane(bool goingRight)
	{
		desiredLane += (goingRight) ? 1 : -1;
		desiredLane = Mathf.Clamp(desiredLane, 0, 2);
	}


	public void AliveCheck()
	{
		if (GM.HP < 0.9f)
		{
			GM.Alive = false;
			GM.isRunning = false;
			//Destroy(gameObject);
		}
	}

	public void StartRunning()
	{
		GM.isRunning = true;
		anim.SetBool("GameStart", true);
	}


	private bool IsGrounded()
	{
		Ray groundRay = new Ray(
			new Vector3(
				controller.bounds.center.x,
				(controller.bounds.center.y - controller.bounds.extents.y) + .2f,
				controller.bounds.center.z),
			Vector3.down);
		Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 2f);
		return Physics.Raycast(groundRay, 0.2f + 0.1f);

	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "FrontalFallT")
		{
			anim.Play("FrontalFall");
		}
		if (other.gameObject.tag == "BackFallT")
		{
			anim.Play("BackFall");
		}
		
	}


}
