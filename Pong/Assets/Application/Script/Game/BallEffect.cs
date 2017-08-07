using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEffect : MonoBehaviour
{
	[SerializeField] GameObject BallEffect1;		// エフェクト プレイヤー1
	[SerializeField] GameObject BallEffect2;		// エフェクト プレイヤー2
	[SerializeField] Ball		Ball;				// ボール情報

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// プレイヤー1
		if(Ball.GetComponent<Ball>().GetBallState() == 1)
		{
			Instantiate(BallEffect1, Ball.transform.position, Ball.transform.rotation);
		}

		// プレイヤー2
		if (Ball.GetComponent<Ball>().GetBallState() == 2)
		{
			Instantiate(BallEffect2, Ball.transform.position, Ball.transform.rotation);
		}
	}
}
