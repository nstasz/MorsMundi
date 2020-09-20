using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingScripts : MonoBehaviour
{

	// Use this for initialization
	public void ActivateTestScripts ()
	{
		
		/*
		for (int i = 0; i < 4; i++) {

			PlrData.plr_resource [i, 0] = 1.1f; 
			PlrData.plr_resource [i, 1] = 2; 
			PlrData.plr_resource [i, 2] = 0;
			PlrData.plr_resource [i, 3] = 0;
			PlrData.plr_resource [i, 4] = 0;
			PlrData.plr_resource [i, 5] = 1;
			PlrData.plr_resource [i, 6] = 0;
			*/

		for (int i = 0; i < 4; i++) {

			/* Start resources for players only for test phase */
			PlrData.plr_resource [i, 0] = 1.1f; 
			PlrData.plr_resource [i, 1] = 20; 
			PlrData.plr_resource [i, 2] = 150;
			PlrData.plr_resource [i, 3] = 50;
			PlrData.plr_resource [i, 4] = 50;
			PlrData.plr_resource [i, 5] = 50;
			PlrData.plr_resource [i, 6] = 50;
		}


		/*
		PlrData.plr_total_count = 4;
		PlrData.plr_alive [0] = true;
		PlrData.plr_alive [1] = true;
		PlrData.plr_alive [2] = true;
		PlrData.plr_alive [3] = true;
*/


		//ADDS ALL PLAYERS ALL CARDS EXCEPT TOKENS

		for (int j = 0; j < 4; j++) {
			/*
			for (int i = 0; i < CardDatabase.CardLevel1PlayableTotalCount; i++) {
				PlrData.plr_hand_level1 [j].Add (i);
			}

*/
			/*
			for (int i = 0; i < CardDatabase.CardLevel2PlayableTotalCount; i++) {
				PlrData.plr_hand_level2 [j].Add (i);
			}


			*/

			/*
			for (int i = 0; i < CardDatabase.CardLevel3PlayableTotalCount; i++) {
				PlrData.plr_hand_level3 [j].Add (i);
			}
			*/


			PlrData.plr_hand_level3 [j].Add (13);
			PlrData.plr_hand_level3 [j].Add (1);
			PlrData.plr_hand_level3 [j].Add (4);
		}


			





	}




}
	

/*
	void Update ()
	{
		
	}
	*/

