using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameStart : MonoBehaviour
{
	public bool local_initial_camera_zoom_in_enabled;
	//by default false
	static public bool[] deactivateFirstStepOnGameStart;


	void Start ()
	{
		deactivateFirstStepOnGameStart = new bool[] { true, true, true, true };

		for (int i = 0; i < 4; i++) {
			//PlrData.plr_planet [i].name = PlrData.plr_name [i];
			PlrData.plr_planet [i].GetComponent<Rotation> ().rotation_enabled = false;
		}
        
		PlrCurrentStatsUpdate.PlrCurrentStatsUpdateClass ();

		//ADDS bonus CARDS
		for (int j = 0; j < 4; j++) {


			PlrData.plr_hand_level2 [j].Add (CardDatabase.tk2 + 1);
			PlrData.plr_hand_level2 [j].Add (CardDatabase.tk2 + 2);
			PlrData.plr_hand_level2 [j].Add (CardDatabase.tk2 + 3);
			PlrData.plr_hand_level2 [j].Add (CardDatabase.tk2 + 4);


		}
	}


	//void Update()
	//{
	//}

}
