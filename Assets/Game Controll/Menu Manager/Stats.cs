using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DM = DataManager;

public class Stats : MonoBehaviour
{
	//private PlayerMotor motor;

	void Update()
	{
		//motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
		if (GM.Alive && GM.isRunning)
		{
			if (gameObject.name == "Coinstxt")
			{
				float CTC = GM.coinTotal; // current total coins
				if (CTC > 1000000)
				{
					GetComponent<TextMeshProUGUI>().SetText(" " + (CTC / 1000000).ToString("#,##0.###") + "M");
				}
				else
				{
					GetComponent<TextMeshProUGUI>().SetText(" " + CTC.ToString("#,##0.###"));
				}
			}
			if (gameObject.name == "ScoreText")
			{
				float CTS = GM.CScore; // current total score
				if (CTS > 1000000)
				{
					GetComponent<TextMeshProUGUI>().SetText(" " + (Mathf.Round(CTS) / 1000000).ToString("#,##0.###") + "M");
				}
				else
				{
					GetComponent<TextMeshProUGUI>().SetText(" " + Mathf.Round(CTS).ToString("#,##0.###"));
				}
			}
			//display


			if (gameObject.name == "ScoreTextDisp")
			{
				float CTS = GM.CScore; // current total score
				if (CTS > 1000000)
				{
					GetComponent<TextMeshProUGUI>().SetText("Current : " + (Mathf.Round(CTS) / 1000000).ToString("#,##0.###") + "M");
				}
				else
				{
					GetComponent<TextMeshProUGUI>().SetText("Current : " + Mathf.Round(CTS).ToString("#,##0.###"));
				}
			}
			if (gameObject.name == "CoinstxtDisp")
			{
				float CTC = GM.coinTotal; // current total coins
				if (CTC > 1000000)
				{
					GetComponent<TextMeshProUGUI>().SetText("Earned : " + (CTC / 1000000).ToString("#,##0.###") + "M");
				}
				else
				{
					GetComponent<TextMeshProUGUI>().SetText("Earned : " + CTC.ToString("#,##0.###"));
				}
			}
		}

		// total ammount account
		if (gameObject.name == "TotalCoins")
		{
			float GTC = DM.instance.data.TotalCoins; // game total coins
			if (GTC > 1000000)
			{
				GetComponent<TextMeshProUGUI>().SetText(" " + (GTC / 1000000).ToString("#,##0.###") + "M");
			}
			else
			{
				GetComponent<TextMeshProUGUI>().SetText(" " + GTC.ToString("#,##0.###"));
			}
		}
		if (gameObject.name == "BestScore")
		{
			float GBS = DM.instance.data.BestScore; // game best score
			if (GBS > 1000000)
			{
				GetComponent<TextMeshProUGUI>().SetText(" " + (Mathf.Round(GBS) / 1000000).ToString("#,##0.###") + "M");
			}
			else
			{
				GetComponent<TextMeshProUGUI>().SetText(" " + Mathf.Round(GBS).ToString("#,##0.###"));
			}
		}
		// Total display
		if (gameObject.name == "BestScoreRun")
		{
			float GBS = DM.instance.data.BestScore;
			if (GBS > 1000000)
			{
				GetComponent<TextMeshProUGUI>().SetText("Best : " + (Mathf.Round(GBS) / 1000000).ToString("#,##0.###") + "M");
			}
			else
			{
				GetComponent<TextMeshProUGUI>().SetText("Best : " + Mathf.Round(GBS).ToString("#,##0.###"));
			}
		}

	}
}
