using UnityEngine;
using System.Collections;

//大砲の砲口にセットしたObjectにアタッチするScript
public class Shooter : MonoBehaviour {

	//アタッチしているGameObjectの大砲ナンバー:0~2
	[SerializeField]int shooter_num;
	Magaizine magazine;
	Camera main_camera;
	GameObject bullet_prefab;
	[SerializeField]float keisuu;

	// Use this for initialization
	void Start () {
		main_camera = Camera.current;
	}


	//上位存在によってMagazineインスタンスをセットしてもらう
	public void SetMagazine(Magaizine m_instance){
		magazine = m_instance;
	}

	//tame_time:ため時間
	//screen_vec:クリック座標
	public void Shoot(float tame_time,Vector2 screen_vec){
		Vector3 vec = Calcu_vec (screen_vec,gameObject.transform.position.z);

		/*
		 * bullet_prefabを取得する処理
		bullet_prefab = 
		*/
		GameObject bullet = Instantiate (bullet_prefab,
			                    gameObject.transform.position,
								bullet_prefab.transform.rotation) as GameObject;

		vec = keisuu * tame_time * vec;

		bullet.rigidbody.AddForce (vec);
	}

	//クリックされた座標から正規化した方向ベクトルを返す
	Vector3 Calcu_vec(Vector2 screen_vec,float z){
		Vector3 v = main_camera.ScreenToWorldPoint (screen_vec);
		v.z = z;

		Vector3 shoot_v = new Vector3 ();
		shoot_v = v - gameObject.transform.position;
		shoot_v = Vector3.Normalize (shoot_v);

		return shoot_v;
	}
}
