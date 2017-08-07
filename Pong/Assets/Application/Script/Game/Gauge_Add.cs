using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge_Add : MonoBehaviour
{
	// メンバ 変数
	private Slider Gauge;       // ゲージの情報を取得
	private bool AlphaFlag;		// 点滅フラグ

	[SerializeField] private List<Wall>     wallList;       // 壁の情報
	[SerializeField] private int			PlayerNum;		// プレイヤーの数字

	// Use this for initialization
	private void Start()
	{
		// ゲージ情報取得
		Gauge = GetComponent<Slider>();
	}

	// Update is called once per frame
	private void Update()
	{
		// プレイヤー1
		if(PlayerNum == 1)
		{
			// 現在のスコアにゴールした時のスコアを加算して代入
			Gauge.value = Player.GetScore() + DEFINE.GOAL_SCORE;

			for (int i = 0; i < wallList.Count; i++)
			{
				//プレイヤー1の壁を数える
				if (1 == wallList[i].GetWallState())
				{
					Gauge.value += DEFINE.WALL_SCORE;    //ボーナス加算
				}
			}
		}

		// プレイヤー2
		if (PlayerNum == 2)
		{
			// 現在のスコアにゴールした時のスコアを加算して代入
			Gauge.value = Player2.GetScore() + DEFINE.GOAL_SCORE;

			for (int i = 0; i < wallList.Count; i++)
			{
				//プレイヤー2の壁を数える
				if (2 == wallList[i].GetWallState())
				{
					Gauge.value += DEFINE.WALL_SCORE;    //ボーナス加算
				}
			}
		}

		// ゲージの点滅処理
		if (AlphaFlag == false)
		{
			Color color = Gauge.fillRect.GetComponent<Image>().color;

			// アルファの値を徐々に増やす
			Gauge.fillRect.GetComponent<Image>().color = new Color(color.r, color.g, color.b, color.a + 0.008f);
			
			if(color.a > 1)
			{
				// フラグオン
				AlphaFlag = true;
			}
		}
		else if(AlphaFlag == true)
		{
			Color color = Gauge.fillRect.GetComponent<Image>().color;

			// アルファの値を徐々に減らす
			Gauge.fillRect.GetComponent<Image>().color = new Color(color.r, color.g, color.b, color.a - 0.005f);

			if (color.a < 0.5f)
			{
				// フラグオフ
				AlphaFlag = false;
			}
		}
	}
}
