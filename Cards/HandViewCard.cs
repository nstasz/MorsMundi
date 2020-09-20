using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandViewCard : MonoBehaviour
{

	public string localCardName;
	public bool CardWannaBeDestroyed;

	public void Start ()
	{
		localCardName = gameObject.name;

	}



	public void HandCardClick ()
	{

		localCardName = gameObject.name;
		print ("From Hand: play the card");
		print (localCardName + "card");
		CurrentCard.IsPlayedFromHand = true;
		CurrentCard.AnimationCompleted = false;
		if (gameObject.tag == "cardlevel1") {
			GameObject.Find (localCardName + "card").GetComponent<CardClickCardLevel1> ().CardClickCardLevel1Script ();
		}
		if (gameObject.tag == "cardlevel2") {
			GameObject.Find (localCardName + "card").GetComponent<CardClickCardLevel2> ().CardClickCardLevel2Script ();
		}
		if (gameObject.tag == "cardlevel3") {
			GameObject.Find (localCardName + "card").GetComponent<CardClickCardLevel3> ().CardClickCardLevel3Script ();
		}
		CurrentCard.IsPlayedFromHand = false;
		//Destroy (GameObject.Find ("PrefabHandCard(Clone)"));
		GameObject.Find ("RightButtonsFromPrefab").GetComponent<HandUpdate> ().HandUpdateScript ();
		GetComponent<Button> ().interactable = false;

	}

	public void OnMouseEnter ()
	{


		GetComponent<Button> ().interactable = true;
		if (gameObject.tag == "cardlevel1") {
			GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel1 (localCardName + "card", int.Parse (localCardName));
		}
		if (gameObject.tag == "cardlevel2") {
			GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel2 (localCardName + "card", int.Parse (localCardName));
		}
		if (gameObject.tag == "cardlevel3") {
			GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel3 (localCardName + "card", int.Parse (localCardName));
		}

		Destroy (GameObject.Find ("ButtonKeepInHand"));
		GameObject.Find (localCardName + "card").GetComponent<Transform> ().transform.position += new Vector3 (320, 0, 0);

	}

	public void DestroyCard ()
	{



		Destroy (GameObject.Find (localCardName + "card"));

	}
}
