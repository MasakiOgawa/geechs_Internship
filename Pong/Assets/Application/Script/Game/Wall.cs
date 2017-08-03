﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private int m_State;
    private MeshRenderer m_MeshRenderer;

    // Use this for initialization
    void Start () {

        m_State = 0;

        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_MeshRenderer.material.color = Color.white;

    }
	
	// Update is called once per frame
	void Update () {


		
	}

    // 壁のステータスの設定 //////////////////////////////////
    public void SetWallState(int state)
    {
        //取得ステータスが成功の場合
        if ((state == 0) | (state == 1) | (state == 2))
        {
            //色の設定
            switch (state)
            {
                case 1:  m_MeshRenderer.material.color = Color.red;  break;
                case 2: m_MeshRenderer.material.color = Color.blue; break;
                default: m_MeshRenderer.material.color = Color.white; break;
            }

            m_State = state;
        }
        //取得ステータスが失敗の場合
        else
        {
            m_State = 0;
        }
    }


    // 壁のステータスの取得 //////////////////////////////////
    public int GetWallState()
    {
        //ステータスが成功の場合
        if ((m_State == 0) | (m_State == 1) | (m_State == 2))
        {
            return m_State;
        }
        //ステータスが失敗の場合NONEを返す
        else
        {
            return 0;
        }
    }
}
