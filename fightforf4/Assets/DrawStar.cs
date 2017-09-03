using UnityEngine;
using System.Collections;

public class DrawStar : MonoBehaviour {
	public Texture2D texture;
	// Use this for initialization
	void OnGUI()
	{
		Rect rect = new Rect(Screen.width/2 - (texture.width/2),	//在屏幕中心绘制准心

			Screen.height - Screen.height/2 - (texture.height/2),
			//Input.mousePosition.y

			texture.width, texture.height);

		GUI.DrawTexture(rect, texture);
	}
}