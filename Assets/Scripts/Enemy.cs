using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	int hitPoint = -1;
	float speed = 1f;
	Vector3 travelling = new Vector3();

	// Use this for initialization
	void Start () {
		//hitPoint = 100;
		travelling = Vector3.left;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(travelling * Time.deltaTime * speed, Space.World);
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag != "Bullet") return;

		//hitPoint--;
	}

	public void Init (int hp, float speed) {
		this.hitPoint = hp;
		this.speed = speed;
	}
}
