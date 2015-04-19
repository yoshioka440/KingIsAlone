using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour {

	Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
	Dictionary<string, string> resourcePaths = new Dictionary<string, string>();

	List<string> prefabKeys = new List<string>();
	List<string> reuseKeys = new List<string>();

	static bool created = false;

	protected void Awake () {
		if(!created) {
			DontDestroyOnLoad(this.gameObject);
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

	public GameObject LoadPrefab (string key) {
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
