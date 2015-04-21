using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	List<EnemyInfo> enemiesInfo = null;
	EnemyInfo next;
	float startTime = 0;

	[SerializeField]
	Transform spawnPoint;
	[SerializeField]
	GameObject resourceManager;

	void Awake () {
		resourceManager = ResourceManager.Instance.gameObject;
		RegistPrefabs();
	}

	public void StartSpawn () {
		Init();
		StartCoroutine(SpawnEnemies());
	}

	void Init () {
		enemiesInfo = ImportMtbEnemys();
		startTime = Time.time;
	}

	void RegistPrefabs () {

		ResourceManager mgr = resourceManager.GetComponent<ResourceManager>();
		mgr.AddPrefab("ENEMY0", "Prefabs/Enemy MushroomRed");
		mgr.AddPrefab("ENEMY1", "Prefabs/Enemy MushroomBlue");
		mgr.AddPrefab("ENEMY2", "Prefabs/Enemy goblin");
		mgr.AddPrefab("ENEMY3", "Prefabs/Enemy Necromancer");
		mgr.AddPrefab("ENEMY4", "Prefabs/Enrmy CaveWorm");
	}

	IEnumerator SpawnEnemies () {
		Debug.Log("Start spawn enemies");
		for(int i = 0; i < enemiesInfo.Count; i++) {
			next = enemiesInfo[i];
			float t = Time.time - startTime;
			if(next.SpawnTime > t) {
				yield return new WaitForSeconds(next.SpawnTime - t);
				InstantiateEnemy(next);
			}
		}
	}

	GameObject InstantiateEnemy (EnemyInfo info) {
		float zPos = -5f + info.Line * 5f;
		Vector3 pos = new Vector3(spawnPoint.position.x, spawnPoint.position.y, zPos);
		ResourceManager resource = resourceManager.GetComponent<ResourceManager>();
		GameObject enemyObj = Instantiate(resource.GetPrefab(info.Kind), pos, Quaternion.identity) as GameObject;
		Enemy enemy = enemyObj.GetComponent<Enemy>();
		enemy.Init(info.HP, info.Speed);
		return enemyObj;
	}

	List<EnemyInfo> ImportMtbEnemys () {
		/*
		Entity_SpawnEnemy entityEnemy = Resources.Load("Data/mtb_enemy_spawn_rate") as Entity_SpawnEnemy;

		var sheet = entityEnemy.sheets[0];
		for(int i = 0; i < sheet.list.Count; i++) {
			var entityList = sheet.list[i];
			EnemyInfo info = new EnemyInfo(entityList.id, entityList.kind, entityList.line, entityList.spawn_time, entityList.hit_point, entityList.speed);
			Debug.Log("ID:" + info.ID + ",Line:" + info.Line + ",Spawn:" + info.SpawnTime);
			enemies.Add(info);
		}

		return enemies;
		 */

		List<EnemyInfo> enemies = new List<EnemyInfo>();

		TextAsset mtbCsv = Resources.Load<TextAsset>("Data/mtb_enemy_spawn_rate");
		string[] lines = mtbCsv.text.Replace("\r\n", "\n").Split("\n"[0]);

		for(int i = 1; i<lines.Length; i++) {
			string line = lines[i];
			if(line == "") continue;
			string[] elements = line.Split(","[0]);

			if(elements[0] == "") continue;

			bool registFlag = true;
			registFlag = (elements[0] == "FALSE") ? false : true;
			if(!registFlag) continue;

			int id = int.Parse(elements[1]);
			string kind = (string)elements[2];
			int row = int.Parse(elements[3]);
			float spawnTime = float.Parse(elements[4]);
			int HP = int.Parse(elements[5]);
			float speed = float.Parse(elements[6]);

			EnemyInfo info = new EnemyInfo(id, kind, row, spawnTime, HP, speed);
			enemies.Add(info);
			//Debug.Log("ID:" + info.ID + ",Line:" + info.Line + ",Spawn:" + info.SpawnTime);
		}

		return enemies;
	}
}
