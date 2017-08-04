using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody m_rigidbody;   //速度を与える対象のRigidBody
    private const float randomRange1 = 1000.0f;
    private const float randomRange2 = 3000.0f;

    public float SpeedUpValue;      //速度上昇値
    public float SpeedDownValue;    //速度下降値
    public float MaxSpeed;    //速度最大値
    public float MinSpeed;    //速度最小値

    private int m_State;
    private MeshRenderer m_MeshRenderer;

    // Use this for initialization
    public void Start()
    {
        //m_rigidbody
        m_rigidbody.AddForce(new Vector3(Random.Range(randomRange1, randomRange2),
            0.0f,
            Random.Range(randomRange1, randomRange2)));
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_MeshRenderer.material.color = Color.white;
        m_State = 0;

        SpeedUpValue = 1.1f;
        SpeedDownValue = 0.9f;

        MaxSpeed = 1.5f;
        MinSpeed = 0.5f;

        SetBollState(0);
        SetBollState(1);    //デバッグ
    }

    // Update is called once per frame
    void Update()
    {
        //座標の更新
    }

    //ボールの属性を設定
    public void SetBollState(int state)
    {
        switch (state)
        {
            case 0:
                m_MeshRenderer.material.color = Color.white;
                break;
            case 1:
                m_MeshRenderer.material.color = Color.red;
                break;
            case 2:
                m_MeshRenderer.material.color = Color.blue;
                break;
            default:
                Debug.Log("想定外の数値(Ball.cs line:47)");
                Debug.Assert(false);
                break;
        }
        m_State = state;
    }

    //ボールの属性を取得
    public int GetBallState()
    {
        return m_State;
    }

    //{//SetBallStateに移植
    //ボールの色を変える
    //public void SetColor(int color)
    //{}
    //}

    //加速
    public void SpeedUp()
    {
        m_rigidbody.velocity *= SpeedUpValue;
        //if (m_rigidbody.velocity.magnitude > MaxSpeed)
        //{
        //    m_rigidbody.velocity.Normalize();
        //    m_rigidbody.velocity *= MaxSpeed;
        //}

    }

    //減速
    public void SpeedDown()
    {
        m_rigidbody.velocity *= SpeedDownValue;
    }

    //角度調整
    public void AngleCheck()
    {
        if (Mathf.Abs(m_rigidbody.velocity.z) < 3)
        {
            float z = m_rigidbody.velocity.z * 3;
            m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, m_rigidbody.velocity.y, z);
        }
        if (Mathf.Abs(m_rigidbody.velocity.x) < 3)
        {
            float x = m_rigidbody.velocity.x * 3;
            m_rigidbody.velocity = new Vector3(x, m_rigidbody.velocity.y, m_rigidbody.velocity.z);
        }
    }
}
