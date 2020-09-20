using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCard : MonoBehaviour
{

	public static int CurrentCardType;
	public static int CurrentAbsoluteCardNumber;
	public static bool IsPlayedFromHand;
	public static bool WillRemainInHand;
	public static bool AnimationCompleted;

	public static int BargainConditionIndex;
	public static float BargainConditionCost;
	public static int BargainGrantsIndex;
	public static float BargainGrantsCost;

	public void Start ()
	{
		CurrentCardType = 0;
		CurrentAbsoluteCardNumber = 0;
		IsPlayedFromHand = false;
		WillRemainInHand = false;
		AnimationCompleted = true;
		BargainConditionIndex = 0;
		BargainConditionCost = 0;
		BargainGrantsIndex = 0;
		BargainGrantsCost = 0;

	}
}
