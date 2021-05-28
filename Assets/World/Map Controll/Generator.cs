using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	[Header("Spawner")]
	public float spacer;
	public float startfrom;
	public int Tiles;

	[Header("Objects To Spawn")]
	private int RandX;
	private int CanSpawnThis;
	private int SeedR;
	private int CoinT;

	[Header("Randomize Seed")]
	private int CurrentSeed;

	[Header("Randomize Texture")]
	private int TextureTimer;
	private int BTimer;
	public int RTexture;
	public int BTexture;

	[Header("Zone 1")]

	private Vector3 nextTileSpawn;
	public Transform[] tile1obj;
	[Header("Water Zone")]
	public Transform tile1obj2;


	[Header("Objects")]
	public Transform bricksObj;
	private Vector3 nextBrickSpawn;

	public Transform smCrateObj;
	private Vector3 nextSmCrateSpawn;

	public Transform dbCrateObj;
	private Vector3 nextDbCrateSpawn;


	public Transform coinsObj;
	private Vector3 nextCoinSpawn;


	void Start()
	{
		nextTileSpawn.z = startfrom;
		for (int i = 0; i <= 10; i++)
		{
			Generate();
		}

	}

	void Update()
	{
		Tiles = GameObject.FindGameObjectsWithTag("Tile").Length;
		// Debug.Log(Tiles);
	}

	public void Generate()
	{

		RTexture = Random.Range(11, 20);

		if (TextureTimer <= RTexture)
		{
			int i = Random.Range(0, 3);
			Instantiate(tile1obj[i], nextTileSpawn, tile1obj[i].rotation); //texture
			TextureTimer++;
			CurrentSeed = 1;
		}
		else
		{
			Instantiate(tile1obj2, nextTileSpawn, tile1obj2.rotation); //texture
			TextureTimer = 0;
			CurrentSeed = 2;
			BTexture += RTexture;
		}

		ConstructorZone();
		nextTileSpawn.z += spacer;
	}

	// Randomizer X poz + hotfix
	void GMRandomizer()
	{
		XRandomizer();
		ObjectCollection();
		RandomCanSpam();
	}
	void RandomX()
	{
		RandX = Random.Range(-2, 3);
		if (RandX == 1)
		{
			RandX = 2;
		}
		else
		  if (RandX == -1)
		{
			RandX = -2;
		}
	}

	void XRandomizer()
	{
		if (RandX == 0)
		{
			RandX = 2;
		}
		else
		   if (RandX == 2)
		{
			RandX = -2;
		}
		else
		{
			RandX = 0;
		}
	}

	void RandomCanSpam()
	{
		CanSpawnThis = Random.Range(-2, 3);
		//Debug.Log(CanSpawnThis);
	}

	//Select All Objects
	void ObjectCollection()
	{
		DBCrate();
		SMCrate();
		Bricks();
		Coins();
	}

	// Objects Collection
	void DBCrate()
	{
		nextDbCrateSpawn.z = nextTileSpawn.z;
		nextDbCrateSpawn.y = 1f;
		nextDbCrateSpawn.x = RandX;
	}
	void SMCrate()
	{
		nextSmCrateSpawn.z = nextTileSpawn.z;
		nextSmCrateSpawn.y = 1f;
		nextSmCrateSpawn.x = RandX;
	}
	void Bricks()
	{
		nextBrickSpawn.z = nextTileSpawn.z;
		nextBrickSpawn.y = 1f;
		nextBrickSpawn.x = RandX;
	}
	void Coins()
	{
		nextCoinSpawn.z = nextTileSpawn.z;
		nextCoinSpawn.y = 1;
		nextCoinSpawn.x = RandX;
	}

	// Zone Constructor
	void ConstructorZone()
	{
		RandomX();
		if (CurrentSeed == 1)
		{
			for (int GMR = 0; GMR <= 2; GMR++) // 3 lanes
			{
				GMRandomizer();
				RandomizerConstructor();
			}
		}
		else
		{
			GMRandomizer();
			RandomizerConstructor();
		}
	}


	void RandomizerConstructor()
	{
		if (SeedR == CanSpawnThis)
		{
			RandomCanSpam(); // overlay protection
		}
		else
		{
			SeedPick();
		}
	}

	// Zone Seed

	// coins spawn
	void CoinSpawn()
	{
		for (int i = 0; i <= 7; i++)
		{
			nextCoinSpawn.z = nextTileSpawn.z - 8 + i;
			nextCoinSpawn.y = 1;
			nextCoinSpawn.x = RandX;
			Instantiate(coinsObj, nextCoinSpawn, coinsObj.rotation); //Coins
		}
	}
	void CoinSpawnB()
	{
		for (int i = 0; i <= 5; i++)
		{
			nextCoinSpawn.z = nextTileSpawn.z - 3 + i;
			nextCoinSpawn.y = 3;
			Instantiate(bricksObj, nextBrickSpawn, bricksObj.rotation); //Bricks
			Instantiate(coinsObj, nextCoinSpawn, coinsObj.rotation); //Coins
		}
	}
	void SeedPick()
	{
		switch (CurrentSeed)
		{
			case 1:
				Seed1();
				break;
			case 2:
				Seed2();
				break;
		}

	}

	void Seed1()
	{
		switch (CanSpawnThis)
		{
			case -2:
				Instantiate(coinsObj, nextCoinSpawn, coinsObj.rotation); //Coins
				SeedR = CanSpawnThis;
				break;
			case -1:
				Instantiate(dbCrateObj, nextDbCrateSpawn, dbCrateObj.rotation); // 2x Crate
				SeedR = CanSpawnThis;
				break;
			case 0:
				Instantiate(bricksObj, nextBrickSpawn, bricksObj.rotation); //Bricks
				SeedR = CanSpawnThis;
				break;
			case 1:
				Instantiate(smCrateObj, nextSmCrateSpawn, smCrateObj.rotation); //Crate
				SeedR = CanSpawnThis;
				break;
			case 2:
				CoinT = Random.Range(0, 4);
				if (CoinT == 1)
				{
					CoinSpawnB();
				}
				else if (CoinT == 2)
				{
					CoinSpawn();
				}
				else
				{
					Instantiate(smCrateObj, nextSmCrateSpawn, smCrateObj.rotation); //Crate
				}
				SeedR = CanSpawnThis;
				break;

		}
	}
	void Seed2()
	{
		nextCoinSpawn.y = 3f;
		Instantiate(coinsObj, nextCoinSpawn, coinsObj.rotation); //Coins
	}
}
