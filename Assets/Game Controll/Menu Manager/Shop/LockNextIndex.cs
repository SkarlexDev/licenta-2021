using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockNextIndex : MonoBehaviour
{
	public int counter;
	public Transform[] LockScreen = new Transform[20];
	public bool[] Verificator = new bool[20];



	private void Start()
	{
		counter = Shop.counterindex;
		Invoke("IndexCheck", 1.5f);
	}
	public void IndexCheck()
	{
		for (int i = 0; i <= counter; i++)
		{
			LockScreen[i] = this.gameObject.transform.GetChild(i).GetChild(3);
			Verificator[i] = DataManager.instance.data.IsPurchased[i];
		}
		for (int i = 0; i <= counter-1; i++)
		{
			if (Verificator[i])
			{
				LockScreen[i + 1].gameObject.SetActive(false);
			}
		}
		LockScreen[0].gameObject.SetActive(false);
		//Debug.Log("Loaded lock");
		LockScreen = new Transform[20];
		Verificator = new bool[20];
	}
}
