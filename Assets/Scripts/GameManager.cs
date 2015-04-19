using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	private bool gameover;
	private bool cleared;

	[SerializeField]
	public GameObject castle;
	//[SerializeField]
	public GameObject progressBar;
	public GameObject enemySpawner;

	/**
	 * （時間初期化（ProgressBar初期化））
	 * （ステージ初期化（掃除、生成））
	 * （城の体力初期化）
	 * 生活用品（弾倉）初期化
	 * 敵の初期化
	 * （プレイヤー初期化）
	 **/
	void Awake () {

		// 生活用品（弾倉）初期化

		// EnemySpawnerの取得
//		enemySpawner = enemySpawner.GetComponent<EnemySpawner> ();

		// 終了条件、クリア条件の受け渡し
		gameover = castle.GetComponent<Castle> ().IsBroken;
		cleared = progressBar.GetComponent<ProgressBar> ().IsEnd;
	}

	/**
	 * プレイヤースタート
	 * 敵スタート
	 * 時間スタート 
	 **/
	// Use this for initialization
	void Start () {

		// EnemySpawnerの初期化
//		enemySpawner.StartSpawn();

		// ResourceManagerの初期化
		GetComponent<ResourceManager>().LoadPrefabs();
	}

	/**
	 * 敵の進行が終了、進行時間がMax
	 * 城の体力が０ 
	 **/
	// Update is called once per frame
	void Update () {



		gameover = castle.GetComponent<Castle> ().IsBroken;
		cleared = progressBar.GetComponent<ProgressBar> ().IsEnd;

		// 終了判定
		if (gameover) {
			GameOver ();
		}

		// クリア判定
		if (cleared) {

		}
	}

	// 終了処理
	void GameOver () {

		// ゲーム画面を止める、画面表示、シーンの遷移などなど

	}
		
	// クリア処理
	void Clear () {

		// ゲーム画面を止める、画面表示、ファンファーレ、シーンの遷移など

	}
}
