using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour {

	public float speed = 1500f;
	public float rotationSpeed = 1000f;

	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;

	public Rigidbody2D rb;

	private float movement = 0f;
	private float rotation = 0f;

	void Update() {
		movement = -Input.GetAxisRaw("Vertical") * speed;
		rotation = Input.GetAxisRaw("Horizontal");

		if (Input.GetKey(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void FixedUpdate() {
		if (movement == 0f) {
			backWheel.useMotor = false;
			frontWheel.useMotor = false;
		} else {
			backWheel.useMotor = true;
			JointMotor2D motor_s = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWheel.motor.maxMotorTorque };
			backWheel.motor = motor_s;

			frontWheel.useMotor = true;
			JointMotor2D motor_f = new JointMotor2D { motorSpeed = movement, maxMotorTorque = frontWheel.motor.maxMotorTorque };
			frontWheel.motor = motor_f;
		}

		rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
	}

}
