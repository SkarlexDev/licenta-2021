using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DM = DataManager;

public class SoundSettings : MonoBehaviour
{
	public AudioSource audioSource;
	public DataLoader DL;
	void Start()
	{
		GM.Mute=DM.instance.data.Mute;
		GM.NightMode = DM.instance.data.NightMode;
		audioSource = GetComponent<AudioSource>();
		Check();
	}
	void Check()
	{
		if (GM.Mute)
		{
			audioSource.Stop();
		}
		else
		{
			audioSource.Play();
		}
	}
	public void MuteUnmute()
	{
		if (!GM.Mute)
		{
			GM.Mute = true;
			audioSource.Stop();
		}
		else
		{
			GM.Mute = false;
			audioSource.Play();
		}
		DL.SaveStats(); //save Mute status
	}
}
