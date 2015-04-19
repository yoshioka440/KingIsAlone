using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class Magaizine: MonoBehaviour{

	int initial_bullet;
	BulletType[][] bullet_arrays;
	int[] now_bullet_num;

	[SerializeField]ResourceManager rsmgr;

	// Use this for initialization
	void Awake () {

		initial_bullet = 200;
		bullet_arrays = new BulletType[3][];
		
		now_bullet_num = new int[3] {0,0,0};

		//大砲ごとのbullet
		for(int i=0;i<3;i++){
			bullet_arrays[i] = new BulletType[initial_bullet];

			bullet_arrays[i] = MakeBulletsList(initial_bullet);
		}

		for (int i = 0; i < Enum.GetNames (typeof(BulletType)).Length; i++) {
			string bullet_key, bullet_prefabs_path;
			bullet_key = ((BulletType)i).ToString ();
			Debug.Log (bullet_key);
			bullet_prefabs_path = "Prefabs/Bullet/" + bullet_key;
			rsmgr.AddPrefab (bullet_key, bullet_prefabs_path, false);

		}
		//StartCoroutine(rsmgr.LoadPrefabs ());
	}

	BulletType[] MakeBulletsList(int bullet_num){
		BulletType[] bullet = new BulletType[bullet_num];
		System.Random random = new System.Random ();

		for (int i = 0; i < bullet.Length; i++) {

			bullet [i] = (BulletType)random.Next (Enum.GetNames (typeof(BulletType)).Length);
		
		}
		return bullet;
	}


	public BulletType NowBullet(int shooter_num){
		return bullet_arrays [shooter_num][now_bullet_num [shooter_num]];
	}

	public BulletType NextBullet(int shooter_num){
		return bullet_arrays [shooter_num][now_bullet_num[shooter_num]+1];
	}

	public BulletType NextNextBullet(int shooter_num){
		return bullet_arrays [shooter_num][now_bullet_num[shooter_num]+2];
	}

	public void Next(int shooter_num){

		if (now_bullet_num[shooter_num] < initial_bullet-2) {
			now_bullet_num [shooter_num]++;	
		} else {
			now_bullet_num [shooter_num] = 0;
		}
	}

}

public enum BulletType{
	Bed,
	Book,
	Statue,
	Chair,
	Planter,
	Desk,
	Folk,
	Spoon,
	Cup
};