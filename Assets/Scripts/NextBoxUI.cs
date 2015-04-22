using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextBoxUI : MonoBehaviour {

	// UIオブジェクト
	public GameObject currentBulletImage;
	public GameObject nextBulletImage;
	public GameObject nextnextBulletImage;

	// Magagine
	public GameObject magazine;

	// プレイヤーからの受け取り用変数
	public GameObject player;
	private int selectedShooterNum;
	private Shooter selectedShooter;

	// Magazineからの取得用
	private BulletType[] bullet;

	// AssetsからSprites取得用
	public Sprite[] sprites;

	private Sprite[] bulletImage;

	public GameObject gameObject;

	void Awake () {
		
		// インスペクタで初期化してなかった時の処理
		if (currentBulletImage == null)  currentBulletImage	= GameObject.Find ("CurrentBulletImage");
		if (nextBulletImage == null) 	 nextBulletImage = GameObject.Find ("NextBulletImage");
		if (nextnextBulletImage == null) nextnextBulletImage = GameObject.Find ("NextNextBulletImage");

		if (magazine == null) magazine = GameObject.Find ("Magazine");
		print (magazine.name);

		if (player == null) player = GameObject.Find ("Player");
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
		selectedShooterNum = 1; // test
		print("player: " + player.name);
		print("player.GetComponent<Player>(): " + player.GetComponent<Player> ());
		print("SelectedShooter: " + player.GetComponent<Player> ().SelectedShooter);
		selectedShooter = player.GetComponent<Player> ().SelectedShooter;

		print (selectedShooter.name);


		// Shooter番号のMagazineを取得する
		// bullet[]には、各弾（Bed, Book, ... spoon, ...）が入っている
		bullet = new BulletType[3];
//		print(magazine.name);
//		print (magazine.GetComponent<Magaizine>());
//		print (magazine.GetComponent<Magaizine>().NowBullet(1));
//		print (magazine.GetComponent<Magaizine>().NowBullet(selectedShooterNum));
//		print (bullet [0]);
		bullet [0] = magazine.GetComponent<Magaizine> ().NowBullet(selectedShooterNum);
		bullet [1] = magazine.GetComponent<Magaizine> ().NextBullet (selectedShooterNum);
		bullet [2] = magazine.GetComponent<Magaizine> ().NextNextBullet (selectedShooterNum);

//		print ("bullet[0]: " + bullet[0]);
//		print ("sprite name: " + sprites[0].name);
//
		for (int i = 0; i < 3; i++) {
			print(bullet [i].ToString());
		}

//		foreach (Sprite sprite in sprites) {
//			print (sprite.name);
//		}

		// 初期化
		bulletImage = new Sprite[3];

		for (int i = 0; i < 3; i++) {
			foreach (Sprite sprite in sprites) {
//				if (bullet [i].ToString () == sprite.name) {
//					print (bullet [i].ToString () + " == " + sprite.name);
//				}

				if (string.Compare (bullet [i].ToString (), sprite.name, true) == 0) {
					print ("string.Compare, true: " + bullet [i].ToString () + ", " + sprite.name);
					bulletImage [i] = sprite;
				}
			}
		}

		for (int i = 0; i < 3; i++) {
			print ("bulletImage[" + i + "].name: " + bulletImage[i].name);
		}

//		//currentBulletImage.GetComponent<Image> ().sprite = sprites[0];
//		foreach (int i in bullet) {
//			foreach (Sprite sprite in sprites) {
//				
//				// Magazineクラスから受け取ったbullet(BulletType型)と、sprite画像の名前を比較する
//				// 文字列を比較し、同じであれば格納する。
//				// （spoonはAssetの画像名が小文字なので、別に比較する）
//				if (bullet [i].ToString() == sprite.name) {
//					bulletImage [i] = sprite;
//				}
//				else if (bullet[i].ToString() == "Spoon" && sprites[i].name == "spoon.png") {
//					bulletImage [i] = sprite;	
//				}
//			}
//		}
//
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