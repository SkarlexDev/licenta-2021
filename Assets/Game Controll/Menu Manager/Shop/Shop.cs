using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
	[Header("LockSys")]
	public int IndexLock; //same as index shop item list
	[SerializeField] LockNextIndex[] LockSystem;
	public static int counterindex;
	[Header("Shop")]
	#region Singlton:Shop

	public static Shop Instance;

	void Awake()
	{
		counterindex = IndexLock-1;
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}
	#endregion
	[System.Serializable]
	public class ShopItem
	{
		public Sprite Image;
		public int Price;
		public bool IsPurchased = false;
	}
	public List<ShopItem> ShopItemsList;

	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] Transform[] ShopScrollView;

	Button buyBtn;

	

	void Start()
	{
#if UNITY_STANDALONE_WIN
		ItemTemplate = ShopScrollView[0].GetChild(0).gameObject;
#else
		ItemTemplate = ShopScrollView[1].GetChild(0).gameObject;
#endif
		int len = ShopItemsList.Count;

		for (int i = 0; i < len; i++)
		{
#if UNITY_STANDALONE_WIN
			g = Instantiate(ItemTemplate, ShopScrollView[0]);
#else
			g = Instantiate(ItemTemplate, ShopScrollView[1]);
#endif
			g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
			g.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = ShopItemsList[i].Price.ToString();
			buyBtn = g.transform.GetChild(2).GetComponent<Button>();
#pragma warning disable 0649
			ShopItemsList[i].IsPurchased = DataManager.instance.data.IsPurchased[i];
#pragma warning restore 0649
			if (ShopItemsList[i].IsPurchased)
			{
				buyBtn.interactable = !ShopItemsList[i].IsPurchased;
			}

			buyBtn.AddEventListener(i, OnShopItemBynClicked);

		}
		Destroy(ItemTemplate);
	}

	void OnShopItemBynClicked(int itemIndex)
	{
		if (GM.Instance.HaveEnoughCoins(ShopItemsList[itemIndex].Price))
		{
			GM.Instance.UseCoins(ShopItemsList[itemIndex].Price);
			//buy item
			ShopItemsList[itemIndex].IsPurchased = true;
			//disable button
#if UNITY_STANDALONE_WIN
			ShopScrollView[0].GetChild(itemIndex).GetChild(2).GetComponent<Button>().interactable = false;
#else
			ShopScrollView[1].GetChild(itemIndex).GetChild(2).GetComponent<Button>().interactable = false;
#endif
			//add avatar
			Profile.Instance.AddAvatar(ShopItemsList[itemIndex].Image);
			Invoke("CheckForIndexUpdate", .5f);
		}
		else
		{
			Debug.Log("Need More Coins");
		}
	}


	public void CheckForIndexUpdate()
	{
#if UNITY_STANDALONE_WIN
		LockSystem[0].IndexCheck();
		Debug.Log("Called lock 0");
#else
		LockSystem[1].IndexCheck();
#endif

	}
}
