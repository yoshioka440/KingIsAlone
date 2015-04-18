﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	int hitPoint = -1;
	Vector3 travelling = new Vector3();

	// Use this for initialization
	void Start () {
		hitPoint = 100;
		travelling = Vector3.right;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(travelling * Time.deltaTime, Space.World);
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag != "Bullet") return;

		//hitPoint--;
	}
}
