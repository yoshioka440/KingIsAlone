using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	List<EnemyInfo> enemiesInfo = new List<EnemyInfo>();

	// Use this for initialization
	void Start () {
		ImportMtbEnemys();
	}

	// Update is called once per frame
	void Update () {

	}

	List<EnemyInfo> ImportMtbEnemys () {
		Entity_SpawnEnemy entityEnemy = Resources.Load("Data/mtb_enemy_spawn_rate") as Entity_SpawnEnemy;
		List<EnemyInfo> enemies = new List<EnemyInfo>();

		var sheet = entityEnemy.sheets[0];
		for(int i = 0; i < sheet.list.Count; i++) {
			var entityList = sheet.list[i];
			EnemyInfo info = new EnemyInfo(entityList.id, entityList.kind, entityList.line, entityList.spawn_time, entityList.hit_point, entityList.speed);
			Debug.Log("ID:" + info.ID + ",Line:" + info.Line + ",Spawn:" + info.SpawnTime);
			enemies.Add(info);
		}

		return enemies;
	}
}
