using UnityEngine;
using System.Collections;

public class AudioPlayer : SingletonMonoBehaviour<AudioPlayer> {

	[SerializeField]
	ResourceManager resource;

	public AudioClip[] clips;

	protected override void Awake () {
		base.Awake();
		//RegistAudios();
		resource.AddPrefab("AudioPlayer", "Prefabs/AudioPlayer");
	}

	void Start () {
		PlayBGM(0);
	}

	public void PlaySE (int num) {
		GameObject player = Instantiate(resource.GetPrefab("AudioPlayer")) as GameObject;
		AudioSource source = player.GetComponent<AudioSource>();
		source.PlayOneShot(clips[num]);
		float time = clips[num].length;
		StartCoroutine(DestroyPlayer(player, time));
	}

	public void PlayBGM (int num) {
		GameObject player = Instantiate(resource.GetPrefab("AudioPlayer")) as GameObject;
		AudioSource source = player.GetComponent<AudioSource>();
		source.clip = clips[num];
		source.loop = true;
		source.Play();
	}

	IEnumerator DestroyPlayer (GameObject player, float time) {
		yield return new WaitForSeconds(time);

		Destroy(player);
	}
}
