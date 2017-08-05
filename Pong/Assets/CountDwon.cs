using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDwon : MonoBehaviour
{
	private Animator CountDownAnim;     // カウントダウンアニメーション
	private bool GameStart;             // ゲームスタートフラグ

	[SerializeField]
	private Ball ball;					// ボール情報

	// Use this for initialization
	void Start()
	{
		// カウントダウンアニメーション情報取得
		CountDownAnim = GetComponent<Animator>();

		GameStart = false;              // ゲームスタートフラグ
	}

	// Update is called once per frame
	void Update()
	{
		if (GameStart == false)
		{
			// アニメが再生しているかどうか
			if (CountDownAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
			{
				Debug.Log("アニメ停止");

				// ゲームスタートフラグ オン
				GameStart = true;

				// ボールスタート
				ball.StartBall(0);
			}
		}
	}
}