using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandUpdate : MonoBehaviour
{

	public  GameObject LocalHandPanel;
	public  GameObject LocalHandCard;


	public  void HandUpdateScript ()
	{

		if (BackgroundSequencingInfo.choosingTargetPlrActive == false) {
			if (CurrentCard.WillRemainInHand == false) {


				DestroyThePreviousOne ();
				CreateAPanel ();
				DisplayCardsInHand ();
				//GameObject newPanel = Instantiate (LocalHandPanel, Vector3.zero, Quaternion.identity);

				//GameObject.Find ("PrefabHandCanvas(Clone)").SetActive (true);

		
			}
			CurrentCard.WillRemainInHand = false;
		}

	}

	public  void DestroyThePreviousOne ()
	{
		/*
		if (GameObject.Find ("PrefabHandCanvas(Clone)") != null) {
			print ("It exists");

			GameObject.Find ("PrefabHandCanvas(Clone)").SetActive (false);

		}
		*/

		if (BackgroundSequencingInfo.handIsDisplayed == true) {
			GameObject.Find ("PrefabHandCanvas(Clone)").SetActive (false);
			foreach (Transform child in GameObject.Find("HandPanels").transform) {
				GameObject.Destroy (child.gameObject);
			}
		}
	}

	public  void CreateAPanel ()
	{ 

		GameObject newPanel = Instantiate (LocalHandPanel, Vector3.zero, Quaternion.identity);
		newPanel.transform.SetParent (GameObject.Find ("HandPanels").transform);
		BackgroundSequencingInfo.handIsDisplayed = true;



		/*
	
		if (GameObject.Find ("PrefabHandCanvas(Clone)") == null) {
			print ("It exists");

			Instantiate (LocalHandPanel, Vector3.zero, Quaternion.identity);
			FirstWasCreated = true;
		}
		*/
	}

	public void DisplayCardsInHand ()
	{
		foreach (int item in PlrData.plr_hand_level1[PlrData.current_player]) {
			var CardMiniImage = Instantiate (LocalHandCard, Vector3.zero, Quaternion.identity);
			string itemAsString = item.ToString ();
			//print ("itemAsString: " + itemAsString);

			CardMiniImage.transform.SetParent (GameObject.Find ("LayoutHelperGrid").transform);
			CardMiniImage.tag = "cardlevel1";
			GameObject.Find ("HandCardArt").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Art/" + CardDatabase.CardLevel1Art [item]) as Texture;
			GameObject.Find ("HandCardArt").tag = "cardlevel1";
			GameObject.Find ("HandCardArt").name = itemAsString;
			GameObject.Find ("HandCardBorder").GetComponent<RawImage> ().color = Color.blue;
			GameObject.Find ("HandCardBorder").name += "Nr" + itemAsString;
			GameObject.Find ("TextBg").GetComponent<Image> ().color = Color.blue;
			GameObject.Find ("TextBg").name += "Nr" + itemAsString;
			GameObject.Find ("HandCardTextLabel").GetComponent<Text> ().text = CardDatabase.CardLevel1Title [item];
			GameObject.Find ("HandCardTextLabel").GetComponent<Text> ().color = Color.white;
			GameObject.Find ("HandCardTextLabel").name = CardDatabase.CardLevel1Title [item];
		}
		foreach (int item in PlrData.plr_hand_level2[PlrData.current_player]) {
			var CardMiniImage = Instantiate (LocalHandCard, Vector3.zero, Quaternion.identity);
			string itemAsString = item.ToString ();


			CardMiniImage.transform.SetParent (GameObject.Find ("LayoutHelperGrid").transform);
			CardMiniImage.tag = "cardlevel2";
			GameObject.Find ("HandCardArt").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Art/" + CardDatabase.CardLevel2Art [item]) as Texture;
			GameObject.Find ("HandCardArt").tag = "cardlevel2";
			GameObject.Find ("HandCardArt").name = itemAsString;
			GameObject.Find ("HandCardBorder").GetComponent<RawImage> ().color = Color.red;
			GameObject.Find ("HandCardBorder").name += "Nr" + itemAsString;
			GameObject.Find ("TextBg").GetComponent<Image> ().color = Color.red;
			GameObject.Find ("TextBg").name += "Nr" + itemAsString;
			GameObject.Find ("HandCardTextLabel").GetComponent<Text> ().text = CardDatabase.CardLevel2Title [item];
			GameObject.Find ("HandCardTextLabel").GetComponent<Text> ().color = Color.white;
			GameObject.Find ("HandCardTextLabel").name = CardDatabase.CardLevel2Title [item];
		}
		foreach (int item in PlrData.plr_hand_level3[PlrData.current_player]) {
			var CardMiniImage = Instantiate (LocalHandCard, Vector3.zero, Quaternion.identity);
			string itemAsString = item.ToString ();


			CardMiniImage.transform.SetParent (GameObject.Find ("LayoutHelperGrid").transform);
			CardMiniImage.tag = "cardlevel3";
			GameObject.Find ("HandCardArt").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Art/" + CardDatabase.CardLevel3Art [item]) as Texture;
			GameObject.Find ("HandCardArt").tag = "cardlevel3";
			GameObject.Find ("HandCardArt").name = itemAsString;
			GameObject.Find ("HandCardBorder").GetComponent<RawImage> ().color = Color.black;
			GameObject.Find ("HandCardBorder").name += "Nr" + itemAsString;
			GameObject.Find ("TextBg").GetComponent<Image> ().color = Color.black;
			GameObject.Find ("TextBg").name += "Nr" + itemAsString;
			GameObject.Find ("HandCardTextLabel").GetComponent<Text> ().text = CardDatabase.CardLevel3Title [item];
			GameObject.Find ("HandCardTextLabel").GetComponent<Text> ().color = Color.white;
			GameObject.Find ("HandCardTextLabel").name = CardDatabase.CardLevel3Title [item];
		}
	}
}
