using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationController : MonoBehaviour
{
	public GameObject[] PauseMenuP;
	public GameObject[] MainMenu;
	public GameObject[] GameOverM;
	public GameObject[] PauseButton;
	public GameObject[] CurrentStats;
	public GameObject[] TopPanel;
	public GameObject[] Profile;
	public GameObject[] Shop;
	public GameObject[] Settings;

	public void PMenuC()
	{
#if UNITY_STANDALONE_WIN
		
		Animator anim = PauseMenuP[0].GetComponent<Animator>();
#else
		Animator anim = PauseMenuP[1].GetComponent<Animator>();
#endif
		bool open = anim.GetBool("PMenu");
		anim.SetBool("PMenu", !open);
	}
	public void MMenuC()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = MainMenu[0].GetComponent<Animator>();
		Animator anim2 = TopPanel[0].GetComponent<Animator>();
#else
		Animator anim = MainMenu[1].GetComponent<Animator>();
		Animator anim2 = TopPanel[1].GetComponent<Animator>();
#endif
		bool open = anim.GetBool("MMenu");
		bool open2 = anim2.GetBool("MMenu");
		anim.SetBool("MMenu", !open);
		anim2.SetBool("MMenu", !open2);
	}
	public void GameOver()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = GameOverM[0].GetComponent<Animator>();
#else
		Animator anim = GameOverM[1].GetComponent<Animator>();
#endif
		bool open = anim.GetBool("GameOver");
		anim.SetBool("GameOver", !open);
	}

	public void PButton()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = PauseButton[0].GetComponent<Animator>();
#else
		Animator anim = PauseButton[1].GetComponent<Animator>();
#endif
		bool open = anim.GetBool("Show");
		anim.SetBool("Show", !open);
	}
	public void CStats()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = CurrentStats[0].GetComponent<Animator>();
#else
		Animator anim = CurrentStats[1].GetComponent<Animator>();
#endif
		bool open = anim.GetBool("Show");
		anim.SetBool("Show", !open);
	}


	public void ProfileOpen()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = Profile[0].GetComponent<Animator>();
#else
		Animator anim = Profile[1].GetComponent<Animator>();
#endif
		
		anim.SetBool("Profile", true);
	}
	public void ProfileClose()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = Profile[0].GetComponent<Animator>();
#else
		Animator anim = Profile[1].GetComponent<Animator>();
#endif

		anim.SetBool("Profile", false);
	}


	public void ShopOpen()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = Shop[0].GetComponent<Animator>();
#else
		Animator anim = Shop[1].GetComponent<Animator>();
#endif

		anim.SetBool("Shop", true);
	}
	public void ShopClose()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = Shop[0].GetComponent<Animator>();
#else
		Animator anim = Shop[1].GetComponent<Animator>();
#endif

		anim.SetBool("Shop", false);
	}

	public void SettingsOpen()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = Settings[0].GetComponent<Animator>();
#else
		Animator anim = Settings[1].GetComponent<Animator>();
#endif

		anim.SetBool("Settings", true);
	}
	public void SettingsClose()
	{
#if UNITY_STANDALONE_WIN
		Animator anim = Settings[0].GetComponent<Animator>();
#else
		Animator anim = Settings[1].GetComponent<Animator>();
#endif

		anim.SetBool("Settings", false);
	}

}
