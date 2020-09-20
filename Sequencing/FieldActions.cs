using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldActions : MonoBehaviour
{
	public GameObject CardBack1;
	public GameObject CardBack2;
	public GameObject CardBack3;

	public void BlueFieldAction ()
	{
		print ("BlueFieldAction");

		if ((CardDatabase.ValidCardsLevel1.Count == 0) && (CardDatabase.ValidCardsLevel2.Count == 0) && (CardDatabase.ValidCardsLevel3.Count == 0)) {
			// If there are NO MORE lvl1 AND lvl2 AND lvl3 cards, make them all available again!
			for (int i = 0; i < (CardDatabase.CardLevel1PlayableTotalCount); i++) {
				CardDatabase.ValidCardsLevel1.Add (i);
			}
			for (int i = 0; i < (CardDatabase.CardLevel2PlayableTotalCount); i++) {
				CardDatabase.ValidCardsLevel2.Add (i);
			}
			for (int i = 0; i < (CardDatabase.CardLevel3PlayableTotalCount); i++) {
				CardDatabase.ValidCardsLevel3.Add (i);
			}

		}

		if (CardDatabase.ValidCardsLevel1.Count > 0) {
			var NewCardBack1 = Instantiate (CardBack1, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
			NewCardBack1.transform.SetParent (GameObject.Find ("CardCanvas").transform); // in other words: Display on Canvas
			NewCardBack1.transform.position = GameObject.Find ("CardCanvas").transform.position + new Vector3 (-350, 0, 0);
			NewCardBack1.name = "CardBackLevel1";
		}

		if (CardDatabase.ValidCardsLevel2.Count > 0) {
			var NewCardBack2 = Instantiate (CardBack2, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
			NewCardBack2.transform.SetParent (GameObject.Find ("CardCanvas").transform);
			NewCardBack2.transform.position = GameObject.Find ("CardCanvas").transform.position; //+ new Vector3(0, 0, 0);
			NewCardBack2.name = "CardBackLevel2";
		}

		if (CardDatabase.ValidCardsLevel3.Count > 0) {
			var NewCardBack3 = Instantiate (CardBack3, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
			NewCardBack3.transform.SetParent (GameObject.Find ("CardCanvas").transform);
			NewCardBack3.transform.position = GameObject.Find ("CardCanvas").transform.position + new Vector3 (350, 0, 0);
			NewCardBack3.name = "CardBackLevel3";
		}
	}

	public void RedFieldAction ()
	{
		GameObject.Find ("Cards").GetComponent<BargainCreateDisplay> ().BargainMainScript ();

	}

	public void StartFieldAction ()
	{
		GameObject.Find ("Sequencing").GetComponent<CreatePanel> ().CreateStartFieldPanel ();

	}

	public void YellowFieldAction ()
	{
		GameObject.Find ("Cards").GetComponent<YellowCreateDisplay> ().YellowMainScript ();

	}
}
