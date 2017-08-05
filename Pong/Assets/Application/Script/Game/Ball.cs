using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody m_rigidbody;   //速度を与える対象のRigidBody
    private const float randomRange1 = 1000.0f;
    private const float randomRange2 = 3000.0f;

    public int angleCheckValue = 5; //角度調整に使ういい感じの数値

    public float SpeedUpValue;      //速度上昇値
    public float SpeedDownValue;    //速度下降値
    public float MaxSpeed;          //速度最大値
    public float MinSpeed;          //速度最小値

    private int m_State;    //0：無属性 //1：プレイヤ１ //2：プレイヤ２


    private MeshRenderer m_MeshRenderer;    //色の変更に使用


    // Use this for initialization
    void Start()
    {
        m_rigidbody.position = Vector3.zero;
        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.AddForce(new Vector3(Random.Range(randomRange1, randomRange2),
            0.0f,
            Random.Range(randomRange1, randomRange2)));
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_MeshRenderer.material.color = Color.white;
        m_State = 0;

        SpeedUpValue = 1.2f;
        SpeedDownValue = 0.9f;

        MaxSpeed = 100.0f;
        MinSpeed = 50.0f;

        SetBollState(0);
        //SetBollState(1);    //デバッグ
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpeed();   //毎フレーム速度を監視する
        //CheckAngle();
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

    //加速
    public void SpeedUp()
    {
        m_rigidbody.velocity *= SpeedUpValue;
        Debug.Log("[Ball.cs]SpeedUp()" + m_rigidbody.velocity.magnitude);
    }

    //減速
    public void SpeedDown()
    {
        m_rigidbody.velocity *= SpeedDownValue;
        Debug.Log("[Ball.cs]SpeedDown()" + m_rigidbody.velocity.magnitude);
    }

    //角度調整
    public void CheckAngle()
    {
        if (Mathf.Abs(m_rigidbody.velocity.z) < angleCheckValue)
        {
            float z = m_rigidbody.velocity.z * angleCheckValue;
            m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, m_rigidbody.velocity.y, z);
        }
        if (Mathf.Abs(m_rigidbody.velocity.x) < angleCheckValue)
        {
            float x = m_rigidbody.velocity.x * angleCheckValue;
            m_rigidbody.velocity = new Vector3(x, m_rigidbody.velocity.y, m_rigidbody.velocity.z);
        }
        Debug.Log("[Ball.cs]AngelCheck()" + m_rigidbody.velocity.magnitude);
    }

    //速度調整
    public void CheckSpeed()
    {
        if (m_rigidbody.velocity.magnitude > MaxSpeed)
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * MaxSpeed;
            Debug.Log("[Ball.cs]最大値検知");
        }
        if (m_rigidbody.velocity.magnitude < MinSpeed)
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * MinSpeed;
            Debug.Log("[Ball.cs]最小値検知");
        }
    }

    //位置リセット
    public void ResetPosition()
    {
        m_rigidbody.position = Vector3.zero;
        m_rigidbody.velocity = Vector3.zero;
    }

    //力を与える(動かす)
    //引数 angle：角度(飛ばしたい向き)
    //ゴールして位置のリセットをした後に呼び出す。
    //また、球が横方向に進まなくなったときなどにも使う。
    public void StartBall(float angle)
    {
        //！まだランダムです！
        m_rigidbody.AddForce(new Vector3(Random.Range(randomRange1, randomRange2),
            0.0f,
            Random.Range(randomRange1, randomRange2)));
    }
}
