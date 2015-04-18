using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	List<Enemy> ImportMtbEnemys () {
		Entity_SpawnEnemy entityEnemy = Resources.Load<Entity_SpawnEnemy>("Data/mtb_enemy_spawn_rate");
		List<Enemy> enemies = new List<Enemy>();


		return enemies;
	}
}
