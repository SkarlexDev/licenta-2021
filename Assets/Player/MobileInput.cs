using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
	public static MobileInput Instance { set; get; }

	[Header("Tweaks")]
	[SerializeField] private float deadzone = 100.0f;

	[Header("Logic")]
	private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private Vector2 swipeDelta, startTouch;
	private float lastTap;
	private float sqrDeadzone;

	#region Public properties
	public bool Tap { get { return tap; } }

	public Vector2 SwipeDelta { get { return swipeDelta; } }
	public bool SwipeLeft { get { return swipeLeft; } }
	public bool SwipeRight { get { return swipeRight; } }
	public bool SwipeUp { get { return swipeUp; } }
	public bool SwipeDown { get { return swipeDown; } }
	#endregion
	private void Awake()
	{

		Instance = this;
	}
	private void Start()
	{

		sqrDeadzone = 150f;
		// sqrDeadzone = deadzone * deadzone;
	}

	private void Update()
	{
		// Reset our bools
		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

#if UNITY_STANDALONE_WIN
		UpdateStandalone();
#else
        UpdateMobile();
#endif
	}
	//pc
	private void UpdateStandalone()
	{
		if (Input.GetMouseButtonDown(0))
		{
			tap = true;
			startTouch = Input.mousePosition;
			lastTap = Time.time;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			startTouch = swipeDelta = Vector2.zero;
		}

		// Reset distance, get the new swipeDelta
		swipeDelta = Vector2.zero;

		if (startTouch != Vector2.zero && Input.GetMouseButton(0))
			swipeDelta = (Vector2)Input.mousePosition - startTouch;

		//Checking if our delta is beyond deadzone
		if (swipeDelta.sqrMagnitude > sqrDeadzone)
		{

			float x = swipeDelta.x;
			float y = swipeDelta.y;
			if (Mathf.Abs(x) > Mathf.Abs(y))
			{
				//Left or right
				if (x < 0)
					swipeLeft = true;
				else
					swipeRight = true;
			}
			else
			{
				//Up or down
				if (y < 0)
					swipeDown = true;
				else
					swipeUp = true;
			}
			startTouch = swipeDelta = Vector2.zero;
		}
	}
	private void UpdateMobile()
	{
		if (Input.touches.Length != 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				tap = true;
				startTouch = Input.mousePosition;

				lastTap = Time.time;
			}
			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				startTouch = swipeDelta = Vector2.zero;
			}
		}

		// Reset distance, calculate new one
		swipeDelta = Vector2.zero;

		if (startTouch != Vector2.zero && Input.touches.Length != 0)
			swipeDelta = Input.touches[0].position - startTouch;


		if (swipeDelta.sqrMagnitude > sqrDeadzone) //direction from 0
		{
			float x = swipeDelta.x;
			float y = swipeDelta.y;
			if (Mathf.Abs(x) > Mathf.Abs(y))
			{
				//Left or right
				if (x < 0)
					swipeLeft = true;
				else
					swipeRight = true;
			}
			else
			{
				//Up or down
				if (y < 0)
					swipeDown = true;
				else
					swipeUp = true;
			}
			startTouch = swipeDelta = Vector2.zero;
		}
	}
}
