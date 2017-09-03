using UnityEngine;
using System.Collections;
public class GravityControl : MonoBehaviour {
	public float xRotation =0F;
	public float yRotation =0F;
	void Update() {
		xRotation += Input.acceleration.x;
		yRotation += Input.acceleration.y;
		transform.eulerAngles = new Vector3(yRotation, xRotation, 0);
		if (xRotation < -5)
			xRotation = -5;
		else if (xRotation >5)
			xRotation = 5;
		if (yRotation < -5)
			yRotation = -5;
		else if (yRotation >5)
			yRotation = 5;
	}
}