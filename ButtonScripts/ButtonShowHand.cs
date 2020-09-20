using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShowHand : MonoBehaviour
{



	public void BtnShowHand ()
	{
		BackgroundSequencingInfo.AwaitAction ();
		//GameObject.Find ("ButtonShowHand").GetComponent<Button> ().interactable = false;

		GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "Cards in hand. Choose a card to play it.";



		GameObject.Find ("ButtonsOnTheRight").GetComponent<HandUpdate> ().HandUpdateScript ();
			


	}
}
