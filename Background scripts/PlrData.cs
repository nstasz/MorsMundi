using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlrData : MonoBehaviour
{
	static public int plr_total_count;
	static public bool[] plr_alive;
	static public int current_player;

	static public string[] plr_name;

	static public float[,] plr_resource;
	static public string[] resource_name;
	static public string[] resource_name_grants;

	static public GameObject[] plr_planet;
	static public GameObject[] plr_orbit;
	static public GameObject[] plr_fields;

	public static int[] plr_hand;
	public static List<int>[] plr_hand_level1;
	public static List<int>[] plr_hand_level2;
	public static List<int>[] plr_hand_level3;


	//An array of lists
	public static int[] plr_used_cards;
	public static List<int>[] plr_used_cards_level1;
	public static List<int>[] plr_used_cards_level2;
	public static List<int>[] plr_used_cards_level3;

	public static List<int>[] plr_used_cards_event;
	public static List<int>[] plr_used_cards_bargain;

	public static bool settings_entered;
	// by default false;
	public static int settings_planet_speed;


	void Start ()
	{
		current_player = 0;


		resource_name = new string[7] {
			"Population growth",	// 0
			"Population",			// 1
			"Gold",					// 2
			"Hydrogen",				// 3
			"Exomatter",			// 4
			"Technology level",		// 5
			"Energy level"			// 6
		};
		// For example, the Energy level of Player 2 is resource_name[1,6] - you always start counting with 0.

		resource_name_grants = new string[14] {
			"Population growth",
			"Population",
			"Gold",
			"Hydrogen",
			"Exomatter",
			"Technology level",
			"Energy level",
			"Population growth",	// 7
			"Population",			// 8
			"Gold",				// 9
			"Hydrogen",			// 10
			"Exomatter",			// 11
			"Technology level",	// 12
			"Energy level"		// 13
		};

		plr_resource = new float[4, 7];
		for (int i = 0; i < 4; i++) {

			plr_resource [i, 0] = 1.1f; //set population growth to higher than 1;
			plr_resource [i, 1] = 2; 	//set population to 2;
		}
		for (int i = 2; i < 7; i++) { //reset everything else to 0;
			plr_resource [0, i] = 0;
			plr_resource [1, i] = 0;
			plr_resource [2, i] = 0;
			plr_resource [3, i] = 0;
		}



		plr_planet = new GameObject[4] {
			GameObject.Find ("Mercury"),
			GameObject.Find ("Venus"),
			GameObject.Find ("Earth"),
			GameObject.Find ("Mars")
		};

		plr_orbit = new GameObject[4] {
			GameObject.Find ("Orbit1"),
			GameObject.Find ("Orbit2"),
			GameObject.Find ("Orbit3"),
			GameObject.Find ("Orbit4")
		};

		plr_fields = new GameObject[4] {
			GameObject.Find ("PlayingFieldsPlr0"),
			GameObject.Find ("PlayingFieldsPlr1"),
			GameObject.Find ("PlayingFieldsPlr2"),
			GameObject.Find ("PlayingFieldsPlr3")
		};

		plr_alive = new bool[4] { true, true, true, true };
		if (plr_total_count < 4) {
			plr_alive [3] = false; 
			Destroy (plr_planet [3]);
			Destroy (plr_orbit [3]);
		}
		if (plr_total_count < 3) {
			plr_alive [2] = false; 
			Destroy (plr_planet [2]);
			Destroy (plr_orbit [2]);
		}

		if (plr_name == null) {
			plr_name = new string[4];
			plr_name [0] = "Mercury Player";
			plr_name [1] = "Venus Player";
			plr_name [2] = "Earth Player";
			plr_name [3] = "Mars Player";
		}

		plr_hand = new int [4] { 0, 0, 0, 0 };
		plr_hand_level1 = new List<int>[4];
		plr_hand_level2 = new List<int>[4];
		plr_hand_level3 = new List<int>[4];


		plr_used_cards = new int [4] { 0, 0, 0, 0 };
		plr_used_cards_level1 = new List<int>[4];
		plr_used_cards_level2 = new List<int>[4];
		plr_used_cards_level3 = new List<int>[4];
		plr_used_cards_event = new List<int>[4];
		plr_used_cards_bargain = new List<int>[4];
		for (int i = 0; i < 4; i++) {
			

			plr_hand_level1 [i] = new List<int> ();
			plr_hand_level2 [i] = new List<int> ();
			plr_hand_level3 [i] = new List<int> ();


			plr_used_cards_level1 [i] = new List<int> ();
			plr_used_cards_level2 [i] = new List<int> ();
			plr_used_cards_level3 [i] = new List<int> ();
			plr_used_cards_event [i] = new List<int> ();
			plr_used_cards_bargain [i] = new List<int> ();
		}



		// TEST begins
		if (GameObject.Find ("Sequencing") != null) {
			GameObject.Find ("Sequencing").GetComponent<TestingScripts> ().ActivateTestScripts (); // REMOVE LATER
		}
		// TEST END

	}

	public static void DefineVariables ()
	{
		plr_name = new string[4]; //this is only used in the first scene

        
	}


	public static void DefineSettings ()
	{
		settings_entered = true;
		settings_planet_speed = 10;

	}
}