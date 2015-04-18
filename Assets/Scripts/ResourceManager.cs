using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour {

	Dictionary<string, GameObject> prefabs;
	Dictionary<string, string> resourcePaths;

	List<string> prefabKeys;
	List<string> reuseKeys;

	static bool created = false;

	protected void Awake () {
		if(!created) {
			DontDestroyOnLoad(this.gameObject);
			prefabKeys = new List<string>();
			reuseKeys = new List<string>();
			prefabs = new Dictionary<string, GameObject>();
			resourcePaths = new Dictionary<string, string>();
			created = true;
			return;
		}
		Destroy(this.gameObject);
	}

	public IEnumerator LoadPrefabs () {
		string s = "OK";
		try {
			foreach(string key in prefabKeys) {
				LoadPrefab(key);
			}
		}
		catch(System.Exception e) {
			s = e.Message;
		}

		yield return s;
	}

	GameObject LoadPrefab (string key) {
		if(prefabs.ContainsKey(key)) return prefabs[key];

		prefabs.Add(key, Resources.Load<GameObject>(resourcePaths[key]));
		return prefabs[key];
	}

	public bool AddPrefab (string key, string resourcePath, bool reuseFlag = false) {
		if(prefabKeys.Contains(key)) { Debug.Log(key + " already added"); return false; }

		prefabKeys.Add(key);
		resourcePaths.Add(key, resourcePath);
		if(reuseFlag) reuseKeys.Add(key);
		return true;
	}

	public GameObject GetPrefab (string key) {
		if(prefabs.ContainsKey(key)) return prefabs[key];

		return LoadPrefab(key);
	}
}
