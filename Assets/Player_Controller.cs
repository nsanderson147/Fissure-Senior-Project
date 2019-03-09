
using UnityEngine;

[RequireComponent(typeof(Player_Motor))]
public class Player_Controller : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float looksens = 3f;

	private Player_Motor motor;

	void Start () {
		motor = GetComponent<Player_Motor>();
		Screen.lockCursor = true;
	}

	void Update () {
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw("Vertical");
		bool _jump = Input.GetKeyDown ("space");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

		motor.Move(_velocity);

		//Calculate Rotation
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * looksens;

		//Apply rotation
		motor.Rotate(_rotation);

		//Calculate Camera Rotation
		float _xRot = Input.GetAxisRaw("Mouse Y");
		_xRot = Mathf.Clamp(_xRot, -30f, 60f); 
		Vector3 _cameraRotation = new Vector3 (_xRot, 0f, 0f) * looksens;

		//Apply camera rotation
		motor.RotateCamera(_cameraRotation);

		//Send jump input
		motor.TestJump(_jump);
	}
}
