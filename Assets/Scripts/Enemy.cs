﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	int hitPoint = -1;
	[SerializeField]
	float speed = 5f;
	Vector3 travelling = new Vector3();
	bool move_flag = true;
	Rigidbody rbody;
	[SerializeField]
	float interval;

	// Use this for initialization
	void Start () {
		hitPoint = 100;
		travelling = Vector3.left;
		rbody = gameObject.GetComponent<Rigidbody>();
		StartCoroutine("Move");
	}

	// Update is called once per frame
	void Update () {

		//transform.Translate(travelling * Time.deltaTime * speed, Space.World);
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Bullet") {
			Bullet bullet = col.gameObject.GetComponent<Bullet>();
			AudioPlayer.Instance.PlaySE(4);
			hitPoint -= bullet.Damage();
			if(hitPoint <= 0) {
				Destroy(gameObject);
			}
		}
	}

	public void Init (int hp, float speed) {
		this.hitPoint = hp;
		this.speed = speed;
	}

	IEnumerator Move () {

		while(move_flag) {
			rbody.velocity = travelling * speed;
			yield return new WaitForSeconds(interval);
		}
	}
}
