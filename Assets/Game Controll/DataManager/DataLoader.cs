using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DM = DataManager;

public class DataLoader : MonoBehaviour
{

	public void SaveStats()
	{
		float GTC = GM.coinTotal + DM.instance.data.TotalCoins; //Game Total Coins
		float GBS = GM.CScore; //game best score
		bool CMS = GM.Mute; // current mute sound

		int len = Shop.Instance.ShopItemsList.Count;

		if (GBS > DM.instance.data.BestScore)
		{
			for (int i = 0; i < len; i++)
			{
				bool IPD = Shop.Instance.ShopItemsList[i].IsPurchased; //Item PurchaseD
				int ALP = Profile.Instance.LastPickedAvatar; // avatar last pick 
				bool GNM = GM.NightMode; // gamemode night
				DM.instance.data.SetData(GTC, GBS, CMS, IPD, i, ALP, GNM);
			}
		}
		else
		{
			for (int i = 0; i < len; i++)
			{
			
				bool IPD = Shop.Instance.ShopItemsList[i].IsPurchased;//Item PurchaseD
				GBS = DM.instance.data.BestScore; 
				int ALP = Profile.Instance.LastPickedAvatar; // avatar last pick 
				bool GNM = GM.NightMode; // gamemode night
				DM.instance.data.SetData(GTC, GBS, CMS, IPD, i, ALP, GNM);
			}
		}
		DM.instance.Save();
	}
}
