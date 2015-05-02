using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextBoxUI : MonoBehaviour {

	// UIオブジェクト
	public GameObject currentBulletImage;
	public GameObject nextBulletImage;
	public GameObject nextnextBulletImage;

	// Magagzine
	public GameObject magazine;
	private Magaizine magazineScript;

	// プレイヤーからの受け取り用変数
	public GameObject player;
	private Player playerScript;
	
	// プライヤーが選択している大砲の番号
	private int selectedShooterNum;
	private int currentShooterNum;
	private Shooter selectedShooter;

	// Magazineからの取得用
	private BulletType[] bullet;
	// 
	private BulletType[] currentBullet;
	
	// AssetsからSprites取得用
	public Sprite[] sprites;
	// 弾の画像取得用
	private Sprite[] bulletImage;


	void Awake () {
		
		// インスペクタで初期化してなかった時の処理
		if (currentBulletImage == null)  currentBulletImage	= GameObject.Find ("CurrentBulletImage");
		if (nextBulletImage == null) 	 nextBulletImage = GameObject.Find ("NextBulletImage");
		if (nextnextBulletImage == null) nextnextBulletImage = GameObject.Find ("NextNextBulletImage");

		if (magazine == null) magazine = GameObject.Find ("Magazine");
		
		if (player == null) {
			player = GameObject.Find ("Player");
			//playerScript = player.GetComponent<Player> ();
		}
	}

	// Use this for initialization
	void Start () {
		
		// bulletの初期化 
		//bullet = new BulletType[3];
		// Playerコンポーネントの参照を取得する
		//playerScript = player.GetComponent<Player> ();
		// 弾の画像の参照を取得する
		//bulletImage = new Sprite[3];
		
		// 弾の画像変更
		ChangeBullet ();

		// 画像の表示
		ShowUI ();
		
		// 現在の大砲の番号の取得
		//currentShooterNum = playerScript.SelectedShooter.GetShooterNumber ();
		//currentBullet = bullet;
		
		// テスト
		int i;
		for (i=0; i<3; i++) {
			print("ShooterNum: " + i + ", NowBullet: " + magazine.GetComponent<Magaizine> ().NowBullet(i).ToString ());
			print("ShooterNum: " + i + ", NextBullet: " + magazine.GetComponent<Magaizine> ().NextBullet (i). ToString ());
			print("ShooterNum: " + i + ", NextNextBullet: " + magazine.GetComponent<Magaizine> ().NextNextBullet (i). ToString ());	
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

//		// 力技で良ければ、Update()の中身は以下二行でOK
 		ChangeBullet (); 
 		ShowUI ();
		
		// 弾の参照を変更する
// 		ChangeBullet ();
// 		print("selectedShooterNum: " + selectedShooterNum);	
// 		
		// Playerが操作している（選択している）Shooterが切り替わったら、装填されてる弾を変更する
		//if (currentShooterNum != selectedShooterNum) {	
		// 弾の配列の値が変更していたら、表示画像を変更する
// 		if (currentBullet != bullet) {	
// 			//currentShooterNum = playerScript.SelectedShooter.GetShooterNumber ();
// 			print("ShowUI ()");		
// 	 		currentBullet = bullet;
// 			 
// 			// 画像の表示
// 			ShowUI ();
//  		}
// 		
// 		// 弾の参照を変更する
// 		ChangeBullet ();
		//print("selectedShooterNum: " + selectedShooterNum);	
	}

	// 弾の参照を取得する
	void ChangeBullet () {
		
		// Playerが選択中のShooter番号を取得する
// 		selectedShooterNum = 1; // test
// 		print("player: " + player.name);
// 		print("player.GetComponent<Player>(): " + player.GetComponent<Player> ());
// 		print("SelectedShooter: " + player.GetComponent<Player> ().SelectedShooter);
		selectedShooter = player.GetComponent<Player> ().SelectedShooter;
		selectedShooterNum = selectedShooter.GetShooterNumber ();
		
		print ("selectedShooterNum" + selectedShooterNum);
// 		print ("GetShooterNumber: " + selectedShooter.GetShooterNumber());

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
	}


	// 画像の変更、表示
	void ShowUI () {
		
		// 弾の画像の参照を取得する
		bulletImage = new Sprite[3];
		
		// 弾薬の配列と、スプライト画像
		for (int i = 0; i < 3; i++) {
			foreach (Sprite sprite in sprites) {
				
				// 弾の名前とスプライト画像名の文字列を（大文字、小文字関係なく）、比較して同じだったら、
				// その画像（sprite）を弾の配列（bulletImage[]）に格納する。
				if (string.Compare (bullet [i].ToString (), sprite.name, true) == 0) {
					//print ("string.Compare, true: " + bullet [i].ToString () + ", " + sprite.name);
					bulletImage [i] = sprite;
				}
				//print ("bulletImage[" + i + "].name: " + bulletImage[i].name);
			}
		}

		// UIの各Imageオブジェクトに画像を格納する
		currentBulletImage.GetComponent<Image> ().sprite = bulletImage [0];
		nextBulletImage.GetComponent<Image> ().sprite = bulletImage[1];
		nextnextBulletImage.GetComponent<Image> ().sprite = bulletImage[2];	
	}
}