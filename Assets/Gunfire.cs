using UnityEngine; 
using System.Collections;

public class Gunfire : MonoBehaviour 
{
	public float bulletSpeed = 10f;
	public Rigidbody bullet;


	void Fire()
	{
		Rigidbody bulletClone = (Rigidbody) Instantiate(bullet, transform.position, transform.rotation);
		bulletClone.velocity = -transform.up * bulletSpeed;
	}

	void Update () 
	{
		if (Input.GetButtonDown("Fire1"))
			Fire();
	}
}