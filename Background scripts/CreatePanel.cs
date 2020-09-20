using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CreatePanel : MonoBehaviour
{

	public  GameObject StandardPanel;

	public  void CreateStandardPanel (string panelHeader, string panelText)
	{
		Instantiate (StandardPanel, Vector3.zero, Quaternion.identity);
		GameObject.Find ("StandardPanelHeaderText").GetComponent<Text> ().text = panelHeader;
		if (GameObject.Find ("StandardPanelText") != null) {
			print ("GameObject.Find (\"StandardPanelText\") exists");
			GameObject.Find ("StandardPanelText").GetComponent<Text> ().text = panelText;
		}

		BackgroundSequencingInfo.anyPanelIsDisplayed = true;
		BackgroundSequencingInfo.AwaitAction ();
	}



	public  GameObject OverpopulationPanel;

	public  void CreateOverpopulationPanel (int PlrNumber)
	{
		Instantiate (OverpopulationPanel, Vector3.zero, Quaternion.identity);
		BackgroundSequencingInfo.anyPanelIsDisplayed = true;
		BackgroundSequencingInfo.AwaitAction ();
		GameObject.Find ("OverpopulationPanelPlayerText").GetComponent<Text> ().text = PlrData.plr_name [PlrNumber];

	}



	public  GameObject StartFieldPanel;

	public  void CreateStartFieldPanel ()
	{

		Instantiate (StartFieldPanel, Vector3.zero, Quaternion.identity);
		BackgroundSequencingInfo.anyPanelIsDisplayed = true;
		BackgroundSequencingInfo.AwaitAction ();
		int localPlayer = PlrData.current_player;
		string GameLogParts = PlrData.plr_name [localPlayer] + " reached the Bonus Field.";
		string HeaderInfoParts = GameLogParts;
		GameObject.Find ("StartFieldPanelText").GetComponent<Text> ().text = GameLogParts;


		float multiply_populationgrowth_by = 1.1f; 
		float multiply_population_by = 1.5f;
		int addthis_resource_index = 2; // GOLD
		int addthis_resource_value = 10; 

		string addthis_resource_name = PlrData.resource_name [addthis_resource_index];


		float addthis_populationgrowth = PlrData.plr_resource [localPlayer, 0] * (multiply_populationgrowth_by - 1);
		float addthis_population = PlrData.plr_resource [localPlayer, 1] * (multiply_population_by - 1);



		addthis_populationgrowth = (float)System.Math.Round (addthis_populationgrowth, 2);  // Population growth should only have 2 decimals.
		addthis_population = (float)System.Math.Round (addthis_population, 2); // Population should only have 2 decimals.

		int bonus_index = Random.Range (3, 7); //7 is excluded. Available are hydrogen, exomatter, techn. and energy level.
		int bonus_value = Random.Range (2, 5); // add between 2 and 4 units of it
		string bonus_name = PlrData.resource_name [bonus_index];
	

		PlrData.plr_resource [localPlayer, 0] = PlrData.plr_resource [localPlayer, 0] * multiply_populationgrowth_by;
		PlrData.plr_resource [localPlayer, 0] = (float)System.Math.Round (PlrData.plr_resource [localPlayer, 0], 2); // Population growth should only have 2 decimals.

		PlrData.plr_resource [localPlayer, 1] = PlrData.plr_resource [localPlayer, 1] * multiply_population_by;
		PlrData.plr_resource [localPlayer, 1] = (float)System.Math.Round (PlrData.plr_resource [localPlayer, 1], 2); // Population should only have 2 decimals.

		PlrData.plr_resource [localPlayer, addthis_resource_index] += addthis_resource_value;
		PlrData.plr_resource [localPlayer, bonus_index] += bonus_value;

		//1image + 1a never chagne!
		GameObject.Find ("SFText1b").GetComponent<Text> ().text = "+" + ((multiply_populationgrowth_by - 1) * 100).ToString () + "%";
		GameObject.Find ("SFText1c").GetComponent<Text> ().text = "[+" + addthis_populationgrowth.ToString () + "]";

		//2image + 2a never chagne!
		GameObject.Find ("SFText2b").GetComponent<Text> ().text = "+" + ((multiply_population_by - 1) * 100).ToString () + "%";
		GameObject.Find ("SFText2c").GetComponent<Text> ().text = "[+" + addthis_population.ToString () + "]";

		GameObject.Find ("SFImage3").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + addthis_resource_index) as Texture;
		GameObject.Find ("SFText3a").GetComponent<Text> ().text = addthis_resource_name.ToString ();
		GameObject.Find ("SFText3b").GetComponent<Text> ().text = "+" + addthis_resource_value.ToString ();
		//3c exists, but without text. It may be useful later and helps the layoutmanager.

		GameObject.Find ("SFImage4").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + bonus_index) as Texture;
		GameObject.Find ("SFText4a").GetComponent<Text> ().text = "BONUS: " + bonus_name.ToString ();
		GameObject.Find ("SFText4b").GetComponent<Text> ().text = "+" + bonus_value.ToString ();
		//4c exists, but without text. It may be useful later and helps the layoutmanager.

		GameLogParts += "\nPopulation growth: +" + addthis_populationgrowth + ".\n";
		HeaderInfoParts += " Population growth: +" + addthis_populationgrowth + ". ";
		GameLogParts += "Population: +" + addthis_population + ".\n";
		HeaderInfoParts += "Population: +" + addthis_population + ". ";
		GameLogParts += addthis_resource_name + ": +" + addthis_resource_value + ".\n";
		HeaderInfoParts += addthis_resource_name + ": +" + addthis_resource_value + ". ";
		GameLogParts += bonus_name + " (Bonus): +" + bonus_value + ".";
		HeaderInfoParts += bonus_name + " (Bonus): +" + bonus_value + ".";
		GameLog.AddLog (GameLogParts);
		//GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = HeaderInfoParts; // Maybe not needed, as planet step updates are not visible.
		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
	}




	public GameObject PrefabPanelChPlayer;

	public void CreatePanelChoosePlayer ()
	{
		if (GameObject.Find ("StandardLevel2Card") != null) {
			GameObject.Find ("StandardLevel2Card").GetComponent<Button> ().interactable = false;
		}
		if (GameObject.Find ("StandardLevel3Card") != null) {
			GameObject.Find ("StandardLevel3Card").GetComponent<Button> ().interactable = false;
		}


		BackgroundSequencingInfo.ChoosingTargetPlayerStart (); //starts ActionRequired

		GameObject NewPanelChPlayer = Instantiate (PrefabPanelChPlayer, Vector3.zero, Quaternion.identity);
		BackgroundSequencingInfo.anyPanelIsDisplayed = true;
		NewPanelChPlayer.name = "ChoosePlayerPanelFromPrefab";
		if (PlrData.plr_alive [0] == true) {
			GameObject.Find ("ChoosePlayer1Text").GetComponent<Text> ().text = PlrData.plr_name [0];
		} else {
			Destroy (GameObject.Find ("ChoosePlayer1Button"));
		}

		if (PlrData.plr_alive [1] == true) {
			GameObject.Find ("ChoosePlayer2Text").GetComponent<Text> ().text = PlrData.plr_name [1];
		} else {
			Destroy (GameObject.Find ("ChoosePlayer2Button"));
		}

		if (PlrData.plr_alive [2] == true) {
			GameObject.Find ("ChoosePlayer3Text").GetComponent<Text> ().text = PlrData.plr_name [2];
		} else {
			Destroy (GameObject.Find ("ChoosePlayer3Button"));
		}
		if (PlrData.plr_alive [3] == true) {
			GameObject.Find ("ChoosePlayer4Text").GetComponent<Text> ().text = PlrData.plr_name [3];
		} else {
			Destroy (GameObject.Find ("ChoosePlayer4Button"));
		}
	}
}