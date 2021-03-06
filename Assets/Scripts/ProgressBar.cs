﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * プログレスバークラス
 * プログレスバーの管理を置こなう。時間の管理は自前
 **/
public class ProgressBar : MonoBehaviour {

	private float startingProgress = 0;
	private float currentProgress;
	public float endTime;	// = 180.0f;
	private bool isEnd = false;
	public bool IsEnd { get{ return isEnd; } }
	private float startTime = 0;

	// Use this for initialization
	void Start () {
		
		isEnd = false;
		startTime = Time.time;

		//ゲームスタート
		GameManager.Instance.StartGame();

		currentProgress = startingProgress;
	}
	
	// Update is called once per frame
	void Update () {
		
		// １秒進むと、1/180だけProgressBarが進む。
		currentProgress += Time.deltaTime * 100 / endTime;

		this.gameObject.GetComponent<Slider>().value = currentProgress;

		// 終了条件
		if (Time.time - startTime >= endTime) {

			isEnd = true;
			currentProgress = 100.0f;
		}
	}


}
