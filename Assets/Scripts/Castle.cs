using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public int hitPoint = 100;

	public int HP { get { return hitPoint; } }

	// Use this for initialization
	void Start () {
		hitPoint = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log(col.gameObject);
		hitPoint--;
	}

//	public bool IsBroken () {
//		return (hitPoint <= 0) ? true : false;
//	}
//
	public bool IsBroken {
		get { return (hitPoint <= 0) ? true : false; }
	}
}
