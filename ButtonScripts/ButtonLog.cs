using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLog : MonoBehaviour
{
	public GameObject LogFromPrefab;

	public void BtnLog ()
	{
		GameObject NewLog = Instantiate (LogFromPrefab, Vector3.zero, Quaternion.identity);
		NewLog.name = "GameLog";	
		GameObject.Find ("ButtonLog").GetComponent<Button> ().interactable = false;
		GameObject.Find ("LogField").GetComponent<Text> ().text = GameLog.log;

	}
}
