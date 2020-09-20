using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChoosePlayer : MonoBehaviour
{

	public void DestroyPanelChoosePlayer ()
	{
		BackgroundSequencingInfo.ChoosingTargetPlayerStop ();
		Destroy (GameObject.Find ("ChoosePlayerPanelFromPrefab"));
	}


	public void ButtonClickedChosenPlr1 ()
	{
		BackgroundSequencingInfo.targetPlayerChosenNumber = 0;
		DestroyPanelChoosePlayer ();
	}

	public void ButtonClickedChosenPlr2 ()
	{
		BackgroundSequencingInfo.targetPlayerChosenNumber = 1;
		DestroyPanelChoosePlayer ();
	}

	public void ButtonClickedChosenPlr3 ()
	{
		BackgroundSequencingInfo.targetPlayerChosenNumber = 2;
		DestroyPanelChoosePlayer ();
	}

	public void ButtonClickedChosenPlr4 ()
	{
		BackgroundSequencingInfo.targetPlayerChosenNumber = 3;
		DestroyPanelChoosePlayer ();
	}



}
