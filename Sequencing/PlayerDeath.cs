using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{


	public void PlrDeath (int PlrNumber)
	{
		string necrology;
		string header;
		string gameEndedString;
		int howManyAreAlive;
		int whoIsAlive;
		howManyAreAlive = 0;
		whoIsAlive = 5;

		for (int i = 0; i < 7; i++) {
			PlrData.plr_resource [PlrNumber, i] = 0;
		}

		GameObject.Find ("ButtonShowHand").GetComponent<Button> ().interactable = false;
		necrology = PlrData.plr_name [PlrNumber] +
		" just died horribly, but as time is due, we send our condolences. Still, God will not forget " + PlrData.plr_name [PlrNumber] + "."; 
			
		for (int i = 0; i < 4; i++) {
		
			if (PlrData.plr_alive [i] == true) {
				howManyAreAlive += 1;
				whoIsAlive = i;
			}
		}

		if (howManyAreAlive == 0) {
			
			gameEndedString = "WHAT AN ABHORRENT WAY TO SAY GOODBYE. All players are dead, no one wins. God shapes new planets.";
			GameLog.AddLog (gameEndedString);
			header = "NO WINNER";
			GameObject.Find ("Sequencing").GetComponent<CreatePanel> ().CreateStandardPanel (header, gameEndedString);
		
		}
			
		if (howManyAreAlive == 1) {
			
			gameEndedString = "Congratulations, " + PlrData.plr_name [whoIsAlive] + "! You win the game and God deems you worthy! ";
			Destroy (PlrData.plr_planet [PlrNumber]);
			Destroy (PlrData.plr_orbit [PlrNumber]);
			Destroy (PlrData.plr_fields [PlrNumber]);
			GameLog.AddLog (gameEndedString);
			header = "GAME FINISHED";
			SceneManager.LoadScene ("Scenes/Menu");
			GameObject.Find ("Sequencing").GetComponent<CreatePanel> ().CreateStandardPanel (header, gameEndedString);
		}

		if (howManyAreAlive > 1) {
			Destroy (PlrData.plr_planet [PlrNumber]);
			Destroy (PlrData.plr_orbit [PlrNumber]);
			Destroy (PlrData.plr_fields [PlrNumber]);
			GameLog.AddLog (necrology);
			header = "PLAYER DEAD HORRIBLY";

			GameObject.Find ("Sequencing").GetComponent<CreatePanel> ().CreateStandardPanel (header, necrology); //necrology


		
		}

	}


}
