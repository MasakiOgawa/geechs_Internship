using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
	// コンスト定数
	private const float PLAYER_MOVE_MAX = 23.0f;        // プレイヤーの移動最大値
	private const int MOVE_COUNT_MAX = 5;				// 移動カウンタ最大値
	private const float PLAYER_ANGLE = 22.0f;           // プレイヤーの角度
	private const float BALL_SPEED_UP = 1.5f;           // ボール加速量

	//public class//
	public ResultController resultcontroller;
	public GaugeController gaugecontroller;
	public float Speed;
	public int Rote;

	//private class//
	private int Set_Score;
	private int MoveCount;      // プレイヤーが動き出す時間計測用

	// Use this for initialization
	void Start()
	{
		Set_Score = 0;
		Speed = 1f;
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
			transform.rotation = Quaternion.Euler(0, -PLAYER_ANGLE, 0);

			// 一定以上長押しされたら移動
			if (MoveCount >= MOVE_COUNT_MAX)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed);

				// 上限
				if (transform.position.z > PLAYER_MOVE_MAX)
				{
					transform.position = new Vector3(transform.position.x, transform.position.y, PLAYER_MOVE_MAX);
				}
			}
			// カウンタが最大値未満なら加算
			else if (MoveCount < MOVE_COUNT_MAX)
			{
				// カウンタ加算
				MoveCount++;
			}
		}

		// 下方向移動
		if (Input.GetAxisRaw("Vertical2") < 0)
		{
			// 角度変更
			transform.rotation = Quaternion.Euler(0, PLAYER_ANGLE, 0);

			// 一定以上長押しされたら移動
			if (MoveCount >= MOVE_COUNT_MAX)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed);

				// 下限
				if (transform.position.z < -PLAYER_MOVE_MAX)
				{
					transform.position = new Vector3(transform.position.x, transform.position.y, -PLAYER_MOVE_MAX);
				}
			}
			// カウンタが最大値未満なら加算
			else if (MoveCount < MOVE_COUNT_MAX)
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
			if (MoveCount < MOVE_COUNT_MAX)
			{
				Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

				rb.velocity *= BALL_SPEED_UP;
			}
		}

	}
}
