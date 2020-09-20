using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{


	
	
	void Update ()
	{
		transform.RotateAround (Vector3.zero, new Vector3 (10, 10, 10), 10 * Time.deltaTime);
	

	}
}
