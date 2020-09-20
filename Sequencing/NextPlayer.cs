using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPlayer : MonoBehaviour
{

	private int local_player;

    
	public void NextPlr ()
	{
		if (GameObject.Find ("PrefabHandCanvas(Clone)") != null) {
			Destroy (GameObject.Find ("PrefabHandCanvas(Clone)"));
			BackgroundSequencingInfo.handIsDisplayed = false;
		}

		BackgroundSequencingInfo.turnCount += 1;

		local_player = PlrData.current_player;
		local_player += 1;


		if (local_player == 4) {
			local_player = 0;
		}

		while (PlrData.plr_alive [local_player] == false) {
			local_player += 1;
			if (local_player == 4) {
				local_player = 0;
			}
		}
		PlrData.current_player = local_player;


		PlrData.plr_planet [local_player].GetComponent<Rotation> ().rotation_enabled = true;
		GameObject.Find ("PlayerRewardName").GetComponent<Text> ().text = PlrData.plr_name [local_player];
		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "The planet is moving.";
		GameObject.Find ("ButtonNextPlayer").GetComponent<Button> ().interactable = false;
        
		BackgroundSequencingInfo.planetStepCompleted = false;
		// GameObject.Find("Main Camera").GetComponent<RotationCamera>().target = PlrData.plr_planet[local_player].transform;
		//enabled = false;
	}
}
