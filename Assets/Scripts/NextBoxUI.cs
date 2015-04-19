using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextBoxUI : MonoBehaviour {

	// プレハブオブジェクト
	public GameObject currentBulletUI;
	public GameObject nextBulletUI;
	public GameObject nextnextBulletUI;

	// UIオブジェクト
	public GameObject currentBullet;
	public GameObject nextBullet;
	public GameObject nextnextBullet;

	// Magagine
	public GameObject magazine;

	// 
	private int playerSelectedShooterNum;

	void Awake () {
		
		// インスペクタで初期化してなかった時の処理
		if (currentBulletUI == null) 	currentBulletUI	= GameObject.Find ("CurrentBulletUI");
		if (nextBulletUI == null) 		nextBulletUI = GameObject.Find ("NextBulletUI");
		if (nextnextBulletUI == null)	nextnextBulletUI = GameObject.Find ("NextNextBulletUI");

	}

	// Use this for initialization
	void Start () {

		// Magazineを取得する
		if (magazine == false) {
			magazine = GameObject.Find ("Magazine");
		}

		// Playerが選択中のShooter番号を取得する

		// Shooter番号のMagazineを取得する

		// Magazine[Shooter番号]の、３つのBulletをcurrentBullet, nextBullet, nextnextBullet
		currentBullet = GameObject.Find ("Bullet");

		// test
		ShowUI ();

	}
	
	// Update is called once per frame
	void Update () {
	
		// Playerが操作している（選択している）Shooterが切り替わったら、装填されてる弾を変更する
		if (true /*Inputで切り替わる*/) {

			ChangeMagazine ();
		}
		// 

	}

	void ChangeMagazine () {

		// Playerどの大砲に切り替えたか（数字を取得する）
		//currentMagazineNum = Player.selectedShooterNum;
	}

	void ShowUI () {
		GameObject.Instantiate (currentBullet, currentBulletUI.transform.position, currentBulletUI.transform.rotation);
		//GameObject currentBullet = GameObject.Instantiate (currentBullet, currentBullet.transform.position, currentBullet.transform.rotation);
		currentBullet.transform.parent = transform;

		currentBullet.transform.position = currentBulletUI.GetComponent<RectTransform> ().transform.position;
		print ("currentBulletUI Pos: " + currentBulletUI.GetComponent<RectTransform>().transform.position);



//		Transform currentBulletTransform = currentBullet.GetComponent<Transform> ();
//
//		Vector3 currentBulletPos = Transform.
//		Vector3 currentBulletPos = Transform.InverseTransformVector (currentBulletTransform.position);
//
//		GameObject.Instantiate (currentBullet, currentBulletPos, Quaternion.identity);
	
	}
}