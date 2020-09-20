using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSequencingInfo : MonoBehaviour
{
	static public int turnCount;
	static public bool actionIsRequired;
	static public bool planetStepCompleted;
	static public bool blueFieldWaits;
	static public bool redFieldWaits;
	static public bool startFieldWaits;
	static public bool yellowFieldWaits;

	static public bool handIsDisplayed;
	static public bool anyPanelIsDisplayed;

	static public bool cardDestructionAnimationDisplayed;

	public static int initialNumberOfTurnsBeforeActivation;

	static public bool choosingTargetPlrActive;
	static public int targetPlayerChosenNumber;

	static public bool onYellowFieldNow;
	// will disable playing cards, adding cards to hand, generating cards from cardbacks and maybe more

	void Start ()
	{
		turnCount = 0;
		actionIsRequired = false;

		planetStepCompleted = false;

		blueFieldWaits = false;
		redFieldWaits = false;
		startFieldWaits = false;
		yellowFieldWaits = false;
		handIsDisplayed = false;
		anyPanelIsDisplayed = false;

			
		initialNumberOfTurnsBeforeActivation = PlrData.plr_total_count - 1;
		choosingTargetPlrActive = false;
		targetPlayerChosenNumber = 5;
		onYellowFieldNow = false;

	}

	void LateUpdate ()
	{
		if (planetStepCompleted == true) {
			if (anyPanelIsDisplayed == false) {
				if (blueFieldWaits == true) {
					if (PlrData.plr_alive [PlrData.current_player] == true) {
						AwaitAction (); //because sometimes panels delete it
						GameObject.Find ("Sequencing").GetComponent<FieldActions> ().BlueFieldAction ();
						print ("Starting BlueFieldAction");
						blueFieldWaits = false;
					} else {
						NoActionRequieredAnymore ();
						blueFieldWaits = false;
					}
				}
				if (redFieldWaits == true) {
					if (PlrData.plr_alive [PlrData.current_player] == true) {
						AwaitAction ();
						GameObject.Find ("Sequencing").GetComponent<FieldActions> ().RedFieldAction ();
						print ("Starting RedFieldAction");
						redFieldWaits = false;
					} else {
						NoActionRequieredAnymore ();
						redFieldWaits = false;
					}
				}
				if (startFieldWaits == true) {
					if (PlrData.plr_alive [PlrData.current_player] == true) {
						AwaitAction ();
						GameObject.Find ("Sequencing").GetComponent<FieldActions> ().StartFieldAction ();
						print ("Starting StartFieldAction");
						startFieldWaits = false;
					} else {
						NoActionRequieredAnymore ();
						startFieldWaits = false;
					}
				}
				if (yellowFieldWaits == true) {
					if (PlrData.plr_alive [PlrData.current_player] == true) {
						AwaitAction ();
						GameObject.Find ("Sequencing").GetComponent<FieldActions> ().YellowFieldAction ();
						print ("Starting YellowFieldAction");
						yellowFieldWaits = false;
					} else {
						NoActionRequieredAnymore ();
						yellowFieldWaits = false;
					}
				}
			}
		}


	}

	public static void AwaitAction ()
	{
		actionIsRequired = true;
		if (GameObject.Find ("ButtonNextPlayer") != null) {
			GameObject.Find ("ButtonNextPlayer").GetComponent<Button> ().interactable = false;
		}
		if (GameObject.Find ("ButtonShowHand") != null) {
			GameObject.Find ("ButtonShowHand").GetComponent<Button> ().interactable = false;
		}
		if (GameObject.Find ("ButtonLog") != null) { 
			GameObject.Find ("ButtonLog").GetComponent<Button> ().interactable = false;
		}
	}

	public static void NoActionRequieredAnymore ()
	{
		actionIsRequired = false;
		if (GameObject.Find ("ButtonNextPlayer") != null) {
			GameObject.Find ("ButtonNextPlayer").GetComponent<Button> ().interactable = true;
		}
		if (GameObject.Find ("ButtonShowHand") != null) {
			GameObject.Find ("ButtonShowHand").GetComponent<Button> ().interactable = true;
		}
		if (GameObject.Find ("ButtonLog") != null) { 
			GameObject.Find ("ButtonLog").GetComponent<Button> ().interactable = true;
		}
		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();
	}

	public static void BlueFieldWaitsForActivation ()
	{
		blueFieldWaits = true;
	}

	public static void RedFieldWaitsForActivation ()
	{
		redFieldWaits = true;
	}

	public static void StartFieldWaitsForActivation ()
	{
		startFieldWaits = true;
	}

	public static void YellowFieldWaitsForActivation ()
	{
		yellowFieldWaits = true;
	}


	public static void ChoosingTargetPlayerStart ()
	{
		AwaitAction ();
		choosingTargetPlrActive = true;
	}

	public static void ChoosingTargetPlayerStop ()
	{
		NoActionRequieredAnymore ();
		choosingTargetPlrActive = false;
	}
}
