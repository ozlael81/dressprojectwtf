using UnityEngine;
using System.Collections;

public class LightFade : MonoBehaviour {

	public float fadeSpeed = 1;
	float initIntensity = 1;
	Light lit;

	float fadeMode = 0; 	// 0 : no  1 : incr  -1 : decr

	// Use this for initialization
	void Awake () {
		lit = gameObject. GetComponent<Light>();
		initIntensity = lit.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		if( fadeMode != 0 ) {
			lit.intensity += fadeMode * fadeSpeed * Time.deltaTime;
			if( lit.intensity < 0 ) {
				lit.intensity = 0;
				fadeMode = 0;
			}
			if( lit.intensity > initIntensity ) {
				lit.intensity = initIntensity;
				fadeMode = 0;
			}
		}
	}

	public void ToggleFade() {
		if( fadeMode >= 0 && lit.intensity > 0) {
			fadeMode = -1;
		} else {
			fadeMode = 1;
		}
	}

}
