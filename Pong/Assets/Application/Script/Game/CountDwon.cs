using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDwon : MonoBehaviour
{
	public bool SoundFlag;

	private Animator CountDownAnim;     // カウントダウンアニメーション
	private bool GameStart;             // ゲームスタートフラグ

	[SerializeField]
	private Ball ball;                  // ボール情報
	private AudioSource SE_00;
	private AudioSource SE_01;
	private AudioSource SE_02;
	private int SoundCnt;

	// Use this for initialization
	void Start()
	{
		// カウントダウンアニメーション情報取得
		CountDownAnim = GetComponent<Animator>();

		GameStart = false;              // ゲームスタートフラグ
		SoundFlag = false;

		AudioSource[] audio = GetComponents<AudioSource>();
		SE_00 = audio[0];
		SE_01 = audio[1];
		SE_02 = audio[2];
	}

	// Update is called once per frame
	void Update()
	{
		if (GameStart == false)
		{
			// アニメが再生しているかどうか
			if (CountDownAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
			{
				//Debug.Log("アニメ停止");

				// ゲームスタートフラグ オン
				GameStart = true;

				// ボールスタート
				ball.StartBall(0);
			}
		}

		if(SoundFlag == true)
		{
			if(SoundCnt == 3)
			{
				SE_01.PlayOneShot(SE_01.clip);
			}
			else if (SoundCnt == 4)
			{
				SE_02.Play();
				SE_02.loop = true;
			}
			else
			{
				SE_00.PlayOneShot(SE_00.clip);
			}

			SoundCnt++;

			SoundFlag = false;
		}
	}
}