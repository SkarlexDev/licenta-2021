using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour
{
	float deltaTime = 0.0f;

	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(20, 90, w, h * 2 / 100); // 20, 70, w, h * 2 / 100
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color(255.0f, 255.0f, 255.5f, 1.0f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		string text2 = "Developer Build" + "\n";
		GUI.Label(rect, text2 + text, style);
	}
}