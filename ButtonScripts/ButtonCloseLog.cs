using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCloseLog : MonoBehaviour
{

	public void BtnCloseLog ()
	{

		BackgroundSequencingInfo.NoActionRequieredAnymore ();
		Destroy (gameObject);
	}
}
