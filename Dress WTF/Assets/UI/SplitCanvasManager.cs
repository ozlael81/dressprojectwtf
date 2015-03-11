using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplitCanvasManager : MonoBehaviour {

	int screenWidth, screenHeight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( screenWidth != Screen.width || screenHeight != Screen.height) {
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			OnWindowResized();
		}
	}

	void OnWindowResized() {
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
				}
				//tex.width = Screen.width;
				//tex.height = Screen.height;
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
