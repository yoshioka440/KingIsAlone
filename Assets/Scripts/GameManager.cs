using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {


	private bool gameover;
	private bool cleared;

	public Castle castle;
	public EnemySpawner enemySpawner;
	public ProgressBar progressBar;

	/**
	 * （時間初期化（ProgressBar初期化））
	 * （ステージ初期化（掃除、生成））
	 * （城の体力初期化）
	 * 生活用品（弾倉）初期化
	 * 敵の初期化
	 * （プレイヤー初期化）
	 **/
	// Use this for initialization
	void Start () {

		gameover = false;
		cleared = false;
		// ResourceManagerの初期化
		GetComponent<ResourceManager>().LoadPrefabs();
	
	}

	/**
	 * プレイヤースタート
	 * 敵スタート
	 * 時間スタート 
	 **/
	public void StartGame () {
		// EnemySpawnerがスポーン開始
		enemySpawner.StartSpawn();
	}

	/**
	 * 敵の進行が終了、進行時間がMax
	 * 城の体力が０ 
	 **/
	// Update is called once per frame
	void Update () {


		gameover = castle.IsBroken;
		cleared = progressBar.IsEnd;

		// 終了判定
		if (gameover) {
			GameOver ();
		}

		// クリア判定
		if (cleared) {
			Clear();
		}
	}

	// 終了処理
	void GameOver () {
		Debug.Log("GameOver");
		// ゲーム画面を止める、画面表示、シーンの遷移などなど
		StopAllCoroutines();
		Application.LoadLevel("Restart");
	}
		
	// クリア処理
	void Clear () {
		Debug.Log("GameClear");
		StopAllCoroutines();
		Application.LoadLevel("GameClear");
		// ゲーム画面を止める、画面表示、ファンファーレ、シーンの遷移など

	}
}
