using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public int hitPoint = 100;

	public int HP { get { return hitPoint; } }
	bool is_damaging=true;
	[SerializeField]float damage_wait_time;

	// Use this for initialization
	void Start () {
		hitPoint = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Enemy") {
			StartCoroutine ("Damaging");
		}
	}

	void OnCollisionExit(Collision col){
		StopCoroutine ("Damaging");
	}

//	public bool IsBroken () {
//		return (hitPoint <= 0) ? true : false;
//	}
//
	public bool IsBroken {
		get { return (hitPoint <= 0) ? true : false; }
	}

	IEnumerator Damaging(){
		while (is_damaging) {
			AudioPlayer.Instance.PlaySE(Random.Range(2, 4));
			hitPoint--;
			yield return new WaitForSeconds (damage_wait_time);
		}
	}
}
