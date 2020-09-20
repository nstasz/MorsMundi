using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BargainCreateDisplay : MonoBehaviour
{

	public GameObject BargainFromPrefab;
	public float[] PlrRs;
	// simple copy of the resources of the curent player
	public bool[] PlrRs_av;
	public List<int> PlrRs_list;
	public int CurPl;
	public int Condition_index;
	public float Condition_cost;
	public float Condition_cost_range_min;
	public float Condition_cost_range_max;
	public int Condition_cost_option;

	public List<int> Grants_list;
	public int Grants_index;
	public float Grants_cost;
	public float Grants_cost_range_min;
	public float Grants_cost_range_max;
	public int Grants_cost_option;

	public string BGText;



	public void BargainMainScript ()
	{
		//print ("starting bargain main");
		PlrRs = new float[7] { 0, 0, 0, 0, 0, 0, 0 };
		PlrRs_av = new bool[10];
		PlrRs_list = new List<int> ();
		Grants_list = new List<int> ();

		CurPl = PlrData.current_player;
		//print ("ending bargain main, now other classes will follow");

		CheckForAvailableResources ();
		DefineBargainConditions ();
		RandomizeCardElements ();
		UpdateCardAndButtons ();
	}

	public void CheckForAvailableResources ()
	{
		for (int i = 0; i < 7; i++) {
			
			PlrRs [i] = PlrData.plr_resource [CurPl, i];
			Grants_list.Add (i); // every resource can be granted
			if (PlrRs [i] > 0) {
				PlrRs_av [i] = true; // you can use it as a condition
				PlrRs_list.Add (i);
				//Grants_list.Remove (i);	// this would only grant you what you already have (so you do not get exomatter etc. in the beginning)
			} else {
				PlrRs_av [i] = false;
			}
		}
		if (PlrData.plr_hand [CurPl] > 0) {
			if (PlrData.plr_hand_level1 [CurPl].Count > 0) {
				PlrRs_list.Add (7);
			}
			if (PlrData.plr_hand_level2 [CurPl].Count > 0) {
				PlrRs_list.Add (8);
			}
			if (PlrData.plr_hand_level3 [CurPl].Count > 0) {
				PlrRs_list.Add (9);
			}
		}
		//print ("Resources checked");
	}

	public void	DefineBargainConditions ()
	{
		int randomnumber = Random.Range (0, PlrRs_list.Count);
		Condition_index = PlrRs_list [randomnumber];


		if (Condition_index < 7) { // if it is a resource, not a card
			if (Condition_index == 0) {
				Condition_cost_range_min = 10; //actually 0.1, but I cannot randomize with zero;
				Condition_cost_range_max = PlrRs [0] * 100; 


			}


			for (int i = 1; i < 7; i++) {
				if (Condition_index == i) {
					Condition_cost_range_min = 1; 
					Condition_cost_range_max = PlrRs [i];
				}
			}
			Condition_cost_option = Random.Range (0, 6);
			if (Condition_cost_option == 0) {
				Condition_cost = Random.Range (Condition_cost_range_min, Condition_cost_range_max);
				if (Condition_index == 0) {
					Condition_cost = (float)System.Math.Round (Condition_cost / 100, 2); // cost = a simple int of units or a float in case of population and population growth
				}
			}


			if (Condition_cost_option == 1) {
				Condition_cost = PlrRs [Condition_index]; //100%
			}

			if (Condition_cost_option == 2) {
				
				Condition_cost = (float)(PlrRs [Condition_index] * 0.75); //75%
				if (Condition_index == 0) {
					Condition_cost = (float)System.Math.Round (Condition_cost / 100, 2); // cost = 75% of population growth or population, rounded to two digits after comma.
				} else {
					Condition_cost = (float)System.Math.Round (Condition_cost); // cost = 75% rounding up. (If you have 5 units, you will lose 4).
				}
			}
			if (Condition_cost_option == 3) {
				Condition_cost = (float)(PlrRs [Condition_index] * 0.5); //50%
				if (Condition_index == 0) {
					Condition_cost = (float)System.Math.Round (Condition_cost / 100, 2); // cost = 50% of population growth or population, rounded to two digits after comma.
				} else {
					Condition_cost = (float)System.Math.Round (Condition_cost); // cost = 50% rounding up. (If you have 3 units, you will lose 2).
				}

			}
			if (Condition_cost_option == 4) {
				Condition_cost = (float)(PlrRs [Condition_index] * 0.25); //25%
				if (Condition_index == 0) {
					Condition_cost = (float)System.Math.Round (Condition_cost / 100, 2); // cost = 25% of population growth or population, rounded to two digits after comma.
				} else {
					Condition_cost = (float)System.Math.Round (Condition_cost); // cost = 25% rounding up. 
				}

			}
			if (Condition_cost_option == 5) {
				Condition_cost = (float)(PlrRs [Condition_index] * 0.1); //10%
				if (Condition_index == 0) {
					Condition_cost = (float)System.Math.Round (Condition_cost / 100, 2); // cost = 10% of population growth or population, rounded to two digits after comma.
				} else {
					Condition_cost = (float)System.Math.Round (Condition_cost); // cost = 10% rounding up. 
				}

			}

			if (Condition_cost < 1) {
				if (Condition_index > 0) {
					print ("too small number");
					Condition_cost = 1;
				} else { /// if it is population growth and costs 0 of it...
					Condition_cost = 0.5f;
				}
			}
			if (Condition_index < 2) {
				Condition_cost = (float)System.Math.Round (Condition_cost, 2);
			} else {
				Condition_cost = (float)System.Math.Round (Condition_cost);
			}
			

		} else {
			if (Condition_index == 7) {
				Condition_cost = Random.Range (0, PlrData.plr_hand_level1 [CurPl].Count); //the index for this card in the hand list, not its value;
			}
			if (Condition_index == 8) {
				Condition_cost = Random.Range (0, PlrData.plr_hand_level2 [CurPl].Count); 
			}
			if (Condition_index == 9) {
				Condition_cost = Random.Range (0, PlrData.plr_hand_level3 [CurPl].Count); 
			}

		}

		Grants_list.Add (7); //cards level 1, 2, 3
		Grants_list.Add (8);
		Grants_list.Add (9);
		Grants_index = Grants_list [Random.Range (0, Grants_list.Count)];
		while (Grants_index == Condition_index) {
			Grants_index = Grants_list [Random.Range (0, Grants_list.Count)];
		}

		///****
		/// The interesting part: 
		/// defining how much will be granted options

		if (Grants_index < 7) {
			Grants_cost_option = Random.Range (0, 3);

			if (Grants_cost_option == 0) {
				Grants_cost = Random.Range (1, 10) / 10;

			}
			if (Grants_cost_option == 1) {
				Grants_cost = Random.Range (1, 8);

			}
			if (Grants_cost_option == 2) {
				Grants_cost = Random.Range (1, 11);

			}
		}
		if (Grants_index == 7) {
			Grants_cost = Random.Range (0, CardDatabase.CardLevel1PlayableTotalCount);  // returns a random card number
		}
		if (Grants_index == 8) {
			Grants_cost = Random.Range (0, CardDatabase.CardLevel2PlayableTotalCount); 
		}
		if (Grants_index == 9) {
			Grants_cost = Random.Range (0, CardDatabase.CardLevel3PlayableTotalCount); 
		}

		CurrentCard.BargainConditionCost = Condition_cost;
		CurrentCard.BargainConditionIndex = Condition_index;
		CurrentCard.BargainGrantsCost = Grants_cost;
		CurrentCard.BargainGrantsIndex = Grants_index;
		//print ("bargain conditions defined");
	}

	public void	RandomizeCardElements ()
	{
		List<string> Element1 = new List<string> ();
		Element1.Add ("Respectable Aliens");
		Element1.Add ("Space pirates");
		Element1.Add ("Voices from the Void");
		Element1.Add ("Unkown Gods");
		Element1.Add ("Some weird bugs");
		Element1.Add ("Space police");
		Element1.Add ("Entities of unspeakable nature");
		Element1.Add ("Long dead players");
		Element1.Add ("Shady smugglers");
		Element1.Add ("Sun inhabitants");
		Element1.Add ("Fugitives from a parallel universe");
		Element1.Add ("Space Church charlatans");
		Element1.Add ("Members of the Shrike church");
		Element1.Add ("Earth inhabitants");
		//Element1.Add ("\"Earth\" inhabitants");
		Element1.Add ("Strange nightmare creatures");
		Element1.Add ("Lost space travellers");
		Element1.Add ("Creatures from planet within");
		Element1.Add ("Bypassing Siths");
		Element1.Add ("Starfleet mutineers");
		Element1.Add ("Universe founders");
		Element1.Add ("Furious A.I. spaceships");
		BGText = Element1 [Random.Range (0, Element1.Count)] + " ";
		List<string> Element2 = new List<string> ();

		Element2.Add ("offer you");
		Element2.Add ("try really hard to sell you");
		Element2.Add ("hint at giving you");
		Element2.Add ("want to give you");


		BGText += Element2 [Random.Range (0, Element2.Count)]	+ " ";

		if (Grants_index == 1) {
			BGText += "a tiny fraction of their ";
		}
		if (Grants_index == 5 || Grants_index == 6) {
			BGText += "some blueprints to boost your ";
		}
		if (Grants_index < 7) {
			BGText += PlrData.resource_name [Grants_index];
		}
		if (Grants_index == 7) {
			BGText += "a random Level 1 Card";
		}
		if (Grants_index == 8) {
			BGText += "a random Level 2 Card";
		}
		if (Grants_index == 9) {
			BGText += "a random Level 3 Card";
		}
		BGText += " for ";

		if (Condition_index < 7) {
			BGText +=	Condition_cost.ToString ();
			if (Condition_cost == 1) {
				BGText +=	" unit of ";
			} else {
				BGText +=	" units of ";
			}

			BGText +=	PlrData.resource_name [Condition_index];
		}
		if (Condition_index == 7) {
			BGText += "a random Level 1 Card";
		}
		if (Condition_index == 8) {
			BGText += "a random Level 2 Card";
		}
		if (Condition_index == 9) {
			BGText += "a random Level 3 Card";
		}
		BGText += " and ";
		List<string> ElementSecondDemand = new List<string> ();
		ElementSecondDemand.Add ("your finest women");
		ElementSecondDemand.Add ("your holy scriptures");
		ElementSecondDemand.Add ("all your cold weapons");
		ElementSecondDemand.Add ("bacteria samples");
		ElementSecondDemand.Add ("your tastiest fruits");
		ElementSecondDemand.Add ("three full-grown lions");
		ElementSecondDemand.Add ("your soul");
		ElementSecondDemand.Add ("your fashion catalouges");
		ElementSecondDemand.Add ("all episodes of \"Friends\"");
		ElementSecondDemand.Add ("some minerals");
		ElementSecondDemand.Add ("your DNA code");
		ElementSecondDemand.Add ("a hard copy of Wikipedia");
		ElementSecondDemand.Add ("your research");
		ElementSecondDemand.Add ("a good Spotify playlist");
		ElementSecondDemand.Add ("your best craft beer");
		BGText += ElementSecondDemand [Random.Range (0, ElementSecondDemand.Count)];
		BGText += ". ";
		List<string> ElementLast = new List<string> ();
		ElementLast.Add ("Do not trust them.");
		ElementLast.Add ("I think you can trust them.");
		ElementLast.Add ("They are not trustworthy.");
		ElementLast.Add ("You can totally trust them.");
		ElementLast.Add ("Be cautious.");
		ElementLast.Add ("Have nothing to fear.");
		ElementLast.Add ("You can expect exortion.");
		ElementLast.Add ("Be aware of their aggression.");
		ElementLast.Add ("Their reputation is doubtful.");
		ElementLast.Add ("You certainly do not need it at all.");
		ElementLast.Add ("They always keep their word.");
		ElementLast.Add ("They seem really kind.");
		ElementLast.Add ("Seems like a good deal.");
		ElementLast.Add ("Seems like a bad deal.");
		ElementLast.Add ("They seem serious about it.");

		BGText += ElementLast [Random.Range (0, ElementLast.Count)];
		//print ("card elements randomized");
	}

	public void	UpdateCardAndButtons ()
	{
		if (GameObject.Find ("BargainCard") == null) {
			GameObject BCard = Instantiate (BargainFromPrefab, Vector3.zero, Quaternion.identity);
			BCard.name = "BargainCard";
			BCard.transform.SetParent (GameObject.Find ("CardCanvas").transform);
			BCard.transform.position = GameObject.Find ("CardCanvas").transform.position;
		}

		GameObject.Find ("BargainDescription").GetComponent<Text> ().text = BGText;


		if (Grants_index < 7) {
			GameObject.Find ("TextBargainWin").GetComponent<Text> ().text =	PlrData.resource_name [Grants_index].ToUpper ();
		

		}
		if (Condition_index < 7) {
			GameObject.Find ("TextBargainCondition").GetComponent<Text> ().text =	Condition_cost.ToString ();
			if (Condition_cost == 1) {
				GameObject.Find ("TextBargainCondition").GetComponent<Text> ().text +=	" UNIT OF";
			} else {
				GameObject.Find ("TextBargainCondition").GetComponent<Text> ().text +=	" UNITS OF";
			}
		}

		//GameObject.Find ("TextBargainWin").GetComponent<Text> ().text = Grants_cost.ToString ();
		//GameObject.Find ("TextBargainCondition").GetComponent<Text> ().text = Condition_cost.ToString ();

		if (Grants_index == 7) {
			GameObject.Find ("TextBargainWin").GetComponent<Text> ().text = "A LEVEL 1 CARD";
		}
		if (Grants_index == 8) {
			GameObject.Find ("TextBargainWin").GetComponent<Text> ().text = "A LEVEL 2 CARD";
		}
		if (Grants_index == 9) {
			GameObject.Find ("TextBargainWin").GetComponent<Text> ().text = "A LEVEL 3 CARD";
		}
		if (Condition_index == 7) {
			GameObject.Find ("TextBargainCondition").GetComponent<Text> ().text = "A LEVEL 1 CARD";
		}
		if (Condition_index == 8) {
			GameObject.Find ("TextBargainCondition").GetComponent<Text> ().text = "A LEVEL 2 CARD";
		}
		if (Condition_index == 9) {
			GameObject.Find ("TextBargainCondition").GetComponent<Text> ().text = "A LEVEL 3 CARD";
		}


		GameObject.Find ("ImageWin").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + Grants_index) as Texture;
		if (Grants_index > 6) {
			GameObject.Find ("ImageWin").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/hand") as Texture;
		}
		GameObject.Find ("ImageCondition").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/" + Condition_index) as Texture;
		if (Condition_index > 6) {
			GameObject.Find ("ImageCondition").GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Symbols/hand") as Texture;
		}
		//print ("card and buttons updated");
	}
}