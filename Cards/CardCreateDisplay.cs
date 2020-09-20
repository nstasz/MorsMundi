using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCreateDisplay : MonoBehaviour
{


	public GameObject PrefabCardLevel1Local;
	public GameObject PrefabCardLevel2Local;
	public GameObject PrefabCardLevel3Local;
	public GameObject FromPrefabButtonKeepInHand;

	public void CreateCardLevel1 (string newPrefabName, int cardNumber)
	{
		GameObject NewCard = Instantiate (PrefabCardLevel1Local, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
		NewCard.transform.SetParent (GameObject.Find ("CardCanvas").transform); // in other words: Display on Canvas
		NewCard.transform.position = GameObject.Find ("CardCanvas").transform.position; // + new Vector3(0, 0, 0);
		NewCard.name = newPrefabName;
       

		GameObject.Find (NewCard.name + "/CardLevel1Name").GetComponent<Text> ().text = CardDatabase.CardLevel1Title [cardNumber];
		GameObject.Find (NewCard.name + "/CardLevel1Description").GetComponent<Text> ().text = CardDatabase.CardLevel1Description [cardNumber];
		GameObject.Find (NewCard.name + "/CardLevel1Art").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Art/" + CardDatabase.CardLevel1Art [cardNumber]) as Texture;
		GameObject.Find (NewCard.name + "/CardLevel1ReqImage").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + CardDatabase.CardLevel1ReqName [cardNumber]) as Texture;
		GameObject.Find (NewCard.name + "/CardLevel1ReqText").GetComponent<Text> ().text = CardDatabase.CardLevel1ReqCost [cardNumber].ToString ();
		GameObject.Find (NewCard.name + "/CardLevel1GrantsImage").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + CardDatabase.CardLevel1GrantsName [cardNumber]) as Texture;
		GameObject.Find (NewCard.name + "/CardLevel1GrantsText").GetComponent<Text> ().text = CardDatabase.CardLevel1GrantsCost [cardNumber].ToString ();
		GameObject.Find (NewCard.name + "/CardLevel1CardNumber").GetComponent<Text> ().text = cardNumber.ToString ();
	}

	public void CreateCardLevel2 (string newPrefabName, int cardNumber)
	{
		
		GameObject NewCard = Instantiate (PrefabCardLevel2Local, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
		NewCard.transform.SetParent (GameObject.Find ("CardCanvas").transform); // in other words: Display on Canvas
		NewCard.transform.position = GameObject.Find ("CardCanvas").transform.position; // + new Vector3(0, 0, 0);
		NewCard.name = newPrefabName;


		GameObject.Find (NewCard.name + "/CardLevel2Name").GetComponent<Text> ().text = CardDatabase.CardLevel2Title [cardNumber];
		GameObject.Find (NewCard.name + "/CardLevel2Description").GetComponent<Text> ().text = CardDatabase.CardLevel2Description [cardNumber];
		GameObject.Find (NewCard.name + "/CardLevel2Art").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Art/" + CardDatabase.CardLevel2Art [cardNumber]) as Texture;
		if (CardDatabase.CardLevel2HasReq [cardNumber] == true) {
			//print ("It has a req");
			GameObject.Find (NewCard.name + "/CardLevel2Req1Image").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + CardDatabase.CardLevel2Req1Name [cardNumber]) as Texture;
			GameObject.Find (NewCard.name + "/CardLevel2Req1Text").GetComponent<Text> ().text = CardDatabase.CardLevel2Req1Cost [cardNumber].ToString ();
			GameObject.Find (NewCard.name + "/CardLevel2Req2Image").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + CardDatabase.CardLevel2Req2Name [cardNumber]) as Texture;
			GameObject.Find (NewCard.name + "/CardLevel2Req2Text").GetComponent<Text> ().text = CardDatabase.CardLevel2Req2Cost [cardNumber].ToString ();
			if (CardDatabase.CardLevel2Req1Name [cardNumber] > 6) {
				GameObject.Find (NewCard.name + "/CardLevel2Req1Image").GetComponent<RawImage> ().color = Shortcuts.colorDarkRed;
				GameObject.Find (NewCard.name + "/CardLevel2Req1Text").GetComponent<Text> ().color = Shortcuts.colorDarkRed;
			}
			if (CardDatabase.CardLevel2Req2Name [cardNumber] > 6) {
				GameObject.Find (NewCard.name + "/CardLevel2Req2Image").GetComponent<RawImage> ().color = Shortcuts.colorDarkRed;
				GameObject.Find (NewCard.name + "/CardLevel2Req2Text").GetComponent<Text> ().color = Shortcuts.colorDarkRed;
			}
		} else {
			//print ("It does not have a req");
			Destroy (GameObject.Find (NewCard.name + "/CardLevel2Req1Image"));
			Destroy (GameObject.Find (NewCard.name + "/CardLevel2Req1Text"));
			Destroy (GameObject.Find (NewCard.name + "/CardLevel2Req2Image"));
			Destroy (GameObject.Find (NewCard.name + "/CardLevel2Req2Text"));
		}
		if (CardDatabase.CardLevel2DisplayGrants [cardNumber] == true) {
			GameObject.Find (NewCard.name + "/CardLevel2GrantsImage").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + CardDatabase.CardLevel2GrantsName [cardNumber]) as Texture;
			GameObject.Find (NewCard.name + "/CardLevel2GrantsText").GetComponent<Text> ().text = CardDatabase.CardLevel2GrantsCost [cardNumber].ToString ();
			if (CardDatabase.CardLevel2GrantsName [cardNumber] > 6) {
				GameObject.Find (NewCard.name + "/CardLevel2GrantsImage").GetComponent<RawImage> ().color = Shortcuts.colorDarkRed;
				GameObject.Find (NewCard.name + "/CardLevel2GrantsText").GetComponent<Text> ().color = Shortcuts.colorDarkRed;
			}
		} else {
			Destroy (GameObject.Find (NewCard.name + "/CardLevel2GrantsImage"));
			Destroy (GameObject.Find (NewCard.name + "/CardLevel2GrantsText"));
		}
		GameObject.Find (NewCard.name + "/CardLevel2CardNumber").GetComponent<Text> ().text = cardNumber.ToString ();
	}

	public void CreateCardLevel3 (string newPrefabName, int cardNumber)
	{
		GameObject NewCard = Instantiate (PrefabCardLevel3Local, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
		NewCard.transform.SetParent (GameObject.Find ("CardCanvas").transform); // in other words: Display on Canvas
		NewCard.transform.position = GameObject.Find ("CardCanvas").transform.position; // + new Vector3(0, 0, 0);
		NewCard.name = newPrefabName;


		GameObject.Find (NewCard.name + "/CardLevel3Name").GetComponent<Text> ().text = CardDatabase.CardLevel3Title [cardNumber];
		GameObject.Find (NewCard.name + "/CardLevel3Description").GetComponent<Text> ().text = CardDatabase.CardLevel3Description [cardNumber];
		GameObject.Find (NewCard.name + "/CardLevel3Art").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Art/" + CardDatabase.CardLevel3Art [cardNumber]) as Texture;
		if (CardDatabase.CardLevel3HasReq [cardNumber] == true) {
			//print ("It has a req");
			GameObject.Find (NewCard.name + "/CardLevel3Req1Image").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + CardDatabase.CardLevel3Req1Name [cardNumber]) as Texture;
			GameObject.Find (NewCard.name + "/CardLevel3Req1Text").GetComponent<Text> ().text = CardDatabase.CardLevel3Req1Cost [cardNumber].ToString ();
			GameObject.Find (NewCard.name + "/CardLevel3Req2Image").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + CardDatabase.CardLevel3Req2Name [cardNumber]) as Texture;
			GameObject.Find (NewCard.name + "/CardLevel3Req2Text").GetComponent<Text> ().text = CardDatabase.CardLevel3Req2Cost [cardNumber].ToString ();
			if (CardDatabase.CardLevel3Req1Name [cardNumber] > 6) {
				GameObject.Find (NewCard.name + "/CardLevel3Req1Image").GetComponent<RawImage> ().color = Shortcuts.colorDarkRed;
				GameObject.Find (NewCard.name + "/CardLevel3Req1Text").GetComponent<Text> ().color = Shortcuts.colorDarkRed;
			}
			if (CardDatabase.CardLevel3Req2Name [cardNumber] > 6) {
				GameObject.Find (NewCard.name + "/CardLevel3Req2Image").GetComponent<RawImage> ().color = Shortcuts.colorDarkRed;
				GameObject.Find (NewCard.name + "/CardLevel3Req2Text").GetComponent<Text> ().color = Shortcuts.colorDarkRed;
			}
		} else {
			//print ("It does not have a req");
			Destroy (GameObject.Find (NewCard.name + "/CardLevel3Req1Image"));
			Destroy (GameObject.Find (NewCard.name + "/CardLevel3Req1Text"));
			Destroy (GameObject.Find (NewCard.name + "/CardLevel3Req2Image"));
			Destroy (GameObject.Find (NewCard.name + "/CardLevel3Req2Text"));
		}
		if (CardDatabase.CardLevel3DisplayGrants [cardNumber] == true) {
			GameObject.Find (NewCard.name + "/CardLevel3GrantsImage").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + CardDatabase.CardLevel3GrantsName [cardNumber]) as Texture;
			GameObject.Find (NewCard.name + "/CardLevel3GrantsText").GetComponent<Text> ().text = CardDatabase.CardLevel3GrantsCost [cardNumber].ToString ();
			if (CardDatabase.CardLevel3GrantsName [cardNumber] > 6) {
				GameObject.Find (NewCard.name + "/CardLevel3GrantsImage").GetComponent<RawImage> ().color = Shortcuts.colorDarkRed;
				GameObject.Find (NewCard.name + "/CardLevel3GrantsText").GetComponent<Text> ().color = Shortcuts.colorDarkRed;
			}
		} else {
			Destroy (GameObject.Find (NewCard.name + "/CardLevel3GrantsImage"));
			Destroy (GameObject.Find (NewCard.name + "/CardLevel3GrantsText"));
		}
		GameObject.Find (NewCard.name + "/CardLevel3CardNumber").GetComponent<Text> ().text = cardNumber.ToString ();
	}

	public void CreateButtonKeepInHand ()
	{
		GameObject NewButtonKeepInHand = Instantiate (FromPrefabButtonKeepInHand, GameObject.Find ("CardCanvas").transform.position, Quaternion.identity);
		NewButtonKeepInHand.transform.SetParent (GameObject.Find ("CardCanvas").transform); // in other words: Display on Canvas
		NewButtonKeepInHand.transform.position = GameObject.Find ("CardCanvas").transform.position + new Vector3 (0, -300, 0);
		NewButtonKeepInHand.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
		NewButtonKeepInHand.name = "ButtonKeepInHand";


	}
}
