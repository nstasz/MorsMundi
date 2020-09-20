using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowCreateDisplay : MonoBehaviour
{

	//public GameObject YellowFromPrefab;

	public int CurPl;
	public int[] optionnumber;

	public GameObject CardBack1;
	public GameObject CardBack2;
	public GameObject CardBack3;
	/*
	public GameObject YellowFieldLeftCard;
	public GameObject YellowFieldMiddleCard;
	public GameObject YellowFieldRightCard;
*/
	public void YellowMainScript ()
	{
		print ("starting yellow script");
		CurPl = PlrData.current_player;
		BackgroundSequencingInfo.onYellowFieldNow = true;
		RandomizeTypeOfCards ();

		UpdateCardsAndButtons ();

	}

	public void RandomizeTypeOfCards ()
	{
		
		optionnumber = new int[3] { 666, 666, 666 };
		string YellowFieldCurrentCardName = "BUG in card name";
		for (int i = 0; i < 3; i++) { // 3 is exclusive
			// POPRAWNE:	optionnumber [i] = Random.Range (0, 4); // 4 is exclusive
			//
			//TEST
			optionnumber [i] = Random.Range (0, 1); 
			// /TEST


			if (optionnumber [i] == 0) {
				// A random card Level 1-3, YOU CAN SEE THE CONTENT
				int optionLevelOfTheCard = Random.Range (1, 4);
				if (i == 0) {
					YellowFieldCurrentCardName = "YellowField1Card";
				}
				if (i == 1) {
					YellowFieldCurrentCardName = "YellowField2Card";
				}
				if (i == 2) {
					YellowFieldCurrentCardName = "YellowField3Card";
				}
				int NewCardNumber = 0;
				if (optionLevelOfTheCard == 1) {
					NewCardNumber = CardDatabase.ValidCardsLevel1 [Random.Range (0, CardDatabase.ValidCardsLevel1.Count)];
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel1 (YellowFieldCurrentCardName, NewCardNumber);
					Destroy (GameObject.Find ("ButtonKeepInHand"));
				}
				if (optionLevelOfTheCard == 2) { 
					NewCardNumber = CardDatabase.ValidCardsLevel2 [Random.Range (0, CardDatabase.ValidCardsLevel2.Count)];
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel2 (YellowFieldCurrentCardName, NewCardNumber);
					Destroy (GameObject.Find ("ButtonKeepInHand"));
				}
				if (optionLevelOfTheCard == 3) {
					NewCardNumber = CardDatabase.ValidCardsLevel3 [Random.Range (0, CardDatabase.ValidCardsLevel3.Count)];
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel3 (YellowFieldCurrentCardName, NewCardNumber);
					Destroy (GameObject.Find ("ButtonKeepInHand"));
				}

			}
			if (optionnumber [i] == 1) {
				// A card back for a technology card, it is hidden, you only see the cardback!
				int optionLevelOfTheCard = Random.Range (1, 4);
				int NewCardNumber = 0;
				if (optionLevelOfTheCard == 1) {
					var NewCardBack1 = Instantiate (CardBack1, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
					NewCardBack1.transform.SetParent (GameObject.Find ("CardCanvas").transform); // in other words: Display on Canvas
					NewCardBack1.transform.position = GameObject.Find ("CardCanvas").transform.position;
					NewCardBack1.name = YellowFieldCurrentCardName;
				}
				if (optionLevelOfTheCard == 2) { 
					var NewCardBack2 = Instantiate (CardBack2, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
					NewCardBack2.transform.SetParent (GameObject.Find ("CardCanvas").transform); // in other words: Display on Canvas
					NewCardBack2.transform.position = GameObject.Find ("CardCanvas").transform.position; //+ new Vector3 (-350, 0, 0);
					NewCardBack2.name = YellowFieldCurrentCardName;
				}
				if (optionLevelOfTheCard == 3) {
					var NewCardBack3 = Instantiate (CardBack3, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
					NewCardBack3.transform.SetParent (GameObject.Find ("CardCanvas").transform);
					NewCardBack3.transform.position = GameObject.Find ("CardCanvas").transform.position;
					NewCardBack3.name = YellowFieldCurrentCardName;
				}


			}
			if (optionnumber [i] == 2) {
				// A random resource
				int optionRandomResource = Random.Range (0, 7);
				float optionRandomResourceSize;
				if (optionRandomResource == 0) { // population growth
					optionRandomResourceSize = Random.Range (0.1f, 1f);
				}
				if (optionRandomResource == 1) { // population
					optionRandomResourceSize = Random.Range (1, 1000);
				}

				if (optionRandomResource == 2) { // gold
					optionRandomResourceSize = Random.Range (1, 10);
				}

				if (optionRandomResource == 3) { // hydrogen
					optionRandomResourceSize = Random.Range (1, 5);
				}

				if (optionRandomResource == 4) { // exomatter
					optionRandomResourceSize = Random.Range (1, 5);
				}

				if (optionRandomResource == 5) { // energy level
					optionRandomResourceSize = Random.Range (1, 3);
				}

				if (optionRandomResource == 6) { // technology level
					optionRandomResourceSize = Random.Range (1, 3);
				}
			}
			if (optionnumber [i] == 3) {
				// A random YellowCard
				///int optionRandomYellowCard = Random.Range (0, liczbazoltychkart+1);
				print ("OPTION YELLOW CARD");

			}
			print ("Option numbers:" + optionnumber [0] + ", " + optionnumber [1] + ", " + optionnumber [2] + ", ");


		}
		GameObject.Find ("YellowField1Card").transform.position += new Vector3 (-350, 0, 0);
		//GameObject.Find("YellowField2Card").transform.position +=  + new Vector3 (-0, 0, 0);
		GameObject.Find ("YellowField3Card").transform.position += new Vector3 (350, 0, 0);
	}


	public void UpdateCardsAndButtons ()
	{
	}
}