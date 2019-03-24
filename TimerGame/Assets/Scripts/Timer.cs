using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	public double time;
	public int InputMinute;
	public Material treatmentMaterial1;
	public Material treatmentMaterial2;
	public Material treatmentMaterial3;
	public Material treatmentMaterial4;
	public Material done1;
	public Material done2;
	public Material running;
	private bool Unstarted;
	private int flop;

	public double[] treatments;
	public Material[] treatmentMaterials; 
	public int disk;
	public Renderer rend;

	// Use this for initialization
	void Start ()
	{
		treatments = new double[4];
		treatmentMaterials = new Material[4];
		for (int i = 0; i < treatments.Length; i++)
		{
			int j = 600;
			treatments[i] = (j*(i+1));
			switch (i)
			{
				case 0:
					treatmentMaterials[i] = treatmentMaterial1;
					break;
				case 1:
					treatmentMaterials[i] = treatmentMaterial2;
					break;
				case 2:
					treatmentMaterials[i] = treatmentMaterial3;
					break;
				case 3:
					treatmentMaterials[i] = treatmentMaterial4;
					break;
				default:
					break;
			}
		}

		disk = 1;
		rend = this.GetComponent<Renderer>();
		Unstarted = true;
		flop = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		if((Unstarted == false) && (time > 0))
		{
			time -= Time.deltaTime;
		}

		else if (Unstarted == false)
		{
			if(flop == 1)
			{
				rend.material = done1;
				flop *= -1;
			}

			if (flop == -1)
			{
				rend.material = done2;
				flop *= -1;
			}
		}
	}

	private void OnMouseDown()
	{
		if(disk < 4)
		{
			disk++;
			rend.material = treatmentMaterials[disk-1];
		}

		else
		{
			disk = 1;
			rend.material = treatmentMaterials[disk-1];
		}
	}

	private void OnMouseOver()
	{
		if((Input.GetMouseButtonDown(1) && Unstarted == true))
		{
			time = treatments[disk - 1];
			Unstarted = false;
			rend.material = running;
		}
	}
}
