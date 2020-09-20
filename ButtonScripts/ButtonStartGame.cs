using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStartGame : MonoBehaviour
{

	public GameObject OtherButtons;

	public void BtnStartGame ()
	{
		CreateNewButtons ();

		PlrData.current_player = 0;
		PlrData.plr_planet [0].GetComponent<Rotation> ().rotation_enabled = true;
		GameObject.Find ("PlayerRewardName").GetComponent<Text> ().text = PlrData.plr_name [PlrData.current_player];
		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "The planet is moving.";
		GameObject.Find ("ButtonNextPlayer").GetComponent<Button> ().interactable = false;

		//test
		/*
		string header;
		header = "header Start";
		string a;
		a = "this is in start";
		print (a);
		GameObject.Find ("Sequencing").GetComponent<CreatePanel> ().CreateStandardPanel (header, a);
*/	
		//end test
		Destroy (gameObject);


		// GameObject.Find("Main Camera").GetComponent<RotationCamera>().target = PlrData.plr_planet[local_player].transform;
		//enabled = false;
	}

	public void CreateNewButtons ()
	{
		print ("Button Start Game pressed");
		GameObject NewButtons = Instantiate (OtherButtons, Vector3.zero, Quaternion.identity);
		NewButtons.name = "RightButtonsFromPrefab";	
	}
}
