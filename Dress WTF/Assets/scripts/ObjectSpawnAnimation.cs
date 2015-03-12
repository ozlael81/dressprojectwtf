using UnityEngine;
using System.Collections;

public class ObjectSpawnAnimation : MonoBehaviour {

	private SmoothSpeedFactor smoothSpeed;
	public float speed = 1.0f;
	public float speedResistanceRatio = 1.5f;
	
	// Use this for initialization
	void Start () {
		smoothSpeed = new SmoothSpeedFactor( speed, speedResistanceRatio);
		MotionStart();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMove();
	}
	
	public void MotionStart() {
		smoothSpeed.StartToMove( 1);
	}
	
	void UpdateMove() {
		smoothSpeed.updateSpeed();
		Vector3 scale = new Vector3( 1.0f - smoothSpeed.GetCurrentSpeed(), 1.0f - smoothSpeed.GetCurrentSpeed(), 1.0f - smoothSpeed.GetCurrentSpeed()); 
		transform.localScale = scale;
	}
}
