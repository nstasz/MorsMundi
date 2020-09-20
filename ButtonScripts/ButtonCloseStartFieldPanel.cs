using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseStartFieldPanel : MonoBehaviour
{

	public void BtnCloseStartFieldPanel ()
	{
		BackgroundSequencingInfo.anyPanelIsDisplayed = false;
		BackgroundSequencingInfo.NoActionRequieredAnymore ();
		Destroy (gameObject);
	}
}

