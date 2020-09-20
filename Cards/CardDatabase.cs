using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDatabase : MonoBehaviour
{
	
	static public int CardLevel1TotalCount;
	static public int CardLevel2TotalCount;
	static public int CardLevel3TotalCount;
	static public int CardLevel1PlayableTotalCount;
	static public int CardLevel2PlayableTotalCount;
	static public int CardLevel3PlayableTotalCount;
	static public int CardLevel1TokenTotalCount;
	static public int CardLevel2TokenTotalCount;
	static public int CardLevel3TokenTotalCount;
	static public int tk1;
	static public int tk2;
	static public int tk3;
	int index;

	static public int CardAllLevelsPlayableCount;
	static public int CardAllLevelsTokenCount;
	static public int CardEventTotalCount;
	static public int CardEventPlayableTotalCount;

	static public int CardYellowTotalCount;
	static public int CardYellowPlayableTotalCount;

	static public int CardsTotalCount;

	static public List<int> ValidCardsLevel1;
	static public List<int> ValidCardsLevel2;
	static public List<int> ValidCardsLevel3;



	static public string[] CardTypeName;

	static public string[] CardLevel1Title;
	static public string[] CardLevel1Description;
	static public string[] CardLevel1Art;
	static public int[] CardLevel1ReqName;
	//"Requries HYDROGEN..." Hydrogen has a number, that is 3, so it is an integer.
	static public int[] CardLevel1ReqCost;
	//"... 5 units of it"
	static public int[] CardLevel1GrantsName;
	//"Gives you TECHNOLOGY..."
	static public float[] CardLevel1GrantsCost;
	//"... 5 units of it"

	static public string[] CardLevel2Title;
	static public string[] CardLevel2Description;
	static public string[] CardLevel2Art;
	static public bool[] CardLevel2HasReq;
	static public int[] CardLevel2Req1Name;
	static public int[] CardLevel2Req1Cost;
	static public int[] CardLevel2Req2Name;
	static public int[] CardLevel2Req2Cost;
	static public bool[] CardLevel2DisplayGrants;
	static public int[] CardLevel2GrantsName;
	static public float[] CardLevel2GrantsCost;
	static public bool[] CardLevel2CanAffectAnotherPlayer;
	static public bool[] CardLevel2HasScript;

	static public string[] CardLevel3Title;
	static public string[] CardLevel3Description;
	static public string[] CardLevel3Art;
	static public bool[] CardLevel3HasReq;
	static public int[] CardLevel3Req1Name;
	static public int[] CardLevel3Req1Cost;
	static public int[] CardLevel3Req2Name;
	static public int[] CardLevel3Req2Cost;
	static public bool[] CardLevel3DisplayGrants;
	static public int[] CardLevel3GrantsName;
	static public float[] CardLevel3GrantsCost;
	static public bool[] CardLevel3CanAffectAnotherPlayer;
	static public bool[] CardLevel3HasScript;


	/* CARD Requirements and Grants names are identical, as they are only required for graphics. They have a numeric value.
     * 0 Population growth
     * 1 Population
     * 2 Gold
     * 3 Hydrogen
     * 4 Exomatter
     * 5 Technology level
     * 6 Energy level
     * 
     * If a card destroys something, for example an Asteroid destroys a population by 50%, then the Asteroid has 101 in CardGrantsName and 50 in CardGrantsCost
     * 7 Population  growth reduction
     * 8 Population reduction
     * 9 Gold reduction
     * 10 Hydrogen reduction
     * 11 Exomatter reduction
     * 12 Technology level reduction
     * 13 Energy level reduction
     * 
     */

	void Awake ()
	{
		


		CardLevel1PlayableTotalCount = 31; //Adding the 0 card, so it is last index + 1!
		CardLevel2PlayableTotalCount = 11; //Adding the 0 card, so it is last index + 1!
		CardLevel3PlayableTotalCount = 14; //Adding the 0 card, so it is last index + 1!

		CardLevel1TokenTotalCount = 0;
		CardLevel2TokenTotalCount = 5;
		CardLevel3TokenTotalCount = 0;

		tk1 = CardLevel1PlayableTotalCount;
		tk2 = CardLevel2PlayableTotalCount;
		tk3 = CardLevel3PlayableTotalCount;

		CardAllLevelsPlayableCount = CardLevel1PlayableTotalCount + CardLevel2PlayableTotalCount + CardLevel3PlayableTotalCount; 

		CardLevel1TotalCount = CardLevel1PlayableTotalCount + CardLevel1TokenTotalCount; 
		CardLevel2TotalCount = CardLevel2PlayableTotalCount + CardLevel2TokenTotalCount;
		CardLevel3TotalCount = CardLevel3PlayableTotalCount + CardLevel3TokenTotalCount;

		CardEventPlayableTotalCount = 0;
		CardEventTotalCount = CardEventPlayableTotalCount;

		CardYellowPlayableTotalCount = 0;
		CardYellowTotalCount = CardYellowPlayableTotalCount;


		CardsTotalCount = CardLevel1TotalCount + CardLevel2TotalCount + CardLevel3TotalCount + CardEventTotalCount + CardYellowTotalCount;


		CardLevel1Title = new string[CardLevel1TotalCount];
		CardLevel1Description = new string[CardLevel1TotalCount];
		CardLevel1Art = new string[CardLevel1TotalCount];
		CardLevel1ReqName = new int[CardLevel1TotalCount];
		CardLevel1ReqCost = new int[CardLevel1TotalCount];
		CardLevel1GrantsName = new int[CardLevel1TotalCount];
		CardLevel1GrantsCost = new float[CardLevel1TotalCount];

		CardLevel2Title = new string[CardLevel2TotalCount];
		CardLevel2Description = new string[CardLevel2TotalCount];
		CardLevel2Art = new string[CardLevel2TotalCount];
		CardLevel2HasReq = new bool[CardLevel2TotalCount]; // some cards have no Requirements. Players start the game with a card that can double their resources.
		CardLevel2Req1Name = new int[CardLevel2TotalCount];
		CardLevel2Req1Cost = new int[CardLevel2TotalCount];
		CardLevel2Req2Name = new int[CardLevel2TotalCount];
		CardLevel2Req2Cost = new int[CardLevel2TotalCount];
		CardLevel2DisplayGrants = new bool[CardLevel2TotalCount];
		CardLevel2GrantsName = new int[CardLevel2TotalCount];
		CardLevel2GrantsCost = new float[CardLevel2TotalCount];
		CardLevel2CanAffectAnotherPlayer = new bool[CardLevel2TotalCount]; 
		CardLevel2HasScript = new bool[CardLevel2TotalCount];

		CardLevel3Title = new string[CardLevel3TotalCount];
		CardLevel3Description = new string[CardLevel3TotalCount];
		CardLevel3Art = new string[CardLevel3TotalCount];
		CardLevel3HasReq = new bool[CardLevel3TotalCount]; // some cards have no Requirements. Players start the game with a card that can double their resources.
		CardLevel3Req1Name = new int[CardLevel3TotalCount];
		CardLevel3Req1Cost = new int[CardLevel3TotalCount];
		CardLevel3Req2Name = new int[CardLevel3TotalCount];
		CardLevel3Req2Cost = new int[CardLevel3TotalCount];
		CardLevel3DisplayGrants = new bool[CardLevel3TotalCount];
		CardLevel3GrantsName = new int[CardLevel3TotalCount];
		CardLevel3GrantsCost = new float[CardLevel3TotalCount];
		CardLevel3CanAffectAnotherPlayer = new bool[CardLevel3TotalCount]; 
		CardLevel3HasScript = new bool[CardLevel3TotalCount];

		// after new card types will be added, add them here


		CardTypeName = new string[5];
		CardTypeName [0] = "Level 1 Card";
		CardTypeName [1] = "Level 2 Card";
		CardTypeName [2] = "Level 3 Card";
		CardTypeName [3] = "Event card";
		CardTypeName [4] = " card";

		ValidCardsLevel1 = new List<int> ();
		ValidCardsLevel2 = new List<int> ();
		ValidCardsLevel3 = new List<int> ();
		for (int i = 0; i < (CardLevel1PlayableTotalCount); i++) {
			ValidCardsLevel1.Add (i);
			//print ("ValidCardsLevel1 count: " + ValidCardsLevel1.Count);
			//print ("ValidCardsContains " + ValidCardsLevel1 [i]);
		}

		for (int i = 0; i < (CardLevel2PlayableTotalCount); i++) {
			ValidCardsLevel2.Add (i);

		}

		//WHAT IS BELOW IS JUST FOR TEST PURPOSES AND SHOULD BE DELETED LATER 
		for (int i = 0; i < (CardLevel3PlayableTotalCount); i++) {
			ValidCardsLevel3.Add (i);

		}

		// END OF THE TEST


		//WHAT IS ABOVE IS JUST FOR TEST PURPOSES AND SHOULD BE DELETED LATER 

		/*
		//CARD zero "example"
		CardType [0] = 0; // Number zero card is a CardLevel1 card;
		CardLevel1Title [0] = "Example card name - Wheel";
		CardLevel1Description [0] = "This is an example card that grants you 10 points of Technology if you have 32 (million) Population";
		CardLevel1Art [0] = "0"; // "Test image"
		CardLevel1ReqName [0] = 1; // "Population"
		CardLevel1ReqCost [0] = 32; // "32 unit of it"
		CardLevel1GrantsName [0] = 5; // "Technology"
		CardLevel1GrantsCost [0] = 10; // "10 units of it"
		*/







		//Cards 1-10: Identical, with different name/art/descriprition. Require population, grant technology.
		index = 0;
		CardLevel1Title [index] = "Gold diggers";  // The ONLY card that grants you something different than Technology/Energy/Population growth. Not useful in the beginning, but useful later on.
		CardLevel1Description [index] = "Unlikely as it was, wanderers report huge amounts of shiny things in your mountains.";
		CardLevel1Art [index] = "lvl1_" + index.ToString (); 
		CardLevel1ReqName [index] = 1; 
		CardLevel1ReqCost [index] = 2; 
		CardLevel1GrantsName [index] = 2; 
		CardLevel1GrantsCost [index] = 8; 




		index = 1;
		CardLevel1Title [index] = "Wheel";
		CardLevel1Description [index] = "After decades of hard labour scientists invent the wheel.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		index = 2;
		CardLevel1Title [index] = "Bow";
		CardLevel1Description [index] = "The growth rate of mammoths is decreasing.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		index = 3;
		CardLevel1Title [index] = "Flail";
		CardLevel1Description [index] = "The wisest of your farmers discovers this most innovative tool.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		index = 4;
		CardLevel1Title [index] = "Scripture";
		CardLevel1Description [index] = "Your wisdom is being set in stone, clay and papyrus.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		index = 5;
		CardLevel1Title [index] = "Horse";
		CardLevel1Description [index] = "You travel faster than regular humans.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;


		index = 6;
		CardLevel1Title [index] = "Fence";
		CardLevel1Description [index] = "Your goats cannot escape.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		index = 7;
		CardLevel1Title [index] = "Abacus";
		CardLevel1Description [index] = "From now on you can perform advanced mathematical calculations.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		index = 8;
		CardLevel1Title [index] = "Roof";
		CardLevel1Description [index] = "You won't get wet in the rain anymore.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		index = 9;
		CardLevel1Title [index] = "Salt";
		CardLevel1Description [index] = "Meat remains fresh.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		index = 10;
		CardLevel1Title [index] = "Well";
		CardLevel1Description [index] = "As it turns out, there is a sea below the earth.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 5;
		CardLevel1GrantsCost [index] = 1;

		//Cards 11-20: Identical, with different name/art/descriprition. Require population, grant energy.
		index = 11;
		CardLevel1Title [index] = "Fire";
		CardLevel1Description [index] = "After laboratory experiments with flints you discover the fire.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 12;
		CardLevel1Title [index] = "Peat 12";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 13;
		CardLevel1Title [index] = "Peat 13";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 14;
		CardLevel1Title [index] = "Peat 14";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 15;
		CardLevel1Title [index] = "Peat 15";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 16;
		CardLevel1Title [index] = "Peat 1";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 17;
		CardLevel1Title [index] = "Peat 17";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 18;
		CardLevel1Title [index] = "Peat 18";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 19;
		CardLevel1Title [index] = "Peat 19";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		index = 20;
		CardLevel1Title [index] = "Peat 20";
		CardLevel1Description [index] = "It may not smell nice, but it certainly warms the feet.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 1;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 6;
		CardLevel1GrantsCost [index] = 1;

		//Cards 21-25: Identical, with different name/art/descriprition. Require technology, grant population growth.
		index = 21;
		CardLevel1Title [index] = "Aphrodysiacs";
		CardLevel1Description [index] = "Some roots shall always be unearthed, says the shaman.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 5;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		index = 22;
		CardLevel1Title [index] = "Bed";
		CardLevel1Description [index] = "Your back does not hurt anymore.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 5;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		index = 23;
		CardLevel1Title [index] = "Hay";
		CardLevel1Description [index] = "Sometimes hay is sufficient.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 5;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		index = 24;
		CardLevel1Title [index] = "Religion";
		CardLevel1Description [index] = "Be fruitful and multiply. Fill the earth and subdue it.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 5;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		index = 25;
		CardLevel1Title [index] = "Door";
		CardLevel1Description [index] = "Everyone needs some privacy. At least from time to time.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 5;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		//Cards 26-30: Identical, with different name/art/descriprition. Require energy, grant population growth.
		index = 26;
		CardLevel1Title [index] = "Beer";
		CardLevel1Description [index] = "Because water is just contaminated.";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 6;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		index = 27;
		CardLevel1Title [index] = "Require energy";
		CardLevel1Description [index] = "Grant population growth";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 6;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		index = 28;
		CardLevel1Title [index] = "Require energy";
		CardLevel1Description [index] = "Grant population growth";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 6;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		index = 29;
		CardLevel1Title [index] = "Require energy";
		CardLevel1Description [index] = "Grant population growth";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 6;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;

		index = 30;
		CardLevel1Title [index] = "Require energy";
		CardLevel1Description [index] = "Grant population growth";
		CardLevel1Art [index] = "lvl1_" + index.ToString ();
		CardLevel1ReqName [index] = 6;
		CardLevel1ReqCost [index] = 2;
		CardLevel1GrantsName [index] = 0;
		CardLevel1GrantsCost [index] = 0.1f;



		/****
		 * 
		 * CARD LEVEL 2
		 * 
		 * 
		 ****/



		index = 0;
		CardLevel2Title [index] = "Hydrogen";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "The news about discovering Hydrogen finally hit the planet.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;
		CardLevel2CanAffectAnotherPlayer [index] = false; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 5;
		CardLevel2Req1Cost [index] = 1;
		CardLevel2Req2Name [index] = 6;
		CardLevel2Req2Cost [index] = 1;

		CardLevel2GrantsName [index] = 3;
		CardLevel2GrantsCost [index] = 10;




		index = 1;
		CardLevel2Title [index] = "Exomatter";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "The news about discovering Exomatter shook the planet. Literally.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;
		CardLevel2CanAffectAnotherPlayer [index] = false; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 5;
		CardLevel2Req1Cost [index] = 10;
		CardLevel2Req2Name [index] = 6;
		CardLevel2Req2Cost [index] = 10;

		CardLevel2GrantsName [index] = 4;
		CardLevel2GrantsCost [index] = 10;




		index = 2;
		CardLevel2Title [index] = "Satellite";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "Nothing defines this aeon more than satellite dependency.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;		
		CardLevel2CanAffectAnotherPlayer [index] = false; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 9;
		CardLevel2Req1Cost [index] = 8;
		CardLevel2Req2Name [index] = 5;
		CardLevel2Req2Cost [index] = 10;

		CardLevel2GrantsName [index] = 5;
		CardLevel2GrantsCost [index] = 10;




		index = 3;
		CardLevel2Title [index] = "Nuclear power plant";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "What could go wrong? Murmurred Livytskyi...";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;		
		CardLevel2CanAffectAnotherPlayer [index] = false; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 9;
		CardLevel2Req1Cost [index] = 6;
		CardLevel2Req2Name [index] = 10;
		CardLevel2Req2Cost [index] = 5;

		CardLevel2GrantsName [index] = 6;
		CardLevel2GrantsCost [index] = 10;




		index = 4;
		CardLevel2Title [index] = "Trash ejection";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "Finally you found a solution what to do with trash you accumulated over centuries.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;		
		CardLevel2CanAffectAnotherPlayer [index] = true; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 1;
		CardLevel2Req1Cost [index] = 2;
		CardLevel2Req2Name [index] = 3;
		CardLevel2Req2Cost [index] = 4;

		CardLevel2GrantsName [index] = 8; 
		CardLevel2GrantsCost [index] = 5000;




		index = 5;
		CardLevel2Title [index] = "Anthropology museum";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "Add three Level 1 Cards to hand.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = false;		
		CardLevel2CanAffectAnotherPlayer [index] = false; 
		CardLevel2HasScript [index] = true; 

		CardLevel2Req1Name [index] = 1;
		CardLevel2Req1Cost [index] = 20;
		CardLevel2Req2Name [index] = 0;
		CardLevel2Req2Cost [index] = 4;

		CardLevel2GrantsName [index] = 1; 
		CardLevel2GrantsCost [index] = 1;




		index = 6;
		CardLevel2Title [index] = "Nuke the government";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "Can a society live in anarchy? We'll see.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;		
		CardLevel2CanAffectAnotherPlayer [index] = true; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 9;
		CardLevel2Req1Cost [index] = 20;
		CardLevel2Req2Name [index] = 10;
		CardLevel2Req2Cost [index] = 20;

		CardLevel2GrantsName [index] = 7; 
		CardLevel2GrantsCost [index] = 100;




		index = 7;
		CardLevel2Title [index] = "Trash ejection 7";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "Finally you found a solution what to do with trash you accumulated over centuries.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;		
		CardLevel2CanAffectAnotherPlayer [index] = true; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 1;
		CardLevel2Req1Cost [index] = 2;
		CardLevel2Req2Name [index] = 3;
		CardLevel2Req2Cost [index] = 4;

		CardLevel2GrantsName [index] = 8; 
		CardLevel2GrantsCost [index] = 5000;




		index = 8;
		CardLevel2Title [index] = "Trash ejection 8";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "Finally you found a solution what to do with trash you accumulated over centuries.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;		
		CardLevel2CanAffectAnotherPlayer [index] = true; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 1;
		CardLevel2Req1Cost [index] = 2;
		CardLevel2Req2Name [index] = 3;
		CardLevel2Req2Cost [index] = 4;

		CardLevel2GrantsName [index] = 8; 
		CardLevel2GrantsCost [index] = 5000;




		index = 9;
		CardLevel2Title [index] = "Trash ejection 9";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "Finally you found a solution what to do with trash you accumulated over centuries.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = true;		
		CardLevel2CanAffectAnotherPlayer [index] = true; 
		CardLevel2HasScript [index] = false; 

		CardLevel2Req1Name [index] = 1;
		CardLevel2Req1Cost [index] = 2;
		CardLevel2Req2Name [index] = 3;
		CardLevel2Req2Cost [index] = 4;

		CardLevel2GrantsName [index] = 8; 
		CardLevel2GrantsCost [index] = 5000;




		index = 10;
		CardLevel2Title [index] = "Chemtrail pollution";
		CardLevel2Art [index] = "lvl2_" + index.ToString ();
		CardLevel2Description [index] = "Add three Chemtrails to your hand.";

		CardLevel2HasReq [index] = true;
		CardLevel2DisplayGrants [index] = false;
		CardLevel2CanAffectAnotherPlayer [index] = false; 
		CardLevel2HasScript [index] = true; 


		CardLevel2Req1Name [index] = 12; 
		CardLevel2Req1Cost [index] = 10;
		CardLevel2Req2Name [index] = 9;
		CardLevel2Req2Cost [index] = 10;


		CardLevel2GrantsName [index] = 0; // it does not have it
		CardLevel2GrantsCost [index] = 0;// it does not have it

		/*
		 * 
		 * 
		 * 
		 * CARD LEVEL 2 TOKENS
		 * 
		 * 
		 * */


		index = 0;
		CardLevel2Title [tk2 + index] = "Chemtrail";
		CardLevel2Art [tk2 + index] = "lvl2_tk_" + index.ToString ();
		CardLevel2Description [tk2 + index] = "Pollute a planet's environment.";

		CardLevel2HasReq [tk2 + index] = true;
		CardLevel2DisplayGrants [tk2 + index] = true;
		CardLevel2CanAffectAnotherPlayer [tk2 + index] = true; 
		CardLevel2HasScript [tk2 + index] = false; 

		CardLevel2Req1Name [tk2 + index] = 10;
		CardLevel2Req1Cost [tk2 + index] = 2;
		CardLevel2Req2Name [tk2 + index] = 9;
		CardLevel2Req2Cost [tk2 + index] = 5;

		CardLevel2GrantsName [tk2 + index] = 7;
		CardLevel2GrantsCost [tk2 + index] = 1;

		index = 1;
		CardLevel2Title [tk2 + index] = "Greater Ritual - Gold";
		CardLevel2Art [tk2 + index] = "lvl2_tk_" + index.ToString ();
		CardLevel2Description [tk2 + index] = "Double your gold amount.";

		CardLevel2HasReq [tk2 + index] = false;
		CardLevel2DisplayGrants [tk2 + index] = false;
		CardLevel2CanAffectAnotherPlayer [tk2 + index] = false; 
		CardLevel2HasScript [tk2 + index] = true; 

		CardLevel2Req1Name [tk2 + index] = 666;
		CardLevel2Req1Cost [tk2 + index] = 666;
		CardLevel2Req2Name [tk2 + index] = 666;
		CardLevel2Req2Cost [tk2 + index] = 666;

		CardLevel2GrantsName [tk2 + index] = 666;
		CardLevel2GrantsCost [tk2 + index] = 666;

		index = 2;
		CardLevel2Title [tk2 + index] = "Equilibrium";
		CardLevel2Art [tk2 + index] = "lvl2_tk_" + index.ToString ();
		CardLevel2Description [tk2 + index] = "Pay your economists to set a reasonable family policy. Set your population growth to 1.0.";

		CardLevel2HasReq [tk2 + index] = true;
		CardLevel2DisplayGrants [tk2 + index] = false;
		CardLevel2CanAffectAnotherPlayer [tk2 + index] = false; 
		CardLevel2HasScript [tk2 + index] = true; 

		CardLevel2Req1Name [tk2 + index] = 9;
		CardLevel2Req1Cost [tk2 + index] = 20;
		CardLevel2Req2Name [tk2 + index] = 6;
		CardLevel2Req2Cost [tk2 + index] = 5;

		CardLevel2GrantsName [tk2 + index] = 666;
		CardLevel2GrantsCost [tk2 + index] = 666;

		index = 3;
		CardLevel2Title [tk2 + index] = "Sell hydrogen";
		CardLevel2Art [tk2 + index] = "lvl2_tk_" + index.ToString ();
		CardLevel2Description [tk2 + index] = "Sell all your Hydrogen for 3 gold a unit.";

		CardLevel2HasReq [tk2 + index] = false;
		CardLevel2DisplayGrants [tk2 + index] = false;
		CardLevel2CanAffectAnotherPlayer [tk2 + index] = false; 
		CardLevel2HasScript [tk2 + index] = true; 

		CardLevel2Req1Name [tk2 + index] = 666;
		CardLevel2Req1Cost [tk2 + index] = 666;
		CardLevel2Req2Name [tk2 + index] = 666;
		CardLevel2Req2Cost [tk2 + index] = 666;

		CardLevel2GrantsName [tk2 + index] = 666;
		CardLevel2GrantsCost [tk2 + index] = 666;

		index = 4;
		CardLevel2Title [tk2 + index] = "Sell exomatter";
		CardLevel2Art [tk2 + index] = "lvl2_tk_" + index.ToString ();
		CardLevel2Description [tk2 + index] = "Sell all your Exomatter for 5 gold a unit.";

		CardLevel2HasReq [tk2 + index] = false;
		CardLevel2DisplayGrants [tk2 + index] = false;
		CardLevel2CanAffectAnotherPlayer [tk2 + index] = false; 
		CardLevel2HasScript [tk2 + index] = true; 

		CardLevel2Req1Name [tk2 + index] = 666;
		CardLevel2Req1Cost [tk2 + index] = 666;
		CardLevel2Req2Name [tk2 + index] = 666;
		CardLevel2Req2Cost [tk2 + index] = 666;

		CardLevel2GrantsName [tk2 + index] = 666;
		CardLevel2GrantsCost [tk2 + index] = 666;

		/*
		 * 
		 * 
		 * 
		 * 
		 * CARD LEVEL 3
		 * 
		 * 
		 * 
		 */


		index = 0;
		CardLevel3Title [index] = "Plagues";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Change water to blood. Spawn frogs, lice, and flies. Kill the livestock. Produce boils on skin. Create a hailstorm. Spawn locusts. Cover the sun. Kill the firstborn.\n\nReduce a chosen population by a million.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 10000;




		index = 1;
		CardLevel3Title [index] = "Throw into a black hole";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Throw a player into a black hole, if it exists.\n\n If there is no black hole, gain 10 Technology level";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = false;		
		CardLevel3CanAffectAnotherPlayer [index] = false; 
		CardLevel3HasScript [index] = true; 

		CardLevel3Req1Name [index] = 6;
		CardLevel3Req1Cost [index] = 20; 
		CardLevel3Req2Name [index] = 11;
		CardLevel3Req2Cost [index] = 25; 

		CardLevel3GrantsName [index] = 666; 
		CardLevel3GrantsCost [index] = 666;




		index = 2;
		CardLevel3Title [index] = "Self-replicating drones";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Self-replicating drones destroy a player's planet.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 500000;




		index = 3;
		CardLevel3Title [index] = "Throw into Sun";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Throw a player into the Sun";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 1000000;




		index = 4;
		CardLevel3Title [index] = "Throw into a wormhole";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Throw a player into a wormhole and send him God knows where.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 5; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 5; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 10000;




		index = 5;
		CardLevel3Title [index] = "Antimatter bomb";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Destroy a planet.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 1000000;




		index = 6;
		CardLevel3Title [index] = "Volcano explosion";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Activate all volvanoes on a chosen planet.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 1000000;




		index = 7;
		CardLevel3Title [index] = "Asteroid throw";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Throw an asteroid into a player.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 1000000;




		index = 8;
		CardLevel3Title [index] = "Alien invasion";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Send a word among aliens. Someone offended them recently.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 1000000;




		index = 9;
		CardLevel3Title [index] = "Hawking's Ray";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Cast black hole particles onto a planet.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 1000000;




		index = 10;
		CardLevel3Title [index] = "Sun destruction";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Annihalate the Sun. All players lose.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; //50
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 50; //20

		CardLevel3GrantsName [index] = 8; 
		CardLevel3GrantsCost [index] = 1000000;




		index = 11;
		CardLevel3Title [index] = "D.N.A. Virus";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Annihalate the Sun. All players lose.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 2;
		CardLevel3Req1Cost [index] = 50; 
		CardLevel3Req2Name [index] = 5;
		CardLevel3Req2Cost [index] = 25; 

		CardLevel3GrantsName [index] = 7; 
		CardLevel3GrantsCost [index] = 3;



		index = 12;
		CardLevel3Title [index] = "Dark Matter Bomb";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Throw a Dark Matter Bomb onto a planet.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = true;		
		CardLevel3CanAffectAnotherPlayer [index] = true; 
		CardLevel3HasScript [index] = false; 

		CardLevel3Req1Name [index] = 10;
		CardLevel3Req1Cost [index] = 50; 
		CardLevel3Req2Name [index] = 12;
		CardLevel3Req2Cost [index] = 25; 

		CardLevel3GrantsName [index] = 7; 
		CardLevel3GrantsCost [index] = 3;

		index = 13;
		CardLevel3Title [index] = "Create Black hole";
		CardLevel3Art [index] = "lvl3_" + index.ToString ();
		CardLevel3Description [index] = "Create a black hole.";

		CardLevel3HasReq [index] = true;
		CardLevel3DisplayGrants [index] = false;		
		CardLevel3CanAffectAnotherPlayer [index] = false; 
		CardLevel3HasScript [index] = true; 

		CardLevel3Req1Name [index] = 6;
		CardLevel3Req1Cost [index] = 20; 
		CardLevel3Req2Name [index] = 11;
		CardLevel3Req2Cost [index] = 25; 

		CardLevel3GrantsName [index] = 666; 
		CardLevel3GrantsCost [index] = 666;
	}







}
