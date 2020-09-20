using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseStandardPanel : MonoBehaviour
{

	public void BtnCloseStandardPanel ()
	{
		BackgroundSequencingInfo.anyPanelIsDisplayed = false;
		BackgroundSequencingInfo.NoActionRequieredAnymore ();
		Destroy (gameObject);
	}
}

