using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardControls : MonoBehaviour
{


	void Update ()
	{
		DisablingPlanetRotation ();
		DisablingCameraRotation ();
		NextPlayerKey ();
		

	}

	void DisablingPlanetRotation ()
	{
        
		if (Input.GetKeyDown ("r")) {  //r for "rotation"
			for (int i = 0; i < PlrData.plr_total_count; i++) {
				PlrData.plr_planet [i].GetComponent<Rotation> ().rotation_enabled = !PlrData.plr_planet [i].GetComponent<Rotation> ().rotation_enabled;
			} 
		}
	}

	void DisablingCameraRotation ()
	{
		if (Input.GetKeyDown ("c")) { // c for "camera"
			GameObject.Find ("Main Camera").GetComponent<RotationCamera> ().rotation_camera_allowed = !GameObject.Find ("Main Camera").GetComponent<RotationCamera> ().rotation_camera_allowed;
		}

	}

	void NextPlayerKey ()
	{
		if (Input.GetKeyDown ("n")) { 
			if (GameObject.Find ("ButtonNextPlayer") != null) {
				if (GameObject.Find ("ButtonNextPlayer").GetComponent<Button> ().interactable == true) {
					GameObject.Find ("RightButtonsFromPrefab").GetComponent<NextPlayer> ().NextPlr ();
				}
			} else {
				if (GameObject.Find ("ButtonStartGame").GetComponent<Button> ().interactable == true) {
					GameObject.Find ("ButtonsOnGameStart").GetComponent<ButtonStartGame> ().BtnStartGame ();
				}
			}
		}

	}

}
