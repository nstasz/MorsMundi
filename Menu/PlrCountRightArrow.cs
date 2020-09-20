using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlrCountRightArrow : MonoBehaviour
{

	public void ClickOnRightArrow ()
	{
		InputField Input2, Input3, Input4;
		Input2 = GameObject.Find ("InputField2").GetComponent<InputField> ();
		Input3 = GameObject.Find ("InputField3").GetComponent<InputField> ();
		Input4 = GameObject.Find ("InputField4").GetComponent<InputField> ();


		int local_count;
		local_count = int.Parse (GameObject.Find ("PlrCountNumber").GetComponent<Text> ().text); 
		if (local_count < 4) { 
			local_count += 1;
			GameObject.Find ("PlrCountNumber").GetComponent<Text> ().text = local_count.ToString ();
			PlrData.plr_total_count = local_count;
		}
		if (local_count == 1) {
			Input2.interactable = false; 
			Input3.interactable = false;
			Input4.interactable = false;
		}
		if (local_count == 2) {
			Input2.interactable = true;
			Input3.interactable = false;
			Input4.interactable = false;
		}
		if (local_count == 3) {
			Input2.interactable = true;
			Input3.interactable = true;
			Input4.interactable = false;
		}
		if (local_count == 4) {
			Input2.interactable = true;
			Input3.interactable = true;
			Input4.interactable = true;
		}

	}
}
