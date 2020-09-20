using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingOrbits : MonoBehaviour
{
	public int segments;
	public float xradius;
	public float zradius;
	private float xradius_planet1;
	private float zradius_planet1;
	private float xradius_planet2;
	private float zradius_planet2;
	private float xradius_planet3;
	private float zradius_planet3;
	private float xradius_planet4;
	private float zradius_planet4;

	LineRenderer line;

	void Start ()
	{
		segments = 100; //HOW DETAILED THE CIRCLE SHOULD BE. It is actually not a circle, but a polygon!
		line = GameObject.Find ("Orbits/Orbit1").GetComponent<LineRenderer> ();

        
		line.positionCount = segments + 1;
		xradius_planet1 = 20;
		zradius_planet1 = 20;


		CreatePoints (xradius_planet1, zradius_planet1);

		if (PlrData.plr_total_count > 1) {
			line = GameObject.Find ("Orbits/Orbit2").GetComponent<LineRenderer> ();
			line.positionCount = segments + 1;
			xradius_planet2 = 30;
			zradius_planet2 = 30;
			CreatePoints (xradius_planet2, zradius_planet2);
		}
		if (PlrData.plr_total_count > 2) {
			line = GameObject.Find ("Orbits/Orbit3").GetComponent<LineRenderer> ();
			line.positionCount = segments + 1;
			xradius_planet3 = 40;
			zradius_planet3 = 40;
			CreatePoints (xradius_planet3, zradius_planet3);
		}

		if (PlrData.plr_total_count == 4) {
			line = GameObject.Find ("Orbits/Orbit4").GetComponent<LineRenderer> ();
			line.positionCount = segments + 1;
			xradius_planet4 = 50;
			zradius_planet4 = 50;
			CreatePoints (xradius_planet4, zradius_planet4);
		}

	}

	private void CreatePoints (float xradius, float zradius)
	{
		float x = 0f;
		float y = 0f;
		float z = 0f;
		float angle = 0f;
		for (int i = 0; i < segments + 1; i++) {
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * angle) * zradius;
			line.SetPosition (i, new Vector3 (x, y, z));
			angle += (360f / segments);
		}
	}
}