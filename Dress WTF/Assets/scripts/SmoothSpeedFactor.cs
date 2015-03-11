using UnityEngine;
using System.Collections;

public class SmoothSpeedFactor {

	public float speed = 1;
	private float speedResistance;
	private float currSpeed;
	private float currDirection = 0;

	public SmoothSpeedFactor( float _speed, float speedResistanceRatio ) {
		speed = _speed;
		speedResistance = speed * speedResistanceRatio;
		currSpeed = 0;
		currDirection = 0;
	}

	public void updateSpeed() {
		UpdateResistance();
	}

	public void StartToMove( float delta) {
		if( delta == 0)
			return;
		else if( delta < 0 )
			currDirection = -1;
		else if( delta > 0)
			currDirection = 1;
		currSpeed = Mathf.Abs(delta) * speed;
	}

	void UpdateResistance() {
		currSpeed -= speedResistance * Time.deltaTime;;
		if( currSpeed < 0.01f)
			currSpeed = 0;
	}

	public float GetCurrentSpeed() {
		return currSpeed * currDirection;
	}

}
