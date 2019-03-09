using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Motor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private float jumpval = 10f;

	private bool onfloor = true;

	private Vector3 velocity = Vector3.zero;

	private Vector3 rotation =  Vector3.zero;

	private Vector3 cameraRotation = Vector3.zero;

	private Rigidbody rb;

	private bool jump;

	RaycastHit myhit = new RaycastHit();

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	public void Move (Vector3 _velocity){
		velocity = _velocity;
	}

	public void Rotate(Vector3 _rotation){
		rotation = _rotation;
	}

	public void RotateCamera(Vector3 _cameraRotation){
		cameraRotation = _cameraRotation;
	}

	public void TestJump(bool _jump){
		jump = _jump;
	}

	bool onGround(){
		return Physics.Raycast(transform.position, -Vector3.up, out myhit, 1.1f);
	}


	void FixedUpdate (){
		PerformMovement();
		PerformRotation();
	}

	void PerformMovement(){
		if (velocity != Vector3.zero) {
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
		if (jump&&onGround()) {
			rb.velocity = new Vector3(0, jumpval, 0);
		}
	}

	void PerformRotation(){
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		if (cam != null) {
			cam.transform.Rotate (-cameraRotation);
		}
	}
}
