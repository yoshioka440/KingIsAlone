using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleHPBar : MonoBehaviour {

	private float startingCastleHP;
	private float currentCastleHP;
	private bool isEnd;
	[SerializeField]
	private GameObject castle;

	void Awake () {
		//castle = GameObject.Find ("AllCastle");
	}

	// Use this for initialization
	void Start () {

		isEnd = false;

		currentCastleHP = castle.GetComponent<Castle> ().HP;
	}
	
	// Update is called once per frame
	void Update () {
	
		currentCastleHP = castle.GetComponent<Castle> ().HP;

		// １秒進むと、1/180だけProgressBarが進む。
//		currentCastleHP += Time.deltaTime * 100 / endTime;

		this.gameObject.GetComponent<Slider>().value = currentCastleHP;

		// 終了条件(スライドしないように固定のみ)
		if (currentCastleHP <= 0) {

			currentCastleHP = 0;

		}
	}
}
