using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBFix : MonoBehaviour
{
    public Button button;
    void Start()
    {
        Invoke("PBChange", 0.1f);
    }

	public void PBChange()
    {
        if (GM.NightMode)
        {
            ColorBlock colors = button.colors;
            colors.normalColor = Color.white;
            button.colors = colors;
        }
        else
        {
            ColorBlock colors = button.colors;
            colors.normalColor = Color.black;
            button.colors = colors;
        }
    }
}
