using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int attack_power,block_power;
	public bool is_ground;

	void Start(){
		is_ground = false;
	}

	public int Damage(){
		int damage;
		if (is_ground) {
			damage = block_power;
		} else {
			damage = attack_power;
		}
		return damage;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			is_ground = true;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Ground") {
			is_ground = false;
		}
	}
}
