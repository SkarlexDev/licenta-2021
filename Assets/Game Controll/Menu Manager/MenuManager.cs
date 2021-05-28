using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	[Header("Menu")]
	public MenuAnimationController MAC;
	[Header("Light")]
	public GameObject[] Light;

	public AudioChange ACC;
	public LightManager LM;
	public DataLoader DL;
	public void PlayGame()
	{
		if (gameObject.name == "PlayButton")
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}

			Light[0].SetActive(false);
			if (!GM.NightMode)
			{
				Light[1].SetActive(true);
				Light[2].SetActive(false);
			}
			else
			{
				Light[1].SetActive(false);
				Light[2].SetActive(true);
			}
			GM.Instance.StartGameB();
			MAC.PButton();
			MAC.MMenuC();
			MAC.CStats();
		}
	}

	public void NightmodeState()
	{
		if (GM.NightMode)
		{
			GM.NightMode = false;

		}
		else
		{
			GM.NightMode = true;

		}
		LM.ChangeLight();

		DL.SaveStats();
	}
	
	public void PauseButton()
	{
		if (gameObject.name == "PauseButton")
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
			}
		}
		MAC.PMenuC();
		MAC.PButton();
	}
	public void ResumeButton()
	{
		if (gameObject.name == "ResumeButton")
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
			MAC.PMenuC();
			MAC.PButton();
		}
	}


	public void ProfileOpen()
	{
		if (gameObject.name == "Profile")
		{
			MAC.ProfileOpen();
		}
	}
	public void ProfileClose()
	{
		if (gameObject.name == "QuitProfile")
		{
			MAC.ProfileClose();
		}
	}

	public void ShopOpen()
	{
		if (gameObject.name == "Shop")
		{
			MAC.ShopOpen();
		}
	}
	public void QPOS() // quit profile open shop
	{
		if (gameObject.name == "QPOS")
		{
			MAC.ShopOpen();
			MAC.ProfileClose();
		}
	}
	public void ShopClose()
	{
		if (gameObject.name == "QuitShop")
		{
			MAC.ShopClose();
		}
	}
	public void QSOP()// quit shop open profile
	{
		if (gameObject.name == "QSOP")
		{
			MAC.ProfileOpen();
			MAC.ShopClose();
		}
	}

	public void SettingsOpen()
	{
		if (gameObject.name == "Settings")
		{
			MAC.SettingsOpen();
		}
	}

	public void SettingsClose()
	{
		if (gameObject.name == "QuitSettings")
		{
			MAC.SettingsClose();
		}
	}



	public void RestartGameOpt()
	{
		if (gameObject.name == "RestartButton")
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
			SceneManager.LoadScene("Game");
			GM.Alive = false;
			GM.isRunning = false;
			GM.coinTotal = 0;
			GM.CScore = 0;
		}
	}
}
