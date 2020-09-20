using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
	int planet_speed;

	public void Start ()
	{
		PlrData.DefineSettings ();
	}

	public void BtnPlanetSpeedMinus ()
	{
		planet_speed = int.Parse (GameObject.Find ("SettingsPlanetSpeedNumber").GetComponent<Text> ().text);
		planet_speed -= 1;
		if (planet_speed == 0) {
			planet_speed = 1;
		}
		PlrData.settings_planet_speed = planet_speed;
		GameObject.Find ("SettingsPlanetSpeedNumber").GetComponent<Text> ().text = planet_speed.ToString ();
	}

	public void BtnPlanetSpeedPlus ()
	{
		planet_speed = int.Parse (GameObject.Find ("SettingsPlanetSpeedNumber").GetComponent<Text> ().text);
		planet_speed += 1;
		if (planet_speed == 11) {
			planet_speed = 10;
		}
		PlrData.settings_planet_speed = planet_speed;
		GameObject.Find ("SettingsPlanetSpeedNumber").GetComponent<Text> ().text = planet_speed.ToString ();
	}

	public void BtnCloseSettings ()
	{
		Destroy (gameObject);
	}
}
