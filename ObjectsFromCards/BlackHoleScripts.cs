using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScripts : MonoBehaviour
{
	public static bool blackHoleExpanding;
	Vector3 currentSize;



	void Start ()
	{
		blackHoleExpanding = true;

	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		NewButtonKeepInHand.transform.SetParent (GameObject.Find ("CardCanvas").transform); // in other words: Display on Canvas
		NewButtonKeepInHand.transform.position = GameObject.Find ("CardCanvas").transform.position + new Vector3 (0, -300, 0);
		NewButtonKeepInHand.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
		NewButtonKeepInHand.name = "ButtonKeepInHand";
		*/
		transform.RotateAround (Vector3.zero, Vector3.one, 0.02f);
		//transform.Rotate (0, 10 * Time.deltaTime, 0);
		currentSize = transform.localScale;


		if (blackHoleExpanding == true) {





			if (transform.localScale.x < 100) {
				transform.localScale = Vector3.Scale (transform.localScale, new Vector3 (1.02f, 1.02f, 1.02f));
			}
		}


	}
}
