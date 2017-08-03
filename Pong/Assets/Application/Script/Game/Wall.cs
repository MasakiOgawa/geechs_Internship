using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private int m_State;

	// Use this for initialization
	void Start () {

        m_State = 0;
		
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
