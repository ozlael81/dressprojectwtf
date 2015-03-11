using UnityEngine;
using System.Collections;

public class PixelColorGetter {

	public RenderTexture texLeft = null;
	public RenderTexture texRight = null;

	// Use this for initialization
	//void Start () {
	//}
	
	// Update is called once per frame
	//void Update () {
	//	//if( Input.GetMouseButton(1)) {
		//	Color clr = GetColorOnMouse();
		//	Debug.Log ( "clr : " + clr.r + " " + clr.g + " " + clr.b );
		//}
	//}


	public Color GetColorOnMouse() {
		Vector3 mousePos = Input.mousePosition;
		float offsetX = mousePos.x / (float)Screen.width;
		float offsetY = mousePos.y / (float)Screen.height;
		
		Debug.Log ( "pos : " + offsetX + " " + offsetY);
		
		RenderTexture tex = texLeft;
		if( offsetX > 0.5f)
			tex = texRight;

		if( tex) {
			int x = (int)((float)tex.width * offsetX);
			int y = (int)((float)tex.height * offsetY);

			Texture2D myTexture2D = new Texture2D( tex.width, tex.height); 
			RenderTexture.active = tex;
			myTexture2D.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
			myTexture2D.Apply();

			return myTexture2D.GetPixel( x, y);

		}

		return Color.black;
	}


}
