using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Selector : MonoBehaviour
{
	void Start()
	{
		Invoke("CharacterLoaded", .5f);
	}
	void CharacterLoaded()
	{

		Profile.Instance.SelectAvatar(DataManager.instance.data.LastPickedCharacter);

	}
}
