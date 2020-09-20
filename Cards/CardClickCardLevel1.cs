using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardClickCardLevel1 : MonoBehaviour
{
	float time_passed = 0;
	bool giveRewardBool = false;
	bool addCardToHandBool = false;
	bool remainsInHandBool = false;
	bool rotationEnabled = false;

	public void CardClickCardLevel1Script ()
	{


		if (BackgroundSequencingInfo.onYellowFieldNow == false) {
			var localCardNumber = int.Parse (GameObject.Find (gameObject.name + "/CardLevel1CardNumber").GetComponent<Text> ().text);
			for (int i = 0; i < 7; i++) { // because there are 7 requirements
				if (CardDatabase.CardLevel1ReqName [localCardNumber] == i) { //if you know which requirement it is
				
					if (CardDatabase.CardLevel1ReqCost [localCardNumber] <= PlrData.plr_resource [PlrData.current_player, i]) { //if the resource of the player higher or equal to the requirement
						GiveReward (localCardNumber); // Give what the card grants the player

					} else {
						if (CurrentCard.IsPlayedFromHand == true) {
							RemainsInHand (localCardNumber);
						} else {
							AddCardToHand (localCardNumber); // Player cannot play the card now, but he keeps it in his hand.
						}
					}
				}
			}

		} else {
			// something something
			BackgroundSequencingInfo.onYellowFieldNow = false;
			Destroy (gameObject);
		}
	}

	public void GiveReward (int LocalCardNumber)
	{  
		float statsOld;
		float statsDifference;
		float statsNew;
		string whatChanged;
		statsOld = 100; //does not matter
		statsDifference = 200;
		statsNew = 300;
		whatChanged = "The resource that changed";

		for (int i = 0; i < 7; i++) { // because there are 7 grants in this card type. In others there are up to 14 as of now.
			if (CardDatabase.CardLevel1GrantsName [LocalCardNumber] == i) { //if you know which grant it is
				
				whatChanged = PlrData.resource_name_grants [i];
				statsOld = PlrData.plr_resource [PlrData.current_player, i];
				PlrData.plr_resource [PlrData.current_player, i] += CardDatabase.CardLevel1GrantsCost [LocalCardNumber];
				statsDifference = PlrData.plr_resource [PlrData.current_player, i] - statsOld;
				statsNew = PlrData.plr_resource [PlrData.current_player, i];

				if (CurrentCard.IsPlayedFromHand == true) {
					(PlrData.plr_hand_level1 [PlrData.current_player]).Remove (LocalCardNumber);
				} else {
					CardDatabase.ValidCardsLevel1.Remove (LocalCardNumber);
				}
				PlrData.plr_used_cards_level1 [PlrData.current_player].Add (LocalCardNumber);

			}

		}
		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = whatChanged + ": " + statsOld + " + " + statsDifference + " = " + statsNew;
		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
		GameLog.AddLog (PlrData.plr_name [PlrData.current_player] + " plays a Level 1 Card called \"" + CardDatabase.CardLevel1Title [LocalCardNumber] + "\". " + whatChanged + ": " + statsOld + " + " + statsDifference + " = " + statsNew + ".");
	



		giveRewardBool = true;  //must be last, as it destroys the object in Update;



	}

	public void AddCardToHand (int LocalCardNumber)
	{
		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "The card will be added to the hand.";

		CardDatabase.ValidCardsLevel1.Remove (LocalCardNumber);


		PlrData.plr_hand_level1 [PlrData.current_player].Add (LocalCardNumber);


		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
		GameLog.AddLog (PlrData.plr_name [PlrData.current_player] + " adds a Level 1 Card to the hand.");



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

	public Color newColor;

	public void Update ()
	{
		//Rotation and destruction of gameObject
		if (giveRewardBool == true) {
			ColorBlock cb = GetComponent<Button> ().colors;
			if (GameObject.Find ("ButtonKeepInHand") != null) {
				Destroy (GameObject.Find ("ButtonKeepInHand"));
			}
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
			ColorBlock cb = GetComponent<Button> ().colors;
			if (GameObject.Find ("ButtonKeepInHand") != null) {
				Destroy (GameObject.Find ("ButtonKeepInHand"));
			}
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
			ColorBlock cb = GetComponent<Button> ().colors;
			if (GameObject.Find ("ButtonKeepInHand") != null) {
				Destroy (GameObject.Find ("ButtonKeepInHand"));
			}
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
