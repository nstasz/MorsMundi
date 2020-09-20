using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseOverpopulationPanel : MonoBehaviour
{

	public void BtnCloseOverpopulationPanel ()
	{
		BackgroundSequencingInfo.anyPanelIsDisplayed = false;
		BackgroundSequencingInfo.NoActionRequieredAnymore ();
		Destroy (gameObject);
	}
}

