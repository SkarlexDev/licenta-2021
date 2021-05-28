using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DM = DataManager;

public class GM : MonoBehaviour
{
	public static GM Instance { set; get; }

	//player stats
	public static int HP;
	public static bool Alive;
	public static float CScore;
	public static int coinTotal;


	//Speed increase
	public static float speed;
	private float speedIncreaseLTick;
	private float speedTime = 5f;
	private float speedAmmount = 0.1f;

	//game
	private bool isGameStarted = false;
	private PlayerMotor motor;
	public DataLoader DL;
	public static bool isRunning;

	public static bool Mute;
	public static bool NightMode;

	[Header("PC VS Android")]
	public bool StatusConfirmed = false;
	public MenuAnimationController MAC;
	[Header("PC")]

	public GameObject PC_UI;
	public Button PC_Resume;
	public GameObject Pause_Pc_Button;

	[Header("Android")]


	public GameObject Mobile_UI;
	public Button Mobile_Resume;
	public GameObject Pause_Mobile_Button;

	private void Awake()
	{
		Instance = this;
#if UNITY_STANDALONE_WIN
		Mobile_UI.SetActive(false);
#else
		PC_UI.SetActive(false);
#endif

	}
	private void Start()
	{

#if UNITY_STANDALONE_WIN
		Application.targetFrameRate = -1;
#else
		Application.targetFrameRate = Screen.currentResolution.refreshRate;
#endif

	}

	void Update()
	{
		if (!Alive && !StatusConfirmed)
		{
			float temp = 2.5f;
			DL.SaveStats();
			speed = 0;
#if UNITY_STANDALONE_WIN

			Pause_Pc_Button.SetActive(false);
			PC_Resume.interactable = false;
			Invoke("DelayerGameover", temp);
			MAC.CStats();

#else
			Pause_Mobile_Button.SetActive(false);
			Mobile_Resume.interactable = false;
			Invoke("DelayerGameover", temp);
			MAC.CStats();

#endif
			StatusConfirmed = true;
		}
		if (Alive && isRunning)
		{
			SpeedIA();
		}
	}

	public void DelayerGameover()
	{
		MAC.GameOver();
	}
	void FixedUpdate()
	{
		if (Alive && isRunning)
		{
			Score();
		}
	}
	void SpeedIA()
	{
		if (Time.time - speedIncreaseLTick > speedTime)
		{
			speedIncreaseLTick = Time.time;
			speed += speedAmmount;
			Debug.Log(speed);
		}
	}
	void Score()
	{
		//temp demo
		CScore += 2000 + Time.deltaTime + speed / 10;
	}
	public void StartGameB()
	{
		if (Alive)
		{
			if (motor == null)
				motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
			isGameStarted = true;
			motor.StartRunning();
			isRunning = true;
		}
	}

	//coins ussage
	public void UseCoins(int X)
	{
		DM.instance.data.TotalCoins -= X;
		CallSave();
	}

	public void CallSave()
	{
		Invoke("DataSaveFix", .1f);
	}

	public bool HaveEnoughCoins(int X)
	{
		return (DM.instance.data.TotalCoins >= X);
	}

	void DataSaveFix()
	{
		DL.SaveStats();
	}
}
