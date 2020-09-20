using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFieldYellow : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
	{
		if (BackgroundSequencingInfo.turnCount > BackgroundSequencingInfo.initialNumberOfTurnsBeforeActivation) {
			print ("OnTriggerEnterYellow");

			BackgroundSequencingInfo.AwaitAction (); // disables the NEXT PLAYER button

			BackgroundSequencingInfo.YellowFieldWaitsForActivation (); //waits till the step rotation is completed, which then activates via BSI the FieldAction for StartField.
		}
	}
	//void OnTriggerStay(Collider other) //niepotrzebne
	//{
	//Debug.Log("Object stays");

	//}
	//void OnTriggerExit(Collider other) //niepotrzebne
	//{
	//Debug.Log("Object exits");

	//}
}
