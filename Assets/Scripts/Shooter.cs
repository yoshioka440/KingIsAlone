using UnityEngine;
using System.Collections;

//大砲の砲口にセットしたObjectにアタッチするScript
public class Shooter : MonoBehaviour {

	//アタッチしているGameObjectの大砲ナンバー:0~2
	[SerializeField]int shooter_num;
	[SerializeField]Magaizine magazine;
	Camera main_camera;
	GameObject bullet_prefab;
	[SerializeField]float keisuu;
	[SerializeField]ResourceManager rsmgr;
	[SerializeField]GameObject playerpos;
	float now_waiting_time;
	[SerializeField]float shoot_wait_time;

	// Use this for initialization
	void Start () {
		main_camera = Camera.main;
	}

	void Update(){
		now_waiting_time += Time.deltaTime;
	}

	//tame_time:ため時間
	//screen_vec:クリック座標
	public void Shoot(float tame_time,Vector2 screen_vec){
		if(now_waiting_time >= shoot_wait_time){
			Vector3 vec = Calcu_vec (screen_vec,gameObject.transform.position.z-main_camera.gameObject.transform.position.z);

			bullet_prefab = rsmgr.GetPrefab (magazine.NowBullet (shooter_num).ToString ());
			Debug.Log (magazine.NowBullet (shooter_num).ToString ());
			AudioPlayer.Instance.PlaySE(2);
			GameObject bullet = Instantiate (bullet_prefab,
				                    gameObject.transform.position,
									bullet_prefab.transform.rotation) as GameObject;

			vec = keisuu * tame_time * vec;

			bullet.GetComponent<Rigidbody>().AddForce (vec);
			magazine.Next (shooter_num);
			now_waiting_time = 0;
		}
	}

	//クリックされた座標から正規化した方向ベクトルを返す
	Vector3 Calcu_vec(Vector2 screen_vec,float z){

		Vector3 direction = new Vector3(screen_vec.x, screen_vec.y,z);
		Vector3 v = main_camera.ScreenToWorldPoint (direction);
		//v.z = 0;

		Vector3 shoot_v = new Vector3 ();
		shoot_v = v - gameObject.transform.position;

		shoot_v = Vector3.Normalize (shoot_v);

		return shoot_v;
	}

	public Vector3 GetPlayerPosition(){
		return playerpos.transform.position;
	}

	public int GetShooterNumber(){
		return shooter_num;
	}
}
