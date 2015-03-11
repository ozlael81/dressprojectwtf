using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplitCanvasManager : MonoBehaviour {

	int screenWidth, screenHeight;
	PixelColorGetter pxClrGetter = null;

	public Image colorImage;
	

	// Update is called once per frame
	void Update () {
		UpdateCheckScreenSizeChanged();
		UpdateColorPicker();
	}

	void UpdateCheckScreenSizeChanged() {
		if( screenWidth != Screen.width || screenHeight != Screen.height) {
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			OnWindowResized();
		}
	}

	void UpdateColorPicker() {
		if( pxClrGetter == null)
			return;
		if( Input.GetMouseButton(1)) {
			Color clr = pxClrGetter.GetColorOnMouse();
			Debug.Log ( "clr : " + clr.r + " " + clr.g + " " + clr.b );
			if ( colorImage) {
				clr.a = colorImage.color.a;
				colorImage.color = clr;
			}
		}
	}

	void OnWindowResized() {
		pxClrGetter = new PixelColorGetter();
		RawImage [] objs = gameObject.GetComponentsInChildren<RawImage>();
		foreach( RawImage rawimg in objs) {
			if( rawimg) {
				Texture tex = rawimg.texture;
				RenderTexture rt = tex as RenderTexture;
				if( rt) {
					RenderTexture newrt = new RenderTexture( Screen.width, Screen.height, rt.depth);
					rawimg.texture = newrt;
					Camera cam = FindCameraUseRt( rt);
					if( cam) {
						cam.targetTexture = newrt;
					}
					// accum that first is left;
					if( pxClrGetter.texLeft == null) {
						pxClrGetter.texLeft = newrt;
					} else {
						pxClrGetter.texRight = newrt;
					}
				}
			}
		}
	}

	Camera FindCameraUseRt( RenderTexture rt) {
		Camera [] cams = FindObjectsOfType< Camera>();
		foreach( Camera cam in cams) {
			if( cam.targetTexture == rt) 
				return cam;
		}
		return null;
	}

}
