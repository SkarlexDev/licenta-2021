using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDataFix : MonoBehaviour
{

	public void ResetDAtaFixing()
	{
		DataManager.instance.Delete();
	}
}
