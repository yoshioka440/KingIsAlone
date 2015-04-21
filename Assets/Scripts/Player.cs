using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Shooter selectedShooter = null; //dummy
	[SerializeField]
	Color defaultCanonColor;
	[SerializeField]
	Color selectedCanonColor;

	[SerializeField]
	Shooter outside;	//奥
	[SerializeField]
	Shooter center;		//真ん中
	[SerializeField]
	Shooter inside;		//手前

	void Awake () {
		SelectShooter(0);
	}

	public Shooter SelectedShooter {
		get { return selectedShooter; }
	}

	public Shooter SelectShooter (int num) {
		if(selectedShooter == null) {
			selectedShooter = center; //dummy
		}

		Material current = selectedShooter.transform.parent.gameObject.GetComponent<Renderer>().material;

		switch(num) {
			case 0:
				current.color = defaultCanonColor;
				selectedShooter = inside;
				break;
			case 1:
				current.color = defaultCanonColor;
				selectedShooter = center;
				break;
			case 2:
				current.color = defaultCanonColor;
				selectedShooter = outside;
				break;
			default:
				return null;
		}

		Material next = selectedShooter.transform.parent.gameObject.GetComponent<Renderer>().material;
		next.color = selectedCanonColor;
		return selectedShooter;
	}
}
