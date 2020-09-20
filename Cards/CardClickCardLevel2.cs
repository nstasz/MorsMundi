using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardClickCardLevel2 : MonoBehaviour
{
	float time_passed = 0;
	bool oneRequirementFulfilled = false;
	bool bothRequirementsFulfilled = false;
	int firstRequirementNumber = 0;
	int secondRequirementNumber = 0;
	bool giveRewardBool = false;
	bool addCardToHandBool = false;
	bool remainsInHandBool = false;
	bool rotationEnabled = false;

	bool waitForTargetingPlayer = false;

	public void CardClickCardLevel2Script ()
	{
		GetComponent<Button> ().interactable = false;

		if (BackgroundSequencingInfo.onYellowFieldNow == false) {
			var localCardNumber = int.Parse (GameObject.Find (gameObject.name + "/CardLevel2CardNumber").GetComponent<Text> ().text);

			if (CardDatabase.CardLevel2HasReq [localCardNumber] == true) {
				for (int i = 0; i < 13; i++) { // because there are 13 requirements. If a card should cost something (8-13), then the player still has to have the resources required
					if (CardDatabase.CardLevel2Req1Name [localCardNumber] == i) {
						firstRequirementNumber = i;
						int j = i;
						if (i > 6) {
							j = i - 7;
						}
						if (CardDatabase.CardLevel2Req1Cost [localCardNumber] <= PlrData.plr_resource [PlrData.current_player, j]) { //if the resource of the player higher or equal to the requirement
							oneRequirementFulfilled = true;
						} 
					}
				}
				if (oneRequirementFulfilled == true) {
					for (int i = 0; i < 13; i++) { 
						if (CardDatabase.CardLevel2Req2Name [localCardNumber] == i) { 
							secondRequirementNumber = i;
							int j = i;
							if (i > 6) {
								j = i - 7; // because I check for 14 things and players got only 7 resources
							}
							if (CardDatabase.CardLevel2Req2Cost [localCardNumber] <= PlrData.plr_resource [PlrData.current_player, j]) { 
								bothRequirementsFulfilled = true;
							} 
						}
					}
				}
				if (bothRequirementsFulfilled == true) {
					GiveReward (localCardNumber);
				} else { 
					if (CurrentCard.IsPlayedFromHand == true) {
						RemainsInHand (localCardNumber);
					} else {
						AddCardToHand (localCardNumber); 
					}
				}
			} else {
				GiveReward (localCardNumber);
			}
		} else {
			// something something related to  yellow field
			BackgroundSequencingInfo.onYellowFieldNow = false;
			Destroy (gameObject);
		}

	}

	string gameLogFirstPart = "";
	public bool somethingWasPaid = false;

	public string SubtractTheCost (int localCardNumber)
	{  
		//Activated by GiveReward
		//Checks if requirements cost something and substracts it

		if (CardDatabase.CardLevel2HasReq [localCardNumber] == true) {
			if (firstRequirementNumber > 6) {
				PlrData.plr_resource [PlrData.current_player, firstRequirementNumber - 7] -= CardDatabase.CardLevel2Req1Cost [localCardNumber];
				gameLogFirstPart = PlrData.plr_name [PlrData.current_player] + " paid " + CardDatabase.CardLevel2Req1Cost [localCardNumber] + " " + PlrData.resource_name_grants [firstRequirementNumber];
				somethingWasPaid = true;
			}
			if (secondRequirementNumber > 6) {
				PlrData.plr_resource [PlrData.current_player, secondRequirementNumber - 7] -= CardDatabase.CardLevel2Req2Cost [localCardNumber];
				gameLogFirstPart += " and " + CardDatabase.CardLevel2Req2Cost [localCardNumber] + " " + PlrData.resource_name_grants [secondRequirementNumber];
			}
			if (somethingWasPaid == true) {
				gameLogFirstPart += ".";
			}
		}
		return gameLogFirstPart;

	}

	string gameLogString = "";

	public void GiveReward (int LocalCardNumber) //conditions were fulfilled
	{  
		
		gameLogString += SubtractTheCost (LocalCardNumber); //Substracts the cost if it exists and returns what happened as a string.

		if (CardDatabase.CardLevel2HasScript [LocalCardNumber] == false) {
			if (CardDatabase.CardLevel2CanAffectAnotherPlayer [LocalCardNumber] == false) {
				float statsOld;
				float statsDifference;
				float statsNew;
				string whatChanged;
				statsOld = 100; //does not matter
				statsDifference = 200;
				statsNew = 300;
				whatChanged = "The resource that changed";

				for (int i = 0; i < 7; i++) { // because there are 7 grants in this card type. In others there are up to 14 as of now.
					if (CardDatabase.CardLevel2GrantsName [LocalCardNumber] == i) { //if you know which grant it is

						whatChanged = PlrData.resource_name_grants [i];
						statsOld = PlrData.plr_resource [PlrData.current_player, i];
						PlrData.plr_resource [PlrData.current_player, i] += CardDatabase.CardLevel2GrantsCost [LocalCardNumber];
						statsDifference = PlrData.plr_resource [PlrData.current_player, i] - statsOld;
						statsNew = PlrData.plr_resource [PlrData.current_player, i];

						if (CurrentCard.IsPlayedFromHand == true) {
							(PlrData.plr_hand_level2 [PlrData.current_player]).Remove (LocalCardNumber);
						} else {
							CardDatabase.ValidCardsLevel2.Remove (LocalCardNumber);
						}
						PlrData.plr_used_cards_level2 [PlrData.current_player].Add (LocalCardNumber);

					}

				}
				GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = gameLogString + " " + whatChanged + ": " + statsOld + " + " + statsDifference + " = " + statsNew;
				PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
				GameLog.AddLog (PlrData.plr_name [PlrData.current_player] + " plays a Level 2 Card called \"" + CardDatabase.CardLevel2Title [LocalCardNumber] + "\". " + gameLogString + " " + whatChanged + ": " + statsOld + " + " + statsDifference + " = " + statsNew + ".");
				giveRewardBool = true;
			
			} else { // if it affects another player
				(PlrData.plr_hand_level2 [PlrData.current_player]).Remove (LocalCardNumber);
				if (BackgroundSequencingInfo.handIsDisplayed == true) {
					//GameObject.Find ("RightButtonsFromPrefab").GetComponent<HandUpdate> ().DestroyThePreviousOne ();  //if it WAS displayed previously
					Destroy (GameObject.Find ("PrefabHandCanvas(Clone)"));
					BackgroundSequencingInfo.handIsDisplayed = false;
				}	
				GameObject.Find ("Sequencing").GetComponent<CreatePanel> ().CreatePanelChoosePlayer ();
				waitForTargetingPlayer = true;
			}
		} else { // if it has a script
			GameObject.Find ("Cards").GetComponent<CardScripts> ().PlayScript (2, LocalCardNumber);
			giveRewardBool = true;
		}



		//must be last, as it destroys the object in Update;



	}

	public void AddCardToHand (int LocalCardNumber)
	{
		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "The card will be added to the hand.";

		CardDatabase.ValidCardsLevel2.Remove (LocalCardNumber);


		PlrData.plr_hand_level2 [PlrData.current_player].Add (LocalCardNumber);


		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
		GameLog.AddLog (PlrData.plr_name [PlrData.current_player] + " adds a Level 2 Card to the hand.");



		addCardToHandBool = true; //must be last, as it destroys the object in Update;


	}

	public void RemainsInHand (int LocalCardNumber)
	{
		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "You do not fulfill the requierements. Keep the card for later";

		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
		GameLog.AddLog (PlrData.plr_name [PlrData.current_player] + " wants to play a card, but the requirements are not fulfilled.");

		CurrentCard.WillRemainInHand = true;
		rotationEnabled = true;
		remainsInHandBool = true; //must be last, as it destroys the object in Update;


	}


	public void DiminishAnotherPlayersResources ()
	{
		var localCardNumber = int.Parse (GameObject.Find (gameObject.name + "/CardLevel2CardNumber").GetComponent<Text> ().text);
		float statsOld;
		float statsDifference;
		float statsNew;
		string whatChanged;
		statsOld = 100; //does not matter
		statsDifference = 200;
		statsNew = 300;
		whatChanged = "The resource that changed";

		whatChanged = PlrData.resource_name_grants [CardDatabase.CardLevel2GrantsName [localCardNumber]];
		statsOld = PlrData.plr_resource [BackgroundSequencingInfo.targetPlayerChosenNumber, CardDatabase.CardLevel2GrantsName [localCardNumber] - 7];
		PlrData.plr_resource [BackgroundSequencingInfo.targetPlayerChosenNumber, CardDatabase.CardLevel2GrantsName [localCardNumber] - 7] -= CardDatabase.CardLevel2GrantsCost [localCardNumber];
		if (CardDatabase.CardLevel2GrantsName [localCardNumber] == 7 || CardDatabase.CardLevel2GrantsName [localCardNumber] == 8) {
			System.Math.Round (PlrData.plr_resource [BackgroundSequencingInfo.targetPlayerChosenNumber, CardDatabase.CardLevel2GrantsName [localCardNumber] - 7], 2);
		}
		statsDifference = statsOld - PlrData.plr_resource [BackgroundSequencingInfo.targetPlayerChosenNumber, CardDatabase.CardLevel2GrantsName [localCardNumber] - 7];
		statsNew = PlrData.plr_resource [BackgroundSequencingInfo.targetPlayerChosenNumber, CardDatabase.CardLevel2GrantsName [localCardNumber] - 7];




		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = PlrData.plr_name [PlrData.current_player] + " plays a Level 2 Card called \"" + CardDatabase.CardLevel2Title [localCardNumber] + "\" and affects " + PlrData.plr_name [BackgroundSequencingInfo.targetPlayerChosenNumber] + " " + whatChanged + ": " + statsOld + " - " + statsDifference + " = " + statsNew + ".";
		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
		GameLog.AddLog (PlrData.plr_name [PlrData.current_player] + " plays a Level 2 Card called \"" + CardDatabase.CardLevel2Title [localCardNumber] + "\" and affects " + PlrData.plr_name [BackgroundSequencingInfo.targetPlayerChosenNumber] + ". " + whatChanged + ": " + statsOld + " - " + statsDifference + " = " + statsNew + ".");
		if (BackgroundSequencingInfo.handIsDisplayed == true) {
			GameObject.Find ("RightButtonsFromPrefab").GetComponent<HandUpdate> ().HandUpdateScript ();  //if it WAS displayed previously
		}	
		giveRewardBool = true;
	}

	public Color newColor;

	public void Update ()
	{

		if (waitForTargetingPlayer == true) {
			if (BackgroundSequencingInfo.choosingTargetPlrActive == false) {
				DiminishAnotherPlayersResources ();
				waitForTargetingPlayer = false;
			}
		}

		//Rotation and destruction of gameObject.

		if (giveRewardBool == true) {
			if (GameObject.Find ("ButtonKeepInHand") != null) {
				Destroy (GameObject.Find ("ButtonKeepInHand"));
			}
			ColorBlock cb = GetComponent<Button> ().colors;

			newColor = Color.green;
			cb.disabledColor = newColor;
			GetComponent<Button> ().colors = cb;
			GetComponent<Button> ().interactable = false;
			transform.Rotate (new Vector3 (0, 1, 0), 720f * Time.deltaTime); //rotate by 180 degrees in one 1 second
			transform.localScale -= new Vector3 (0.02f, 0.02f, 0.02f);
			transform.position += new Vector3 (0, -20, 0);
			time_passed += Time.deltaTime;

			//if (time_passed > 0.125f)
			if (time_passed > 0.5f) { // if half a second has passed... 
				BackgroundSequencingInfo.NoActionRequieredAnymore ();

				Destroy (gameObject);
			}
		}
		if (addCardToHandBool == true) {
			if (GameObject.Find ("ButtonKeepInHand") != null) {
				Destroy (GameObject.Find ("ButtonKeepInHand"));
			}
			ColorBlock cb = GetComponent<Button> ().colors;
			newColor = Color.red;
			cb.disabledColor = newColor;
			GetComponent<Button> ().colors = cb;
			GetComponent<Button> ().interactable = false;
			transform.Rotate (new Vector3 (0, 1, 0), 720f * Time.deltaTime); //rotate by 180 degrees in one 1 second
			time_passed += Time.deltaTime;

			if (time_passed > 0.125f) { // if half a second has passed... 
				BackgroundSequencingInfo.NoActionRequieredAnymore ();

				Destroy (gameObject);
			}

		}
		if (remainsInHandBool == true) {
			if (GameObject.Find ("ButtonKeepInHand") != null) {
				Destroy (GameObject.Find ("ButtonKeepInHand"));
			}
			ColorBlock cb = GetComponent<Button> ().colors;
			newColor = Color.red;
			cb.disabledColor = newColor;
			GetComponent<Button> ().colors = cb;

			if (rotationEnabled == true) {
				time_passed += Time.deltaTime;
				GetComponent<Button> ().interactable = false;
				if (time_passed < 0.25f) {
					transform.Rotate (new Vector3 (0, 2, 0), 720 * Time.deltaTime);
					transform.localScale += new Vector3 (-0.02f, -0.02f, -0.02f);

				}
				if (time_passed > 0.25f) { 

					GetComponent<Button> ().interactable = false;


					transform.Rotate (new Vector3 (0, 2, 0), 720 * Time.deltaTime);
					transform.localScale += new Vector3 (0.02f, 0.02f, 0.02f);
				}

				if (time_passed > 0.5f) { 
					BackgroundSequencingInfo.NoActionRequieredAnymore ();
					GetComponent<Button> ().interactable = true;

					rotationEnabled = false;
				}
			}
		}
	}
}
