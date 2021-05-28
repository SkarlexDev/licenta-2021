using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
	public GameObject[] Light;
	public AudioChange AC;
	public Button[] button; // 0 pc 1 mobile

	void Start()
	{
		Invoke("ChangeLight", .1f);
	}
	public void ChangeLight()
	{
		if (!GM.NightMode)
		{
			Light[0].SetActive(true);
			Light[1].SetActive(false);
			Light[2].SetActive(false);
			Light[3].SetActive(false);
			Light[4].SetActive(true);
			AC.DaySound();
		}
		else
		{
			Light[0].SetActive(false);
			Light[1].SetActive(false);
			Light[2].SetActive(false);
			Light[3].SetActive(true);
			Light[4].SetActive(false);
			AC.NightSound();
		}
		ChangeButtonnColor();
	}

	public void ChangeButtonnColor()
	{
#if UNITY_STANDALONE_WIN
		int i = 0;
#else
		int i = 1;
#endif
		if (GM.NightMode)
		{
			ColorBlock colors = button[i].colors;
			colors.normalColor = Color.white;
			button[i].colors = colors;
		}
		else
		{
			ColorBlock colors = button[i].colors;
			colors.normalColor = Color.black;
			button[i].colors = colors;
		}
	}
}
