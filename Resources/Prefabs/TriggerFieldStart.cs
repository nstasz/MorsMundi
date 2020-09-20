using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFieldStart : MonoBehaviour
{

	public void OnTriggerEnter ()
	{


		if (BackgroundSequencingInfo.turnCount > BackgroundSequencingInfo.initialNumberOfTurnsBeforeActivation) {
			print ("OnTriggerEnter");

			BackgroundSequencingInfo.AwaitAction (); // disables the NEXT PLAYER button

			BackgroundSequencingInfo.StartFieldWaitsForActivation (); //waits till the step rotation is completed, which then activates via BSI the FieldAction for StartField.

		}
	}
}
