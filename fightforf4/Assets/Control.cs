using UnityEngine;
using System.Collections;
public class Control : MonoBehaviour {
	public float xRotation =0F;
	public float yRotation =0F;
	void Update() {
		xRotation += Input.acceleration.x;
		yRotation += Input.acceleration.y;
		transform.eulerAngles = new Vector3(yRotation, xRotation, 0);
		if (xRotation < -180)
			xRotation = -180;
		else if (xRotation >180)
			xRotation = 180;
		if (yRotation < -60)
			yRotation = -60;
		else if (yRotation >50)
			yRotation = 50;
	}
}