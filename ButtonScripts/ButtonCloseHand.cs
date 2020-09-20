using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCloseHand : MonoBehaviour
{

	public void BtnCloseHand ()
	{

		GameObject.Find ("ButtonShowHand").GetComponent<Button> ().interactable = true;
		BackgroundSequencingInfo.handIsDisplayed = false;
		BackgroundSequencingInfo.anyPanelIsDisplayed = false;
		BackgroundSequencingInfo.NoActionRequieredAnymore ();
		Destroy (gameObject);
	}
}

