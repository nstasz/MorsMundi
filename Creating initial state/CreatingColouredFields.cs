using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingColouredFields : MonoBehaviour
{
	public GameObject blue_field;
	public GameObject red_field;
	public GameObject yellow_field;
	public GameObject start_field;
	private float xradius_planet1;
	private float zradius_planet1;
	private float xradius_planet2;
	private float zradius_planet2;
	private float xradius_planet3;
	private float zradius_planet3;
	private float xradius_planet4;
	private float zradius_planet4;
	float x = 0f;
	float y = 0f;
	float z = 0f;

	void Start ()
	{
		xradius_planet1 = 20;
		zradius_planet1 = 20;
		xradius_planet2 = 30;
		zradius_planet2 = 30;
		xradius_planet3 = 40;
		zradius_planet3 = 40;
		xradius_planet4 = 50;
		zradius_planet4 = 50;


		Create_blue_fields (xradius_planet1, zradius_planet1, 0);
		Create_red_fields (xradius_planet1, zradius_planet1, 0);
		Create_yellow_fields (xradius_planet1, zradius_planet1, 0);
		Create_start_fields (xradius_planet1, zradius_planet1, 0);

		if (PlrData.plr_total_count > 1) {
			Create_blue_fields (xradius_planet2, zradius_planet2, 1);
			Create_red_fields (xradius_planet2, zradius_planet2, 1);
			Create_yellow_fields (xradius_planet2, zradius_planet2, 1);
			Create_start_fields (xradius_planet2, zradius_planet2, 1);
		}

		if (PlrData.plr_total_count > 2) {
			Create_blue_fields (xradius_planet3, zradius_planet3, 2);
			Create_red_fields (xradius_planet3, zradius_planet3, 2);
			Create_yellow_fields (xradius_planet3, zradius_planet3, 2);
			Create_start_fields (xradius_planet3, zradius_planet3, 2);
		}

		if (PlrData.plr_total_count == 4) {
			Create_blue_fields (xradius_planet4, zradius_planet4, 3);
			Create_red_fields (xradius_planet4, zradius_planet4, 3);
			Create_yellow_fields (xradius_planet4, zradius_planet4, 3);
			Create_start_fields (xradius_planet4, zradius_planet4, 3);
		}

		enabled = false; //DISABLING THIS SCRIPT;
	}

	void Create_blue_fields (float xradius, float zradius, int plrNr)
	{

		int number_of_fields = 4;
		float angular_displacement = 45; //in angles (see Start field - it has no displacement)
		float angle = 0f;

		for (int i = 0; i < number_of_fields; i++) {
			x = Mathf.Sin (Mathf.Deg2Rad * (angle + angular_displacement)) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * (angle + angular_displacement)) * zradius;

			var creating_blue_fields = Instantiate (blue_field, new Vector3 (x, y, z), Quaternion.identity);
			creating_blue_fields.transform.parent = GameObject.Find ("PlayingFieldsPlr" + plrNr.ToString ()).transform;
			creating_blue_fields.name = "BlueField" + plrNr.ToString ();

			angle += (360f / number_of_fields);
		}
	}

	void Create_red_fields (float xradius, float zradius, int plrNr)
	{
		//unusual formula, because it calculates just 3 fields in a 4 field circle
		int number_of_fields = 3;
		float angular_displacement = 90; 
		float angle = 0f;

		for (int i = 0; i < number_of_fields; i++) { // normally number of fields + 1
			x = Mathf.Sin (Mathf.Deg2Rad * (angle + angular_displacement)) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * (angle + angular_displacement)) * zradius;

			var creating_red_fields = Instantiate (red_field, new Vector3 (x, y, z), Quaternion.identity);
			creating_red_fields.transform.parent = GameObject.Find ("PlayingFieldsPlr" + plrNr.ToString ()).transform;
			creating_red_fields.name = "RedField" + plrNr.ToString ();
			angle += (360f / 4); // divides the circle in 4, but we only draw 3 fields
		}
	}

	void Create_yellow_fields (float xradius, float zradius, int plrNr)
	{

		int number_of_fields = 2;
		float angular_displacement = 45 + 22.5f; //in angles
		float angle = 0f;

		for (int i = 0; i < number_of_fields; i++) {
			x = Mathf.Sin (Mathf.Deg2Rad * (angle + angular_displacement)) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * (angle + angular_displacement)) * zradius;

			var creating_yellow_fields = Instantiate (yellow_field, new Vector3 (x, y, z), Quaternion.identity);
			creating_yellow_fields.transform.parent = GameObject.Find ("PlayingFieldsPlr" + plrNr.ToString ()).transform;
			creating_yellow_fields.name = "YellowField" + plrNr.ToString ();
			angle += (360f / number_of_fields);
		}
	}

	void Create_start_fields (float xradius, float zradius, int plrNr)
	{

		int number_of_fields = 1;
		float angular_displacement = 0; 
		float angle = 0f;

		for (int i = 0; i < number_of_fields; i++) {
			x = Mathf.Sin (Mathf.Deg2Rad * (angle + angular_displacement)) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * (angle + angular_displacement)) * zradius;

			var creating_start_fields = Instantiate (start_field, new Vector3 (x, y, z), Quaternion.identity);
			creating_start_fields.transform.parent = GameObject.Find ("PlayingFieldsPlr" + plrNr.ToString ()).transform;
			creating_start_fields.name = "StartField" + plrNr.ToString ();
			angle += (360f / number_of_fields);
		}
	}
}
