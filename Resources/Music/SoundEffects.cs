using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
	public AudioSource MyAudioSource;
	public AudioClip a_hover_sound;



	void OnMouseEnter ()
	{
		print ("play sound");
		MyAudioSource.PlayOneShot (a_hover_sound);

		//SoundManager.Play ("sound_hover_card");
	}
}
