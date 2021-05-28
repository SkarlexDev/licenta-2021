using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightParrent : MonoBehaviour
{
	public GameObject NightLight;
	public GameObject player;
	public Camera cam;

	void Awake()
	{
		//cam = GetComponent<Camera>();
	}
	void Update()
	{
		if (!GM.isRunning)
		{
			if (player == null)
				player = GameObject.FindGameObjectWithTag("Player");
		}
		else
		{
			if (player == null)
				player = GameObject.FindGameObjectWithTag("Player");
			if (NightLight)
			{
				cam.clearFlags = CameraClearFlags.SolidColor;
				NightLight.transform.parent = player.transform;
			}
		}
	}
}
