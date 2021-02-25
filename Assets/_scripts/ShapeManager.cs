using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeManager : MonoBehaviour {

	// UI objects
	[SerializeField] Dropdown shapeDropdown;
	[SerializeField] Text userInputText, perimeterText, areaText, volumeText, tsaText;

	float sideLength, perimeter, area, volume, totalSurfaceArea;

	//When CALCULATE button clicked
	public void CalculateButton()
	{
		// set the side length equal to the user input
		sideLength = int.Parse(userInputText.text);

		switch (shapeDropdown.value)
		{
			case 0:
				//square
				CalculateSquare();
				break;
			case 1:
				//circle
				CalculateCircle();
				break;
			case 2:
				//triangle
				CalculateTriangle();
				break;
			case 3:
				//hexagon
				CalculateHexagon();
				break;
		}
		DisplayMetrics();
	}

	private void CalculateSquare()
	{
		// calculate all of the square metrics based on the user input
		perimeter = 4 * sideLength;
		area = Mathf.Pow(sideLength, 2f);
		volume = Mathf.Pow(sideLength, 3f);
		totalSurfaceArea = area * 6;
	}

	private void CalculateCircle()
	{
		// calculate all of the circle metrics based on the user input
		perimeter = 2f * Mathf.PI * sideLength;
		area = Mathf.PI * Mathf.Pow(sideLength, 2f);
		volume = 4f / 3f * Mathf.PI * Mathf.Pow(sideLength, 3f);
		totalSurfaceArea = area * 4;
	}

	private void CalculateTriangle()
	{
		// calculate all of the triangle metrics based on the user input
		perimeter = sideLength * 3f;
		area = Mathf.Sqrt(3f) / 4f * Mathf.Pow(sideLength, 2f);
		//float height = 
		//volume = area * height / 3;
		totalSurfaceArea = area * 4f;
	}

	private void CalculateHexagon()
	{
		// calculate all of the hexagon metrics based on the user input

	}

	private void DisplayMetrics()
	{
		perimeterText.text = perimeter.ToString();
		areaText.text = area.ToString();
		volumeText.text = volume.ToString();
		tsaText.text = totalSurfaceArea.ToString();
	}
}
