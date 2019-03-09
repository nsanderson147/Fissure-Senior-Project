using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField]
	int hp = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (hp < 0) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collide){
		if (collide.gameObject.name == "PlayerBullet") hp--;
	}
}
