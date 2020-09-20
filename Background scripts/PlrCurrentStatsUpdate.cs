using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlrCurrentStatsUpdate : MonoBehaviour
{

	static string[] Stats;

	public static void PlrCurrentStatsUpdateClass ()
	{
		bool playerJustDiedBool = false;
		int playerJustDiedNr = 5;
		bool playerReachedOverpopulationBool = false;
		int playerReachedOverpopulationNr = 5;

		for (int i = 0; i < 4; i++) { 
			/* TEST
			if (PlrData.plr_resource [i, 0] < 0.001f) {
				PlrData.plr_resource [i, 0] = 0;
			}
			*/
			if (PlrData.plr_resource [i, 1] < 1) {
				PlrData.plr_resource [i, 1] = 0;
			}



			PlrData.plr_used_cards [i] = PlrData.plr_used_cards_level1 [i].Count + PlrData.plr_used_cards_level2 [i].Count + PlrData.plr_used_cards_level3 [i].Count + PlrData.plr_used_cards_event [i].Count + PlrData.plr_used_cards_bargain [i].Count;
			PlrData.plr_hand [i] = PlrData.plr_hand_level1 [i].Count + PlrData.plr_hand_level2 [i].Count + PlrData.plr_hand_level3 [i].Count;



			if (PlrData.plr_resource [i, 1] <= 0.001f) {
				if (PlrData.plr_alive [i] == true) { //if you see that a player is dead, but he is declared as alive
					playerJustDiedBool = true;
					playerJustDiedNr = i;
					PlrData.plr_alive [i] = false;
				}

			}

			if (PlrData.plr_resource [i, 1] > 1000000) {
				playerReachedOverpopulationBool = true;
				playerReachedOverpopulationNr = i;
			}
			if (PlrData.plr_alive [i] == true) {
				GameObject.Find ("Plr" + (i + 1).ToString () + "Name").GetComponent<Text> ().text = PlrData.plr_name [i];
				RoundingAllPlayersPopulationGrowthAndPopulation ();
				CheckForHugeStatsAndDisplayNumbersWithLetters (i);

				GameObject.Find ("StatsPlr" + (i + 1).ToString () + "HandText").GetComponent<Text> ().text = PlrData.plr_hand [i].ToString ();
			} else {
				if (GameObject.Find ("Plr" + (i + 1)) != null) {
					Destroy (GameObject.Find ("Plr" + (i + 1).ToString ()));
				}

			}
		}
			

		if (playerJustDiedBool == true) {
			GameObject.Find ("Sequencing").GetComponent<PlayerDeath> ().PlrDeath (playerJustDiedNr);

		}
		if (playerReachedOverpopulationBool == true) {
			PlayerOverpopulation.PlrOverpopulation (playerReachedOverpopulationNr);

		}
			
		/*
		//test
		if (BackgroundSequencingInfo.turnCount > 2) {
			BackgroundSequencingInfo.NoActionRequieredAnymore ();
		}
		//end test
		*/
	}

	public static void RoundingAllPlayersPopulationGrowthAndPopulation ()
	{
		for (int i = 0; i < 4; i++) {
			PlrData.plr_resource [i, 0] = (float)System.Math.Round (PlrData.plr_resource [i, 0], 2);
			PlrData.plr_resource [i, 1] = (float)System.Math.Round (PlrData.plr_resource [i, 1], 2);
		}
	}

	public static void CheckForHugeStatsAndDisplayNumbersWithLetters (int i)
	{
		for (int j = 0; j < 7; j++) { 
			GameObject.Find ("StatsPlr" + (i + 1).ToString () + "Res" + j.ToString () + "Text").GetComponent<Text> ().text = PlrData.plr_resource [i, j].ToString ();
			if (j == 1 && PlrData.plr_resource [i, 1] > 999.99) {
				float rounded_population = (float)System.Math.Round (PlrData.plr_resource [i, 1] / 1000, 1); // e.g. 1400 becomes 1.4, 900,010.21 becomes 900,0
				GameObject.Find ("StatsPlr" + (i + 1).ToString () + "Res" + j.ToString () + "Text").GetComponent<Text> ().text = rounded_population.ToString () + "k";
			}
			if (j == 1 && PlrData.plr_resource [i, 1] > 999999.99) {
				float rounded_population = (float)System.Math.Round (PlrData.plr_resource [i, 1] / 1000000, 3); // e.g. 1400 becomes 1.4, 900,010.21 becomes 900,0
				GameObject.Find ("StatsPlr" + (i + 1).ToString () + "Res" + j.ToString () + "Text").GetComponent<Text> ().text = rounded_population.ToString () + "m";
			}
		}
	}


}