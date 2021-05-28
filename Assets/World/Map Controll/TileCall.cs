using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCall : MonoBehaviour
{
	public Generator altGM;
	void Start()
	{
		altGM = GameObject.Find("GM").GetComponent<Generator>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
				altGM.Generate();
			/*for (int i = 0; i <= 6; i++)
			{
				altGM.Generate();
			}*/
		}
	}
}
