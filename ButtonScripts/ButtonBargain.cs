using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBargain : MonoBehaviour
{
	public Color newColor;

	public void ButtonBargainAccept ()
	{
		
		float ConditionCost = CurrentCard.BargainConditionCost;
		int ConditionCostInt = (int)ConditionCost;
		int ConditionIndex = CurrentCard.BargainConditionIndex;
		float GrantsCost = CurrentCard.BargainGrantsCost;
		int GrantsCostInt = (int)ConditionCost;
		int GrantsIndex = CurrentCard.BargainGrantsIndex;
		int CurPl = PlrData.current_player;
		if (ConditionIndex < 7) {
			PlrData.plr_resource [CurPl, ConditionIndex] -= ConditionCost;

		}
		if (ConditionIndex == 7) {
			PlrData.plr_hand_level1 [CurPl].RemoveAt (ConditionCostInt);

		}
		if (ConditionIndex == 8) {
			PlrData.plr_hand_level2 [CurPl].RemoveAt (ConditionCostInt);

		}
		if (ConditionIndex == 9) {
			PlrData.plr_hand_level3 [CurPl].RemoveAt (ConditionCostInt);

		}

		if (GrantsIndex < 7) {
			PlrData.plr_resource [CurPl, GrantsIndex] += GrantsCost;
		}
		if (GrantsIndex == 7) {
			PlrData.plr_hand_level1 [CurPl].Add (GrantsCostInt);

		}
		if (GrantsIndex == 8) {
			PlrData.plr_hand_level2 [CurPl].Add (GrantsCostInt);

		}
		if (GrantsIndex == 9) {
			PlrData.plr_hand_level3 [CurPl].Add (GrantsCostInt);

		}
		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
		PlrCurrentStatsUpdate.RoundingAllPlayersPopulationGrowthAndPopulation ();
		newColor = Color.green;
		destruction_enabled = true;
	}



	public bool destruction_enabled = false;

	public void ButtonBargainDecline ()
	{
		newColor = Shortcuts.colorDarkRed;
		destruction_enabled = true; //See Update

	}

	float time_passed = 0;

	public void Update ()
	{
		if (destruction_enabled == true) {
			
			GameObject BGBackground = GameObject.Find ("BargainBackground");
			BGBackground.GetComponent<RawImage> ().color = newColor;
			bool rotationEnabled;
			rotationEnabled = true;

			if (rotationEnabled == true) {
				time_passed += Time.deltaTime;

				Destroy (GameObject.Find ("ButtonBargainAccept"));
				Destroy (GameObject.Find ("ButtonBargainDecline"));
				Destroy (GameObject.Find ("PanelBargainCondition"));
				Destroy (GameObject.Find ("PanelBargainWin"));
				//Destroy (GameObject.Find ("ButtonBargainAgain"));
				if (time_passed < 0.25f) {
					BGBackground.transform.Rotate (new Vector3 (0, 1, 0), 180 * Time.deltaTime);
					BGBackground.transform.localScale += new Vector3 (-0.03f, -0.03f, -0.03f);

				}
				if (time_passed > 0.25f) { 



					BGBackground.transform.Rotate (new Vector3 (0, 1, 0), 180 * Time.deltaTime);
					BGBackground.transform.localScale += new Vector3 (0.03f, 0.03f, 0.03f);
				}

				if (time_passed > 0.5f) { 
					

					BackgroundSequencingInfo.NoActionRequieredAnymore ();
					Destroy (GameObject.Find ("BargainCard"));
					//GameObject.Find ("BargainCard").SetActive (false);
					//foreach (Transform child in GameObject.Find("CardCanvas").transform) {
					//	GameObject.Destroy (child.gameObject);



				}
			}
		}
	}
	/*
	public void ButtonBargainBargainAgain ()
	{
		
		//  foreach (Transform child in GameObject.Find("CardCanvas").transform) {
		//	GameObject.Destroy (child.gameObject);
		//}

		GameObject.Find ("Cards").GetComponent<BargainCreateDisplay> ().BargainMainScript ();
	}*/
}
