using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
	//public class//
	public ResultController resultcontroller;
	public GaugeController gaugecontroller;
	public float Speed;
	public int Rote;

	//private class//
	private static int Set_Score;
	private int MoveCount;			// プレイヤーが動き出す時間計測用
	private bool GameSetFlag;		// ゲーム終了フラグ
	private int GameSetCount;		// ゲーム終了してからフェードまでをカウント

	// Use this for initialization
	void Start()
	{
		Set_Score = 0;
		Speed = 1.5f;
		Rote = 15;
		MoveCount = 0;
	}

	// Update is called once per frame
	void Update()
	{
		// 上方向移動
		if (Input.GetAxisRaw("Vertical2") > 0)
		{
			// 角度変更
			transform.rotation = Quaternion.Euler(0, -DEFINE.PLAYER_ANGLE, 0);

			// 一定以上長押しされたら移動
			if (MoveCount >= DEFINE.MOVE_COUNT_MAX)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed);

				// 上限
				if (transform.position.z > DEFINE.PLAYER_MOVE_MAX)
				{
					transform.position = new Vector3(transform.position.x, transform.position.y, DEFINE.PLAYER_MOVE_MAX);
				}
			}
			// カウンタが最大値未満なら加算
			else if (MoveCount < DEFINE.MOVE_COUNT_MAX)
			{
				// カウンタ加算
				MoveCount++;
			}
		}

		// 下方向移動
		if (Input.GetAxisRaw("Vertical2") < 0)
		{
			// 角度変更
			transform.rotation = Quaternion.Euler(0, DEFINE.PLAYER_ANGLE, 0);

			// 一定以上長押しされたら移動
			if (MoveCount >= DEFINE.MOVE_COUNT_MAX)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed);

				// 下限
				if (transform.position.z < -DEFINE.PLAYER_MOVE_MAX)
				{
					transform.position = new Vector3(transform.position.x, transform.position.y, -DEFINE.PLAYER_MOVE_MAX);
				}
			}
			// カウンタが最大値未満なら加算
			else if (MoveCount < DEFINE.MOVE_COUNT_MAX)
			{
				// カウンタ加算
				MoveCount++;
			}
		}

		// 上下の入力がされていないとき
		if (Input.GetAxisRaw("Vertical2") == 0)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			MoveCount = 0;
		}

		if (GameSetFlag == false)
		{
			// スコアが最大に達したら
			if (Set_Score >= DEFINE.MAX_SCORE)
			{
				// ボール終了
				GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().GameEndBall();

				// プレハブを取得
				GameObject prefab = (GameObject)Resources.Load ("Prefabs/PongGame/GameSet");

				// プレハブからインスタンスを生成
				Instantiate(prefab);

				// フラグオン
				GameSetFlag = true;
			}
		}
		// ゲーム終了していたら
		else if (GameSetFlag == true)
		{
			if (GameSetCount >= DEFINE.GAME_SET_COUNT)
			{
				Mgrs.sceneMgr.LoadScene(DEFINE.SCENE_RESULT);
			}
			else if (GameSetCount < DEFINE.GAME_SET_COUNT)
			{
				// カウンタ加算
				GameSetCount++;
			}
		}
	}

	//=============================================================================
	// スコア設定関数
	//=============================================================================
	public void SetScore(int Score)
	{
		// 現在のスコアに加算
		Set_Score += Score;

		// ゲージに現在のスコアを設定
		gaugecontroller.SetGaugeValue(Set_Score);
	}

	//=============================================================================
	// 衝突判定がされたら
	//=============================================================================
	private void OnCollisionEnter(Collision collision)
	{
		// 衝突対象がボール
		if (collision.gameObject.tag == "Ball")
		{
			// プレイヤーが動かずはじいたらボールの勢いを加算
			if (MoveCount < DEFINE.MOVE_COUNT_MAX & Input.GetAxisRaw("Vertical2") != 0)
			{
				Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

				rb.velocity *= DEFINE.BALL_SPEED_UP;
			}
		}
	}

	//=============================================================================
	// スコア取得関数
	//=============================================================================
	public static int GetScore()
	{
		// スコアの値を返す
		return Set_Score;
	}
}
