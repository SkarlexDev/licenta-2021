using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
	public static DataManager instance;
	public Data data;
	string dataFile = "testrunsavefile.dat";
	void Awake()
	{
		if (instance == null)
		{
			DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
		else if (instance != this)
			Destroy(this.gameObject);
	}
	private void Start()
	{
		Load();
	}
	public void Update()
	{
		/*
		if (Input.GetKeyDown(KeyCode.P)) Save();
		if (Input.GetKeyDown(KeyCode.L)) Load();
		if (Input.GetKeyDown(KeyCode.H)) Delete();
		*/
	}

	public void Save()
	{
		string filePath = Application.persistentDataPath + "/" + dataFile;
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(filePath);
		bf.Serialize(file, data);
		file.Close();
		Debug.Log("GameSaved");
		Debug.Log(filePath);
	}
	public void Load()
	{
		string filePath = Application.persistentDataPath + "/" + dataFile;
		BinaryFormatter bf = new BinaryFormatter();
		if (File.Exists(filePath))
		{
			FileStream file = File.Open(filePath, FileMode.Open);
			Data loaded = (Data)bf.Deserialize(file);
			data = loaded;
			file.Close();
			Debug.Log("GameLoaded");
		}
		else
		{
			data.DefaultData();
			Debug.Log("No File");
		}
	}

	public void Delete()
	{

		string filePath = Application.persistentDataPath + "/" + dataFile;
		if (File.Exists(filePath))
		{
			File.Delete(filePath);
			Debug.Log("File Deleted");
			Load();
			Invoke("ReloadGame", .1f);
		}
		else
		{
			Debug.Log("No file to delete");
		}
	}

	void ReloadGame()
	{
		SceneManager.LoadScene("Game");
	}
}

[System.Serializable]
public class Data
{

	public float TotalCoins;
	public float BestScore;
	public bool Mute;
	public bool[] IsPurchased;
	public int LastPickedCharacter;
	public bool NightMode;
	public int IndexOfIsPurchased;

	public void DefaultData()
	{
		TotalCoins = 0;
		BestScore = 0;
		Mute = false;
		LastPickedCharacter = 0;
		IndexOfIsPurchased = 2;
		IsPurchased = new bool[IndexOfIsPurchased];
		IsPurchased[0] = true;
		NightMode = false;
	}


	public void SetData(float GTC, float GBS, bool CMS, bool IPD, int i, int ALP, bool GNM)
	{
		TotalCoins = GTC;
		BestScore = GBS;
		Mute = CMS;
		if (IndexOfIsPurchased == Shop.Instance.ShopItemsList.Count)
		{
			IsPurchased[i] = IPD;
		}
		else
		{
			Array.Resize(ref IsPurchased, IndexOfIsPurchased = Shop.Instance.ShopItemsList.Count);
			IsPurchased[i] = IPD;
			Application.LoadLevel(Application.loadedLevel);
		}

		LastPickedCharacter = ALP;
		NightMode = GNM;
	}
}

