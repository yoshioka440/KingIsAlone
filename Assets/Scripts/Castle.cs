using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public int hitPoint;

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
}
