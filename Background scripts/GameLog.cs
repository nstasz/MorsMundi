using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLog : MonoBehaviour
{

	static public string log;
	static public int action_count;

	void Start ()
	{
		log = "";
		action_count = 0;
	}

	static public void AddLog (string whatHappened)
	{
		action_count += 1;
		log = "[" + action_count + ("] ") + whatHappened + "\n\n" + log; 
		print (log);
	}

}
