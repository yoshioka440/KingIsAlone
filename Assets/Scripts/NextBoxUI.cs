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

	// 
	private Sprite[] bulletImage;

	void Awake () {
		
		// インスペクタで初期化してなかった時の処理
		if (currentBulletImage == null)  currentBulletImage	= GameObject.Find ("CurrentBulletImage");
		if (nextBulletImage == null) 	 nextBulletImage = GameObject.Find ("NextBulletImage");
		if (nextnextBulletImage == null) nextnextBulletImage = GameObject.Find ("NextNextBulletImage");

		if (magazine == null) magazine = GameObject.Find ("Magazine");
	}

	// Use this for initialization
	void Start () {

		// 弾の画像変更
		ChangeImage ();

		// 画像の表示
		//ShowUI ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		// Playerが操作している（選択している）Shooterが切り替わったら、装填されてる弾を変更する
		if (true /*selecetedShooterが切り替わる*/) {

			// 弾の画像変更 
			//ChangeImage ();

			// 画像の変更、表示
			//ShowUI ();
		}
	}

	// 弾の画像変更
	void ChangeImage () {

		// Playerが選択中のShooter番号を取得する
		selectedShooterNum = 0; // test

		/* ... */


		// Shooter番号のMagazineを取得する
		// bullet[]には、各弾（Bed, Book, ... spoon, ...）が入っている
		bullet [0] = magazine.GetComponent<Magaizine> ().NowBullet(selectedShooterNum);
		bullet [1] = magazine.GetComponent<Magaizine> ().NextBullet (selectedShooterNum);
		bullet [2] = magazine.GetComponent<Magaizine> ().NextNextBullet (selectedShooterNum);

		print ("bullet[0]: " + bullet[0]);

		// Spritesの初期化
		//sprites[] = Resources.Load(/Sprites/)
		//sprites[0] = Resources.Load("Sprite/Bed.png") as Sprite;

		print ("sprite name: " + sprites[0].name);

		// 初期化
		bulletImage [0] = sprites [0];
		bulletImage [1] = sprites [1];
		bulletImage [2] = sprites [2];

		//currentBulletImage.GetComponent<Image> ().sprite = sprites[0];
		foreach (int i in bullet) {
			foreach (Sprite sprite in sprites) {
				
				// Magazineクラスから受け取ったbullet(BulletType型)と、sprite画像の名前を比較する
				// 文字列を比較し、同じであれば格納する。
				// （spoonはAssetの画像名が小文字なので、別に比較する）
				if (bullet [i].ToString() == sprite.name) {
					bulletImage [i] = sprite;
				}
				else if (bullet[i].ToString() == "Spoon" && sprites[i].name == "spoon.png") {
					bulletImage [i] = sprite;	
				}
			}
		}

		currentBulletImage.GetComponent<Image> ().sprite = bulletImage [0];
		nextBulletImage.GetComponent<Image> ().sprite = bulletImage[1];
		nextnextBulletImage.GetComponent<Image> ().sprite = bulletImage[2];
	}

//	// 画像の変更、表示
//	void ShowUI () {
//		// test
//		var currentBullet = GameObject.Instantiate (currentBulletImage, currentBulletImage.transform.position, currentBulletImage.transform.rotation) as GameObject;
//		//GameObject currentBullet = GameObject.Instantiate (currentBullet, currentBullet.transform.position, currentBullet.transform.rotation);
//		currentBullet.transform.parent = transform;
//
//		currentBullet.transform.position = currentBulletImage.GetComponent<RectTransform> ().transform.position;
//		print ("currentBulletUI Pos: " + currentBulletImage.GetComponent<RectTransform>().transform.position);
//
//
//		// 本番
//		// Shooter番号のMagazineを取得する
//		bullet [0] = magazine.GetComponent<Magaizine>().NowBullet(selectedShooterNum);
//		bullet [1] = magazine.GetComponent<Magaizine> ().NextBullet (selectedShooterNum);
//		bullet [2] = magazine.GetComponent<Magaizine> ().NextNextBullet (selectedShooterNum);
//
//		// bulletを表示する
//
//
////		Transform currentBulletTransform = currentBullet.GetComponent<Transform> ();
////
////		Vector3 currentBulletPos = Transform.
////		Vector3 currentBulletPos = Transform.InverseTransformVector (currentBulletTransform.position);
////
////		GameObject.Instantiate (currentBullet, currentBulletPos, Quaternion.identity);
//	
//	}
}