using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOverpopulation : MonoBehaviour
{


	public static void PlrOverpopulation (int PlrNumber)
	{
		PlrData.plr_resource [PlrNumber, 0] = 0.95f;
		PlrData.plr_resource [PlrNumber, 1] = 1000000;

		GameObject.Find ("Sequencing").GetComponent<CreatePanel> ().CreateOverpopulationPanel (PlrNumber); 





	}


}
