using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private int BulletTimer;
	[SerializeField]
	GameObject Target;
	void Start(){
		BulletTimer = 50;
	}
	void Update(){
		if (BulletTimer > 0)
			BulletTimer--;
		else Destroy (gameObject);
	}
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "enemypillar") Destroy (gameObject);
	}
}
