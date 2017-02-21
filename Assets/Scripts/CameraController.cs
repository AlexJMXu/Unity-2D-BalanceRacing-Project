using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	void FixedUpdate() {
		Vector3 targetPosition = target.position;
		targetPosition.z = transform.position.z;

		transform.position = targetPosition;
	}

}
