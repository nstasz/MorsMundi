using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScripts : MonoBehaviour
{

	public GameObject PrefabBlackHole;

	public bool waitForCompletedAnimation;
	public bool waitFor_2_5;
	public bool waitFor_2_10;

	public bool waitFor_2_tk_1;
	public bool waitFor_2_tk_2;
	public bool waitFor_2_tk_3;
	public bool waitFor_2_tk_4;

	public bool waitFor_3_1;
	public bool waitFor_3_13;
	public bool waitForTargetingPlayer;
	// throw into black hole

	public void Start ()
	{
		waitForCompletedAnimation = false;
		waitForTargetingPlayer = false;
		waitFor_2_5 = false;
		waitFor_2_10 = false;

		waitFor_2_tk_1 = false;
		waitFor_2_tk_2 = false;
		waitFor_2_tk_3 = false;
		waitFor_2_tk_4 = false;

		waitFor_3_1 = false;
		waitFor_3_13 = false;
	}

	public void Update ()
	{
		if (waitForCompletedAnimation == true) {
			if (BackgroundSequencingInfo.actionIsRequired == false) {
				if (waitFor_2_5 == true) {
					Script_2_5 ();
				}
				if (waitFor_2_10 == true) {
					Script_2_10 ();
				}
				if (waitFor_2_tk_1 == true) {
					Script_2_tk_1 ();
				}
				if (waitFor_2_tk_2 == true) {
					Script_2_tk_2 ();
				}
				if (waitFor_2_tk_3 == true) {
					Script_2_tk_3 ();
				}
				if (waitFor_2_tk_4 == true) {
					Script_2_tk_4 ();
				}
				if (waitFor_3_1 == true) {
					Script_3_1_throwIntoBlackHole_beforeTargeting ();
				}
				if (waitFor_3_13 == true) {
					Script_3_13 ();
				}


				if (waitForTargetingPlayer == true) {
					print ("waitForTargetingPlayer == true");
					if (BackgroundSequencingInfo.choosingTargetPlrActive == false) { // if a player has been chosen
						print (".choosingTargetPlrActive == false");
						Script_3_1_throwIntoBlackHole_afterTargeting ();
						waitForTargetingPlayer = false;
					}
				}


			}
		}
	}

	public void PlayScript (int CardType, int CardNr)
	{
		print ("PlayScript activated card: " + CardNr);
		if (CardType == 2) {  //LEVEL 2 and tokens, token at the and
			if (CardNr == 10) {
				waitForCompletedAnimation = true;
				waitFor_2_10 = true;
			}
			if (CardNr == 5) {
				waitForCompletedAnimation = true;
				waitFor_2_5 = true;
			}
			///LEVEL 2 TOKENS
			if (CardNr == CardDatabase.tk2 + 1) {
				waitForCompletedAnimation = true;
				waitFor_2_tk_1 = true;
			}
			if (CardNr == CardDatabase.tk2 + 2) {
				waitForCompletedAnimation = true;
				waitFor_2_tk_2 = true;
			}
			if (CardNr == CardDatabase.tk2 + 3) {
				waitForCompletedAnimation = true;
				waitFor_2_tk_3 = true;
			}
			if (CardNr == CardDatabase.tk2 + 4) {
				waitForCompletedAnimation = true;
				waitFor_2_tk_4 = true;
			}

		}
		if (CardType == 3) {  //LEVEL 3 and tokens, token at the and
			if (CardNr == 1) {
				waitForCompletedAnimation = true;
				waitFor_3_1 = true;
			}
			if (CardNr == 13) {
				waitForCompletedAnimation = true;
				waitFor_3_13 = true;
			}
		}


	}

	public void UpdateUsedCardsAndHand (int cardtype, int index, int playerNr)
	{
		if (cardtype == 1) {
			PlrData.plr_hand_level1 [playerNr].Remove (index);
			PlrData.plr_used_cards_level1 [playerNr].Add (index);
		}
		if (cardtype == 2) {
			PlrData.plr_hand_level2 [playerNr].Remove (index);
			PlrData.plr_used_cards_level2 [playerNr].Add (index);
			// tokens are the same category. They are just cardtype1 cards that are at the end
		}
		if (cardtype == 3) {
			PlrData.plr_hand_level3 [playerNr].Remove (index);
			PlrData.plr_used_cards_level3 [playerNr].Add (index);
		}
	}


	public void UpdateInfo (string log)
	{
		//HAND
		if (BackgroundSequencingInfo.handIsDisplayed == true) {
			Destroy (GameObject.Find ("PrefabHandCanvas(Clone)"));
			GameObject.Find ("RightButtonsFromPrefab").GetComponent<HandUpdate> ().HandUpdateScript ();  //if it WAS displayed previously
		}	
		//PLAYER REWARD INFO
		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = log;
		//STATS
		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
		//LOG
		GameLog.AddLog (log);
		print (log);
	}


	public void Script_2_5 ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = 5;
		int CurPl = PlrData.current_player;
		waitForCompletedAnimation = false;
		waitFor_2_5 = false;
		//
		//
		int Level1Playable = CardDatabase.CardLevel1PlayableTotalCount;
		PlrData.plr_hand_level1 [CurPl].Add (Random.Range (0, Level1Playable));
		PlrData.plr_hand_level1 [CurPl].Add (Random.Range (0, Level1Playable));
		PlrData.plr_hand_level1 [CurPl].Add (Random.Range (0, Level1Playable));

		string log = PlrData.plr_name [CurPl] + " played the card " + CardDatabase.CardLevel2Title [index] + " and added three random Level 1 Cards to the hand.";


		//ALWAYS UPDATE INFORMATION
		//
		UpdateUsedCardsAndHand (2, index, CurPl);
		UpdateInfo (log);
		//
		//
	}

	public void Script_2_10 ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = 10;
		int CurPl = PlrData.current_player;
		waitForCompletedAnimation = false;
		waitFor_2_10 = false;
		//
		//


		PlrData.plr_hand_level2 [CurPl].Add (CardDatabase.tk2 + 0);
		PlrData.plr_hand_level2 [CurPl].Add (CardDatabase.tk2 + 0);
		PlrData.plr_hand_level2 [CurPl].Add (CardDatabase.tk2 + 0);


		string log = PlrData.plr_name [CurPl] + " played the card Chemtrail Pollution and added three Chemtrails to the hand.";


		//ALWAYS UPDATE INFORMATION
		//
		UpdateUsedCardsAndHand (2, index, CurPl); //card type, card number, curPl
		UpdateInfo (log);
		//
		//
	}

	public void Script_2_tk_1 ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = CardDatabase.tk2 + 1;
		int CurPl = PlrData.current_player;
		waitForCompletedAnimation = false;
		waitFor_2_tk_1 = false;
		//
		//
		PlrData.plr_resource [CurPl, 2] = PlrData.plr_resource [CurPl, 2] * 2;

		string log = PlrData.plr_name [CurPl] + " played the card " + CardDatabase.CardLevel2Title [index] + " and doubled the Gold resource.";


		//ALWAYS UPDATE INFORMATION
		//
		UpdateUsedCardsAndHand (2, index, CurPl);
		UpdateInfo (log);
		//
		//
	}

	public void Script_2_tk_2 ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = CardDatabase.tk2 + 2;
		int CurPl = PlrData.current_player;
		waitForCompletedAnimation = false;
		waitFor_2_tk_2 = false;
		//
		//
		PlrData.plr_resource [CurPl, 0] = 1;

		string log = PlrData.plr_name [CurPl] + " played the card " + CardDatabase.CardLevel2Title [index] + " and set the population growth to 1.0.";


		//ALWAYS UPDATE INFORMATION
		//
		UpdateUsedCardsAndHand (2, index, CurPl);
		UpdateInfo (log);
		//
		//
	}

	public void Script_2_tk_3 ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = CardDatabase.tk2 + 3;
		int CurPl = PlrData.current_player;
		waitForCompletedAnimation = false;
		waitFor_2_tk_3 = false;
		//
		//
		int hydrogen_amount = (int)PlrData.plr_resource [CurPl, 3];
		int gold_amount = (int)PlrData.plr_resource [CurPl, 2];
		int profit = hydrogen_amount * 3;
		PlrData.plr_resource [CurPl, 3] = 0;
		PlrData.plr_resource [CurPl, 2] = gold_amount + profit;
		string log = PlrData.plr_name [CurPl] + " played the card " + CardDatabase.CardLevel2Title [index] + " and sold " + hydrogen_amount + " units of Hydrogen for " + profit + " Gold.";


		//ALWAYS UPDATE INFORMATION
		//
		UpdateUsedCardsAndHand (2, index, CurPl);
		UpdateInfo (log);
		//
		//
	}

	public void Script_2_tk_4 ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = CardDatabase.tk2 + 4;
		int CurPl = PlrData.current_player;
		waitForCompletedAnimation = false;
		waitFor_2_tk_4 = false;
		//
		//
		int exomatter_amount = (int)PlrData.plr_resource [CurPl, 4];
		int gold_amount = (int)PlrData.plr_resource [CurPl, 2];
		int profit = exomatter_amount * 5;
		PlrData.plr_resource [CurPl, 4] = 0;
		PlrData.plr_resource [CurPl, 2] = gold_amount + profit;
		string log = PlrData.plr_name [CurPl] + " played the card " + CardDatabase.CardLevel2Title [index] + " and sold " + exomatter_amount + " units of Exomatter for " + profit + " Gold.";


		//ALWAYS UPDATE INFORMATION
		//
		UpdateUsedCardsAndHand (2, index, CurPl);
		UpdateInfo (log);
		//
		//
	}

	public void Script_3_1_throwIntoBlackHole_beforeTargeting ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = 1;
		int CurPl = PlrData.current_player;
		waitForCompletedAnimation = false;
		waitFor_3_1 = false;
		//
		//
		bool blackHoleExistedBefore = false;
		for (int i = 0; i < 4; i++) {
			if (PlrData.plr_used_cards_level3 [i].Contains (13)) { //black hole
				blackHoleExistedBefore = true;
				print ("Throw into black hole: a black hole already exists");
				/*
				// throw into black hole script
				*/
				if (BackgroundSequencingInfo.handIsDisplayed == true) {
					//GameObject.Find ("RightButtonsFromPrefab").GetComponent<HandUpdate> ().DestroyThePreviousOne ();  //if it WAS displayed previously
					Destroy (GameObject.Find ("PrefabHandCanvas(Clone)"));
					BackgroundSequencingInfo.handIsDisplayed = false;
				}	
				GameObject.Find ("Sequencing").GetComponent<CreatePanel> ().CreatePanelChoosePlayer ();
				waitForTargetingPlayer = true;


			} 
		}




		if (blackHoleExistedBefore == false) {
			string log = PlrData.plr_name [CurPl];
			PlrData.plr_resource [CurPl, 5] += 10;
			log += " wanted to throw a player into a black hole, but as it did not exist, the player gained 10 Technology Level";
			UpdateUsedCardsAndHand (3, index, CurPl); //card type, card number, curPl
			UpdateInfo (log);

		}


	}

	public void Script_3_1_throwIntoBlackHole_afterTargeting ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = 1;
		int CurPl = PlrData.current_player;

		print ("throwIntoBlackHole_afterTargeting works");
		PlrData.plr_planet [BackgroundSequencingInfo.targetPlayerChosenNumber].transform.position = new Vector3 (100, 100, 100);
		print ("this doesnt");

		string log = "";
		log += " Threw a player into a black hole.";


		//ALWAYS UPDATE INFORMATION
		//
		UpdateUsedCardsAndHand (3, index, CurPl); //card type, card number, curPl
		UpdateInfo (log);
		//
		//
	}

	public void Script_3_13 ()
	{
		//ALWAYS AT LEAST 4 ELEMENTS
		//
		int index = 13;
		int CurPl = PlrData.current_player;
		waitForCompletedAnimation = false;
		waitFor_3_13 = false;
		//
		//
		bool blackHoleExistedBefore = false;
		for (int i = 0; i < 4; i++) {
			if (PlrData.plr_used_cards_level3 [i].Contains (13)) {
				blackHoleExistedBefore = true;
				print ("a black hole already exists");
			} 
		}
		if (blackHoleExistedBefore == false) {
			GameObject NewBlackHole = Instantiate (PrefabBlackHole, GameObject.Find ("ObjectsFromCards").transform.position, Quaternion.identity);
			NewBlackHole.name = "BlackHole";
		}


		string log = PlrData.plr_name [CurPl];
		if (blackHoleExistedBefore == false) {
			log += " created a black hole.";

		}
		if (blackHoleExistedBefore == true) {
			log += " wanted to create a black hole, but it already exists.";

		}
		//ALWAYS UPDATE INFORMATION
		//
		UpdateUsedCardsAndHand (3, index, CurPl); //card type, card number, curPl
		UpdateInfo (log);
		//
		//
	}
}
