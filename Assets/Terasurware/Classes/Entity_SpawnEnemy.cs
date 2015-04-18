using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_SpawnEnemy : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public bool enable;
		public int id;
		public string kind;
		public int line;
		public float spawn_time;
		public int hit_point;
		public float speed;
	}
}

