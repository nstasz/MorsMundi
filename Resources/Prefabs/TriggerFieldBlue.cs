using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFieldBlue : MonoBehaviour
{







	public void OnTriggerEnter ()
	{
		

		if (BackgroundSequencingInfo.turnCount > BackgroundSequencingInfo.initialNumberOfTurnsBeforeActivation) {
			print ("OnTriggerEnter");

			BackgroundSequencingInfo.AwaitAction (); // disables the NEXT PLAYER button

			BackgroundSequencingInfo.BlueFieldWaitsForActivation (); //waits till the step rotation is completed, which then activates via BSI the FieldAction for BlueField.

		}
	}


	//void OnTriggerStay(Collider other) // not needed
	//{
	//Debug.Log("Object stays");

	//}
	//void OnTriggerExit(Collider other) // not needed
	//{
	//Debug.Log("Object exits");

	//}
}
