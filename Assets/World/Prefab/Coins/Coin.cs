using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinsound;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
        {
            GM.coinTotal += 100;
            GM.CScore += 5;
            AudioSource.PlayClipAtPoint(coinsound, new Vector3(0,transform.position.y,transform.position.z));
            Destroy(gameObject);
        }
    }
     
}
