using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeManager : MonoBehaviour {

	// UI objects
	[SerializeField] Dropdown shapeDropdown;
	[SerializeField] MeshFilter shapeModel;
	[SerializeField] SpriteRenderer shapeSprite;
	[SerializeField] Text userInputText, userInputLabel, perimeterText, areaText, volumeText, tsaText;

	float userInput, perimeter, area, volume, totalSurfaceArea;

	//When CALCULATE button clicked
	public void CalculateButton()
	{
		// set the side length equal to the user input
		userInput = float.Parse(userInputText.text);

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
			default:
				//error message
				Debug.LogError("Error! A shape must be selected!");
				break;
		}
		DisplayMetrics();
	}

	public void ChangeShape()
    {
		string shape, inputLabel = "Side Length:";
		switch (shapeDropdown.value)
        {
			case 0:
				//square
				shape = "square";
				break;
			case 1:
				//circle
				shape = "circle";
				inputLabel = "Radius:";
				break;
			case 2:
				//triangle
				shape = "triangle";
				break;
			case 3:
				//hexagon
				shape = "hexagon";
				break;
			default:
				//error message
				Debug.LogError("Error! A shape must be selected!");
				shape = null; //set shape to null so it not unassigned
				break;
		}
		// Display corresponding 3D and 2D shape and input label
		shapeModel.mesh = Resources.Load<Mesh>("models/" + shape);
		shapeSprite.sprite = Resources.Load<Sprite>("sprites/" + shape);
		userInputLabel.text = inputLabel;
		// clear the previous calculation results
		ClearMetrics();
	}

	private void CalculateSquare()
	{
		// square:
		perimeter = 4f * userInput;
		area = Mathf.Pow(userInput, 2f);
		// cube:
		volume = Mathf.Pow(userInput, 3f);
		totalSurfaceArea = area * 6f;
	}

	private void CalculateCircle()
	{
		// circle:
		perimeter = 2f * Mathf.PI * userInput;
		area = Mathf.PI * Mathf.Pow(userInput, 2f);
		// sphere:
		volume = 4f / 3f * Mathf.PI * Mathf.Pow(userInput, 3f);
		totalSurfaceArea = area * 4f;
	}

	private void CalculateTriangle()
	{
		// Equilateral triangle:
		perimeter = userInput * 3f;
		area = Mathf.Sqrt(3f) / 4f * Mathf.Pow(userInput, 2f);

		// Triangular based pyramid (equilateral):
		// length from the middle of the triangle to a vertex
		float midToVertex = userInput * Mathf.Sqrt(3f) / 3f;
		// use pythagoras to calcualte the height of the triangular based pyramid
		float height = Mathf.Sqrt(Mathf.Pow(userInput, 2f) - Mathf.Pow(midToVertex, 2f));
		volume = area * height / 3f;
		totalSurfaceArea = area * 4f;		
	}

	private void CalculateHexagon()
	{
		// hexagon:
		perimeter = userInput * 6f;
		area = 3f * Mathf.Sqrt(3f) / 2f * Mathf.Pow(userInput, 2f);
		// hexagonal prism:
		volume = area * userInput;
		// TSA = 2 hexagons + 6 square sides
		totalSurfaceArea = area * 2 + Mathf.Pow(userInput, 2f) * 6;
	}

    private void DisplayMetrics()
    {
        perimeterText.text = perimeter.ToString();
        areaText.text = area.ToString();
        volumeText.text = volume.ToString();
        tsaText.text = totalSurfaceArea.ToString();
    }

    private void ClearMetrics()
    {
		perimeterText.text = null;
		areaText.text = null;
		volumeText.text = null;
		tsaText.text = null;
	}
}
