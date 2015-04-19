using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Shooter selectedShooter = null;

	[SerializeField]
	Shooter outside;	//奥
	[SerializeField]
	Shooter center;		//真ん中
	[SerializeField]
	Shooter inside;		//手前

	void Start () {
		SelectShooter(0);
	}

	public Shooter SelectedShooter {
		get { return selectedShooter; }
	}

	public Shooter SelectShooter (int num) {
		switch(num) {
			case 0:
				selectedShooter = inside;
				return selectedShooter;
			case 1:
				selectedShooter = center;
				return selectedShooter;
			case 2:
				selectedShooter = outside;
				return selectedShooter;
			default:
				return null;
		}
	}
}
