using UnityEngine; 
using System.Collections;

public class FireAtPlayer : MonoBehaviour 
{
	public float bulletSpeed = 20f;
	public int maxInterval = 100;
	private int fireInterval;
	public Rigidbody bullet;
	public Transform player;

	void Start(){
		fireInterval = 0;
	}
	void Fire()
	{
		transform.LookAt(player);
		Rigidbody bulletClone = (Rigidbody) Instantiate(bullet, (transform.position + new Vector3(0, 2, 0)), transform.rotation);
		bulletClone.velocity = transform.forward * bulletSpeed;
	}

	void Update () 
	{
		if (fireInterval < maxInterval)
			fireInterval++;
		else {
			Fire ();
			fireInterval = 0;
		}
	}
}