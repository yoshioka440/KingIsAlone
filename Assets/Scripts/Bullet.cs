using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int attack_power,block_power;
	public bool is_ground;
	[SerializeField]float destroy_wait_time;

	void Start(){
		is_ground = false;
	}

	public int Damage(){
		int damage;
		if (is_ground) {
			damage = block_power;
			Destroy (gameObject, destroy_wait_time);

		} else {
			damage = attack_power;
			Destroy (gameObject);
		}
		return damage;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			is_ground = true;
		}
		if (col.gameObject.tag == "Bullet") {
			is_ground = true;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Ground") {
			is_ground = false;
		}
	}
}
