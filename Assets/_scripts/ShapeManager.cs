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
		sideLength = float.Parse(userInputText.text);

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
		// square:
		perimeter = 4f * sideLength;
		area = Mathf.Pow(sideLength, 2f);
		// cube:
		volume = Mathf.Pow(sideLength, 3f);
		totalSurfaceArea = area * 6f;
	}

	private void CalculateCircle()
	{
		// circle:
		perimeter = 2f * Mathf.PI * sideLength;
		area = Mathf.PI * Mathf.Pow(sideLength, 2f);
		// sphere:
		volume = 4f / 3f * Mathf.PI * Mathf.Pow(sideLength, 3f);
		totalSurfaceArea = area * 4f;
	}

	private void CalculateTriangle()
	{
		// Equilateral triangle:
		perimeter = sideLength * 3f;
		area = Mathf.Sqrt(3f) / 4f * Mathf.Pow(sideLength, 2f);

		// Triangular based pyramid (equilateral):
		// length from the middle of the triangle to a vertex
		float midToVertex = sideLength * Mathf.Sqrt(3f) / 3f;
		// use pythagoras to calcualte the height of the triangular based pyramid
		float height = Mathf.Sqrt(Mathf.Pow(sideLength, 2f) - Mathf.Pow(midToVertex, 2f));
		volume = area * height / 3f;
		totalSurfaceArea = area * 4f;		
	}

	private void CalculateHexagon()
	{
		// hexagon:
		perimeter = sideLength * 6f;
		area = 3f * Mathf.Sqrt(3f) / 2f * Mathf.Pow(sideLength, 2f);
		// hexagonal prism:
		volume = area * sideLength;
		// TSA = 2 hexagons + 6 square sides
		totalSurfaceArea = area * 2 + Mathf.Pow(sideLength, 2f) * 6;
	}

	private void DisplayMetrics()
	{
		perimeterText.text = perimeter.ToString();
		areaText.text = area.ToString();
		volumeText.text = volume.ToString();
		tsaText.text = totalSurfaceArea.ToString();
	}
}
