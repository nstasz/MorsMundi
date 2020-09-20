using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFieldRed : MonoBehaviour
{

	public void OnTriggerEnter ()
	{


		if (BackgroundSequencingInfo.turnCount > BackgroundSequencingInfo.initialNumberOfTurnsBeforeActivation) {
			print ("OnTriggerEnterRed");

			BackgroundSequencingInfo.AwaitAction (); // disables the NEXT PLAYER button

			BackgroundSequencingInfo.RedFieldWaitsForActivation (); //waits till the step rotation is completed, which then activates via BSI the FieldAction for StartField.

		}
	}
}
