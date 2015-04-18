using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InputArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	float dragBeginTime = 0;

	void Update () {
		if(!Input.anyKeyDown) return;
		if(Input.GetKeyDown(KeyCode.W)) {
			//W(oku)
			Debug.Log("W");
		}
		else if(Input.GetKeyDown(KeyCode.S)) {
			//S(center)
			Debug.Log("S");
		}
		else if(Input.GetKeyDown(KeyCode.X)) {
			//X(temae)
			Debug.Log("X");
		}
	}

	public void OnPointerDown (PointerEventData ped) {
		dragBeginTime = Time.time;
	}

	public void OnPointerUp (PointerEventData ped) {
		float t = Time.time - dragBeginTime;
		Vector3 pos = ped.position;
		Debug.Log("Time:" + t + ",Pos:" + pos);
	}
}
