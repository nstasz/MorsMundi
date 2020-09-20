using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKeepInHand : MonoBehaviour
{

	public void BtnKeepInHand ()
	{
		if (GameObject.Find ("StandardLevel1Card") != null) {
			GameObject.Find ("StandardLevel1Card").GetComponent<CardClickCardLevel1> ().AddCardToHand (CurrentCard.CurrentAbsoluteCardNumber);
			Destroy (gameObject);
		}
		if (GameObject.Find ("StandardLevel2Card") != null) {
			GameObject.Find ("StandardLevel2Card").GetComponent<CardClickCardLevel2> ().AddCardToHand (CurrentCard.CurrentAbsoluteCardNumber);
			Destroy (gameObject);
		}
		if (GameObject.Find ("StandardLevel3Card") != null) {
			GameObject.Find ("StandardLevel3Card").GetComponent<CardClickCardLevel3> ().AddCardToHand (CurrentCard.CurrentAbsoluteCardNumber);
			Destroy (gameObject);
		}
	}
}
