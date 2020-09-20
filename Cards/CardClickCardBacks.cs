using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardClickCardBacks: MonoBehaviour
{
	public AudioSource MyAudioSource;
	public AudioClip sound_card_ok;

	public void CardClickCardBackLevel1 ()
	{
		MyAudioSource = GetComponent<AudioSource> ();
		MyAudioSource.PlayOneShot (sound_card_ok);
		if (BackgroundSequencingInfo.onYellowFieldNow == false) {
			GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "chose a Level 1 card";
        
			if (GameObject.Find ("CardBackLevel2") != null) {
				GameObject.Find ("CardBackLevel2").GetComponent<CardClickCardBacks> ().destruction_of_this_card = true; 
			}
			if (GameObject.Find ("CardBackLevel3") != null) {
				GameObject.Find ("CardBackLevel3").GetComponent<CardClickCardBacks> ().destruction_of_this_card = true;
			}
			card1_selected = true;
			selecton_rotation_card_enabled = true;
		} else {
			// to be completed!
			BackgroundSequencingInfo.onYellowFieldNow = false;
			Destroy (gameObject);
		}
	}

	public void CardClickCardBackLevel2 ()
	{
		MyAudioSource = GetComponent<AudioSource> ();
		MyAudioSource.PlayOneShot (sound_card_ok);
		if (BackgroundSequencingInfo.onYellowFieldNow == false) {

			GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "chose a Level 2 card";

			if (GameObject.Find ("CardBackLevel1") != null) {
				GameObject.Find ("CardBackLevel1").GetComponent<CardClickCardBacks> ().destruction_of_this_card = true;
			}
			if (GameObject.Find ("CardBackLevel3") != null) {
				GameObject.Find ("CardBackLevel3").GetComponent<CardClickCardBacks> ().destruction_of_this_card = true;
			}
			card2_selected = true;
			selecton_rotation_card_enabled = true;
		} else {
			// to be completed!
			BackgroundSequencingInfo.onYellowFieldNow = false;
			Destroy (gameObject);
		}
	}

	public void CardClickCardBackLevel3 ()
	{
		MyAudioSource = GetComponent<AudioSource> ();
		MyAudioSource.PlayOneShot (sound_card_ok);
		if (BackgroundSequencingInfo.onYellowFieldNow == false) {
			GameObject.Find ("PlayerRewardInfo").GetComponent<Text> ().text = "chose a Level 3 card";

			if (GameObject.Find ("CardBackLevel1") != null) {
				GameObject.Find ("CardBackLevel1").GetComponent<CardClickCardBacks> ().destruction_of_this_card = true;
			}
			if (GameObject.Find ("CardBackLevel2") != null) {
				GameObject.Find ("CardBackLevel2").GetComponent<CardClickCardBacks> ().destruction_of_this_card = true;
			}
			card3_selected = true;
			selecton_rotation_card_enabled = true;
		} else {
			// to be completed!
			BackgroundSequencingInfo.onYellowFieldNow = false;
			Destroy (gameObject);
		}
	}

	bool selecton_rotation_card_enabled = false;
	bool card1_selected = false;
	bool card2_selected = false;
	bool card3_selected = false;
	bool destruction_of_this_card = false;
	float time_passed = 0;
    
	int NewCardNumber;



	public void Update ()
	{

		if (selecton_rotation_card_enabled == true) {
   
			transform.Rotate (new Vector3 (0, 1, 0), 180f * Time.deltaTime); //rotate by 180 degrees in one 1 second
			time_passed += Time.deltaTime;
            


			if (time_passed > 0.5f) { // if half a second has passed... 
				

				if (card1_selected == true) {
					
					NewCardNumber = CardDatabase.ValidCardsLevel1 [Random.Range (0, CardDatabase.ValidCardsLevel1.Count)];

					CurrentCard.CurrentAbsoluteCardNumber = NewCardNumber;
					CurrentCard.CurrentCardType = 0;
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel1 ("StandardLevel1Card", NewCardNumber);
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateButtonKeepInHand ();
					Destroy (gameObject);
				}
				if (card2_selected == true) {
					NewCardNumber = CardDatabase.ValidCardsLevel2 [Random.Range (0, CardDatabase.ValidCardsLevel2.Count)];

					CurrentCard.CurrentAbsoluteCardNumber = NewCardNumber;
					CurrentCard.CurrentCardType = 1;
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel2 ("StandardLevel2Card", NewCardNumber);
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateButtonKeepInHand ();
					Destroy (gameObject);
				}				
				if (card3_selected == true) {
					NewCardNumber = CardDatabase.ValidCardsLevel3 [Random.Range (0, CardDatabase.ValidCardsLevel3.Count)];

					CurrentCard.CurrentAbsoluteCardNumber = NewCardNumber;
					CurrentCard.CurrentCardType = 2;
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateCardLevel3 ("StandardLevel3Card", NewCardNumber);
					GameObject.Find ("Cards").GetComponent<CardCreateDisplay> ().CreateButtonKeepInHand ();
					Destroy (gameObject);
				}
			}  
		}


		if (destruction_of_this_card == true) {

			GetComponent<Button> ().interactable = false;
			transform.Rotate (new Vector3 (0, 1, 0), 720f * Time.deltaTime); //rotate by 180 degrees in one 1 second
			time_passed += Time.deltaTime;

			if (time_passed > 0.125f) { // if half a second has passed... 
				Destroy (gameObject);
			}
		}
	}
}
