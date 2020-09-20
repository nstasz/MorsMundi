using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	public bool rotation_enabled;

	public float customizable_speed;
	public bool rotation_around_axis_bool;
	public float x;
	public float y;
	public float z;
	public float angle;
	public float start_position_angle;
	public float xradius;
	public float zradius;
	public float step;
	public float[] halt_positions;
	private double radius_helper;

	void Start ()
	{

		if (PlrData.settings_entered == true) {
			if (PlrData.settings_planet_speed == 10) {
				customizable_speed = 22.5f;
			}
			if (PlrData.settings_planet_speed == 9) {
				customizable_speed = 11.25f;
			}
			if (PlrData.settings_planet_speed == 8) {
				customizable_speed = 11.25f;
			}
			if (PlrData.settings_planet_speed == 7) {
				customizable_speed = 7.5f;
			}
			if (PlrData.settings_planet_speed == 6) {
				customizable_speed = 5.625f;
			}
			if (PlrData.settings_planet_speed == 5) {
				customizable_speed = 4.5f;
			}
			if (PlrData.settings_planet_speed == 4) {
				customizable_speed = 3.75f;
			}
			if (PlrData.settings_planet_speed == 3) {
				customizable_speed = 2.5f;
			}
			if (PlrData.settings_planet_speed == 2) {
				customizable_speed = 1.5f;
			}
			if (PlrData.settings_planet_speed == 1) {
				customizable_speed = 1;
			} 
				
		} else {
			customizable_speed = 22.5f;
		}

		rotation_around_axis_bool = true;
		start_position_angle = Vector3.SignedAngle (new Vector3 (1, 0, 0), gameObject.transform.position, Vector3.up);
        
		angle = start_position_angle;
		step = 0;
        
		radius_helper = Mathf.Abs ((float)(gameObject.transform.position.x + gameObject.transform.position.z));
     
		xradius = (float)radius_helper;
		zradius = xradius; 
		halt_positions = new float[16] {
			0f,
			22.5f,
			45f,
			67.5f,
			90f,
			112.5f,
			135f,
			157.5f,
			180f,
			202.5f,
			225f,
			247.5f,
			270f,
			292.5f,
			315f,
			337.5f
		};
	}


	void Update ()
	{
		RoationAroundAxis ();


		if (rotation_enabled == true) {
			//starting with angle 0 + start_position_angle

			x = Mathf.Cos (Mathf.Deg2Rad * angle * -1) * xradius; 
			z = Mathf.Sin (Mathf.Deg2Rad * angle * -1) * zradius;   
			gameObject.transform.position = new Vector3 (x, y, z);
           
			if (step == 3600) {
				step = 0;
			}


			foreach (float i in halt_positions) {
				if ((i * 10) == step) {
					


					GameObject.Find ("Sequencing").GetComponent<ArrivedOnStep> ().Arrival ();



				} else {
					//BackgroundSequencingInfo.planetStepCompleted = false;
				
				}
					
			}
			//calculations for the next frame:
			step += customizable_speed;
			angle = start_position_angle + (float)(step) / 10;

            
            
		}



	}

    

	void RoationAroundAxis ()
	{
		if (rotation_around_axis_bool == true) {
			transform.Rotate (0, 200 * Time.deltaTime, 0);
		}
	}


}