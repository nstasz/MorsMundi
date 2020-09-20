using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCreateSettings : MonoBehaviour
{
	public GameObject SettingsPnl;
	// Use this for initialization
	public void CreateSettingsPanel ()
	{
		var newPanel = Instantiate (SettingsPnl, Vector3.zero, Quaternion.identity);
		newPanel.transform.SetParent (GameObject.Find ("Canvas").transform); // in other words: Display on Canvas
		newPanel.transform.position = GameObject.Find ("Canvas").transform.position;
		print ("I created a panel");
	}
}
