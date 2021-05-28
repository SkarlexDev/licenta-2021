using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Profile : MonoBehaviour
{
	#region Singlton:Profile

	public static Profile Instance;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	#endregion

	public class Avatar
	{
		public Sprite Image;
	}

	public List<Avatar> AvatarsList;

	public bool CanSave;
	[SerializeField] GameObject[] AvatarUITemplate;
	[SerializeField] Transform[] AvatarsScrollView;
	public SpawnCharacterPicked SCP;
	GameObject g;
	public int newSelectedIndex, previousSelectedIndex;

	//[SerializeField] Color ActiveAvatarColor;
	//[SerializeField] Color DefaultAvatarColor;

	[SerializeField] Image[] CurrentAvatar;
	[SerializeField] public int LastPickedAvatar;

	void Start()
	{
		LastPickedAvatar = DataManager.instance.data.LastPickedCharacter;
		GetAvailableAvatars();
		newSelectedIndex = previousSelectedIndex = 0;
	}

	void GetAvailableAvatars()
	{
		for (int i = 0; i < Shop.Instance.ShopItemsList.Count; i++)
		{
			if (Shop.Instance.ShopItemsList[i].IsPurchased)
			{
				//add all purchased avatars to AvatarsList
				AddAvatar(Shop.Instance.ShopItemsList[i].Image);

			}
		}

		SelectAvatar(newSelectedIndex);

	}

	public void AddAvatar(Sprite img)
	{
		if (AvatarsList == null)
			AvatarsList = new List<Avatar>();

		Avatar av = new Avatar() { Image = img };
		//add av to AvatarsList
		AvatarsList.Add(av);

		//add avatar in the UI scroll view
#if UNITY_STANDALONE_WIN
		g = Instantiate(AvatarUITemplate[0], AvatarsScrollView[0]);
#else
		g = Instantiate(AvatarUITemplate[1], AvatarsScrollView[1]);
#endif
		g.transform.GetChild(0).GetComponent<Image>().sprite = av.Image;

		//add click event
		g.transform.GetComponent<Button>().AddEventListener(AvatarsList.Count - 1, OnAvatarClick);
	}

	void OnAvatarClick(int AvatarIndex)
	{
		SelectAvatar(AvatarIndex);
	}

	public void SelectAvatar(int AvatarIndex)
	{
		previousSelectedIndex = newSelectedIndex;
		newSelectedIndex = AvatarIndex;
		//AvatarsScrollView.GetChild(previousSelectedIndex).GetComponent<Image>().color = DefaultAvatarColor;
		//AvatarsScrollView.GetChild(newSelectedIndex).GetComponent<Image>().color = ActiveAvatarColor;

		//Change Avatar
#if UNITY_STANDALONE_WIN
		CurrentAvatar[0].sprite = AvatarsList[newSelectedIndex].Image;
#else
		CurrentAvatar[1].sprite = AvatarsList[newSelectedIndex].Image;
#endif

		LastPickedAvatar = newSelectedIndex;
		if (CanSave)
		{
			Invoke("DataSaveFix", .1f);
		}
		else
		{ CanSave = true; }

	}

	void DataSaveFix()
	{
		SCP.ChangeCharCall();
		GM.Instance.CallSave();
	}
	

}