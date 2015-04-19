using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InputArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	float dragBeginTime = 0;
	[SerializeField]
	Player player = null;

	public int SelectedShooter {
		get { return player.SelectedShooter.GetShooterNumber(); }
	}

	void Start () {
		
	}

	void Update () {
		if(!Input.anyKeyDown) return;
		if(player == null) return;

		if(Input.GetKeyDown(KeyCode.W)) {
			//W(oku)
			player.SelectShooter(2);
			Debug.Log("W");
		}
		else if(Input.GetKeyDown(KeyCode.S)) {
			//S(center)
			player.SelectShooter(1);
			Debug.Log("S");
		}
		else if(Input.GetKeyDown(KeyCode.X)) {
			//X(temae)
			player.SelectShooter(0);
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
