using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ArrivedOnStep : MonoBehaviour
{
	private int local_current_player;


	public void Arrival ()
	{
		
		local_current_player = PlrData.current_player;




		if (OnGameStart.deactivateFirstStepOnGameStart [local_current_player] == false) { //do not add new stuff on GameStart;
			AddNewStuff (local_current_player); 

			BackgroundSequencingInfo.planetStepCompleted = true;

			PlrData.plr_planet [local_current_player].GetComponent<Rotation> ().rotation_enabled = false;

		}
		OnGameStart.deactivateFirstStepOnGameStart [local_current_player] = false;


		if (PlrData.plr_planet [local_current_player].GetComponent<Rotation> ().rotation_enabled == false) {
			if (BackgroundSequencingInfo.actionIsRequired == false) {
				GameObject.Find ("ButtonNextPlayer").GetComponent<Button> ().interactable = true;
			} 
		}
		//later maybe move this to NextPlayer
        





	}

	public void AddNewStuff (int local_current_player)
	{
		float statsOld;
		float statsDifference;
		float statsNew;

		statsOld = PlrData.plr_resource [PlrData.current_player, 1];
		PlrData.plr_resource [local_current_player, 1] = PlrData.plr_resource [local_current_player, 1] * PlrData.plr_resource [local_current_player, 0]; //multiplies population with population growth
		PlrData.plr_resource [local_current_player, 1] = (float)System.Math.Round (PlrData.plr_resource [local_current_player, 1], 2); // Population should only have 2 decimals. Also rounded in PlrCurrentStatsUpdate,as it is independent
		statsDifference = PlrData.plr_resource [PlrData.current_player, 1] - statsOld;
		statsDifference = (float)System.Math.Round (statsDifference, 2);
		statsNew = PlrData.plr_resource [PlrData.current_player, 1];


		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "Population: " + statsOld + " + " + statsDifference + " = " + statsNew;
		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
		GameLog.AddLog (PlrData.plr_name [local_current_player] + " moves. Population level rises from " + statsOld + " to " + statsNew + ".");
	}
}
