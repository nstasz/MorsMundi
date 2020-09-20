using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewFromTop : MonoBehaviour
{
	float local_distance;



	public void View_from_top ()
	{

		local_distance = GameObject.Find ("Main Camera").GetComponent<CameraControl> ().distance;
		GameObject.Find ("Main Camera").transform.position = new Vector3 (0, local_distance, 0);
		GameObject.Find ("Main Camera").transform.rotation = Quaternion.Euler (90, 0, 0);
	}



	
}
