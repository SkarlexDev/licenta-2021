using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour
{
    public float SpX = .1f;
    public float SpY = .1f;
    private float curX;
    private float curY;

	private void Start()
	{
		curX = GetComponent<Renderer>().material.mainTextureOffset.x;
		curY = GetComponent<Renderer>().material.mainTextureOffset.y;
	}

	private void Update()
	{
		curX += Time.deltaTime * SpX;
		curY += Time.deltaTime * SpY;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curX, curY));
	}
}
