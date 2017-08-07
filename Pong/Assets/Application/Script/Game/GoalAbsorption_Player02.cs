using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAbsorption_Player02 : MonoBehaviour
{

    public float m_Frame = 120.0f;
    private ParticleSystem particle;
    private bool m_StartFlag = false;
    private Vector3 m_FinishPos;
    private Vector3 m_StartPos;
    private Vector3 m_ParticlePos;
    private int m_Counter = 0;

    // Use this for initialization
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
        m_FinishPos.x = 40.0f;
        m_FinishPos.y = 2.0f;
        m_FinishPos.z = 50.0f;
		m_StartFlag = false;
	}

    // Update is called once per frame
    void Update()
    {
		//フラグが成功なら移動を開始する
		if (m_StartFlag == true)
		{
			if (particle.isPlaying == false)
			{
				particle.Play();
			}

			//現在位置から終点までを詰めていく
			Vector3 Interval = (m_FinishPos - m_StartPos) / m_Frame;

			m_ParticlePos = m_StartPos + Interval * m_Counter;

			//パーティクル発生位置の更新
			particle.transform.position = new Vector3(m_ParticlePos.x, m_ParticlePos.y, m_ParticlePos.z);

			//インクリメント
			m_Counter++;

			//フレーム経過したら終了
			if (m_Counter > m_Frame)
			{
				particle.Stop();
				m_StartFlag = false;
				m_Counter = 0;
			}
		}
    }

    //パーティクルのセット
    public void SetParticlePos(Vector3 pos)
    {
		Debug.Log(pos);

		m_StartFlag = true;     //移動フラグの成功
        m_StartPos = pos;       //スタート位置の設定
    }
}