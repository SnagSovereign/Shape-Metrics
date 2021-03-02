using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {

	[SerializeField] Vector3 spinSpeed;


	// Update is called once per frame
	private void Update()
	{
		transform.Rotate(spinSpeed, Space.Self);
	}
}
