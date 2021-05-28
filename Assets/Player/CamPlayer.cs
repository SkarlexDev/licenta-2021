using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayer : MonoBehaviour
{
	public Transform lookat;
	public Vector3 offset; // 5 -2
	public Vector3 Moffset;
	public Vector3 rotation = new Vector3(15, 0, 0);

	private void Start()
	{
		//transform.position = lookat.position + offset;
	}
	private void LateUpdate()
	{
		if (GM.Alive)
		{
			
			if (!GM.isRunning)
				return;
			if (lookat == null)
				lookat = GameObject.FindGameObjectWithTag("Player").transform;
#if UNITY_STANDALONE_WIN
			UpdateStandalone();
#else
        UpdateMobile();
#endif

		}
	}
	void UpdateStandalone()
	{
		Vector3 desiredPosition = lookat.position + offset;
		desiredPosition.x = 0;
		//desiredPosition.y = 3.1f;
		transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5);
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), 0.1f);
	}
	void UpdateMobile()
	{
		Vector3 desiredPosition = lookat.position + Moffset;
		desiredPosition.x = 0;
		//desiredPosition.y = 3.1f;
		transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5);
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), 0.1f);
	}

}
