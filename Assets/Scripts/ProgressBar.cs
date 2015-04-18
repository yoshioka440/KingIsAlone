using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {


	private float startingProgress = 0;
	private float currentProgress;
	public float endTime = 180.0f;
	private bool isEnd;

	// Use this for initialization
	void Start () {

		currentProgress = startingProgress;
	}
	
	// Update is called once per frame
	void Update () {
		
		// １秒進むと、1/180だけProgressBarが進む。
		currentProgress += Time.deltaTime * 100 / endTime;

		this.gameObject.GetComponent<Slider>().value = currentProgress;

		// 終了条件
		if (currentProgress >= endTime) {

			isEnd = true;
			currentProgress = 100.0f;
		}
	}


}
