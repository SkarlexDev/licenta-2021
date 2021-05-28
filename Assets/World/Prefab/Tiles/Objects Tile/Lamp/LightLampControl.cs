using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightLampControl : MonoBehaviour
{
	public GameObject NGL;
	public bool Checked;
	
	private void Start()
	{
		Checked = GM.NightMode;
		CheckForUpdate();
	}

	public void Update()
	{
		if (Checked != GM.NightMode)
		{
			CheckForUpdate();
			Checked = GM.NightMode;
		}
	}
	public void CheckForUpdate()
	{
		if (GM.NightMode)
		{
			if (!NGL.activeSelf)
				NGL.SetActive(true);
		}
		else
		{
			if (NGL.activeSelf)
				NGL.SetActive(false);

		}
	}
}
