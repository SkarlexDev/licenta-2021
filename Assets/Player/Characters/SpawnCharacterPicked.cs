using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterPicked : MonoBehaviour
{
	public GameObject[] playerPrefab;
	public GameObject CurrentCharacter;


	// Start is called before the first frame update
	void Awake()
	{
		GM.HP = 1;
		GM.Alive = true;
	}
	/*
	void Start()
	{
		Invoke("SpawnCharacterStart", .1f);
	}

	void SpawnCharacterStart()
	{
		GameObject playerInstance = Instantiate(playerPrefab[DataManager.instance.data.LastPickedCharacter]);
		playerInstance.transform.position = new Vector3(0, 0.73f, 0);
		Debug.Log(DataManager.instance.data.LastPickedCharacter);
		CurrentCharacter = GameObject.FindGameObjectWithTag("Player");
	}*/

	public void ChangeCharCall()
	{
		CurrentCharacter = GameObject.FindGameObjectWithTag("Player");
		Destroy(CurrentCharacter);
		Invoke("ChangeSpawnedCharacter", .1f);
	}
	void ChangeSpawnedCharacter()
	{
		GameObject playerInstance = Instantiate(playerPrefab[Profile.Instance.newSelectedIndex]);
		playerInstance.transform.position = new Vector3(0, 0.73f, 0);
	}
}
