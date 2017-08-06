using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GaugeController : MonoBehaviour
{
	// コンスト 定数
	private const int ADD_GAUGE = 10;

	// メンバ 変数
	private Slider Gauge;       // ゲージの情報を取得
	private int Score;			// 現在のスコア

	// Use this for initialization
	private void Start()
	{
		// ゲージ情報取得
		Gauge = GetComponent<Slider>();
	}

	// Update is called once per frame
	private void Update()
	{
		// テスト
		//Gauge.value += 10;

		// ゲージを徐々に加算
		if(Gauge.value < Score)
		{
			Gauge.value += ADD_GAUGE;
		}
	}

	// 現在のスコアを設定
	public void SetGaugeValue(int GaugeValue)
	{
		Score = GaugeValue;
	}
}
