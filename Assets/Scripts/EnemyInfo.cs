using UnityEngine;
using System.Collections;

public class EnemyInfo {

	int id;
	string kind;
	int line;
	float spawnTime;
	int hitPoint;
	float speed;

	public int ID { get { return id; } }
	public string Kind { get { return kind; } }
	public int Line { get { return line; } }
	public float SpawnTime { get { return spawnTime; } }
	public int HP { get { return hitPoint; } }
	public float Speed { get { return speed; } }

	public EnemyInfo (int id, string kind, int line, float spawnTime, int hp, float speed) {
		this.id = id;
		this.kind = kind;
		this.line = line;
		this.spawnTime = spawnTime;
		this.hitPoint = hp;
		this.speed = speed;
	}
}
