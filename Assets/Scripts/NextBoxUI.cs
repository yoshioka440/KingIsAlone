using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextBoxUI : MonoBehaviour {

	// UIオブジェクト
	public GameObject currentBulletImage;
	public GameObject nextBulletImage;
	public GameObject nextnextBulletImage;

	// 格納用オブジェクト
	//public GameObject currentBullet;
	public GameObject nextBullet;
	public GameObject nextnextBullet;

	// プレハブオブジェクト(テスト用)
	public GameObject bulletPrefab;

	// Magagine
	public GameObject magazine;

	// プレイヤーからの受け取り用変数
	private int selectedShooterNum;
	// Magazineからの取得用
	private BulletType[] bullet;

	// Sprites取得
	public Sprite[] sprites;

	void Awake () {
		
		// インスペクタで初期化してなかった時の処理
		if (currentBulletImage == null)  currentBulletImage	= GameObject.Find ("CurrentBulletImage");
		if (nextBulletImage == null) 	 nextBulletImage = GameObject.Find ("NextBulletImage");
		if (nextnextBulletImage == null) nextnextBulletImage = GameObject.Find ("NextNextBulletImage");

		if (magazine == null) magazine = GameObject.Find ("Magazine");
	}

	// Use this for initialization
	void Start () {



		bullet [0] = BulletType.Spoon;
		bullet [1] = BulletType.Spoon;
		bullet [2] = BulletType.Spoon;

		Init ();

		ShowUI (); // test
	}

	void Init () {
		
		// Playerが選択中のShooter番号を取得する
		selectedShooterNum = 0; // test

		// Shooter番号のMagazineを取得する
		bullet [0] = magazine.GetComponent<Magaizine>().NowBullet(selectedShooterNum);
		bullet [1] = magazine.GetComponent<Magaizine> ().NextBullet (selectedShooterNum);
		bullet [2] = magazine.GetComponent<Magaizine> ().NextNextBullet (selectedShooterNum);

	}

	// Update is called once per frame
	void Update () {
	
		// Playerが操作している（選択している）Shooterが切り替わったら、装填されてる弾を変更する
		if (true /*selecetedShooterが切り替わる*/) {

			ChangeMagazine ();
		}
		// 

	}

	void ChangeMagazine () {

		// Playerどの大砲に切り替えたか（数字を取得する）
		//currentMagazineNum = Player.selectedShooterNum;
	}

	void ShowUI () {
		// test
		var currentBullet = GameObject.Instantiate (bulletPrefab, currentBulletImage.transform.position, currentBulletImage.transform.rotation) as GameObject;
		//GameObject currentBullet = GameObject.Instantiate (currentBullet, currentBullet.transform.position, currentBullet.transform.rotation);
		currentBullet.transform.parent = transform;

		currentBullet.transform.position = currentBulletImage.GetComponent<RectTransform> ().transform.position;
		print ("currentBulletUI Pos: " + currentBulletImage.GetComponent<RectTransform>().transform.position);


		// 本番
		// Shooter番号のMagazineを取得する
		bullet [0] = magazine.GetComponent<Magaizine>().NowBullet(selectedShooterNum);
		bullet [1] = magazine.GetComponent<Magaizine> ().NextBullet (selectedShooterNum);
		bullet [2] = magazine.GetComponent<Magaizine> ().NextNextBullet (selectedShooterNum);

		// bulletを表示する



//		Transform currentBulletTransform = currentBullet.GetComponent<Transform> ();
//
//		Vector3 currentBulletPos = Transform.
//		Vector3 currentBulletPos = Transform.InverseTransformVector (currentBulletTransform.position);
//
//		GameObject.Instantiate (currentBullet, currentBulletPos, Quaternion.identity);
	
	}
}