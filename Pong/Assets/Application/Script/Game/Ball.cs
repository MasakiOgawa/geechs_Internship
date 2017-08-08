using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private const int BALL_START_INTERVAL = 60;      // ボールのスタートインターバル

	public Rigidbody m_rigidbody;   //速度を与える対象のRigidBody
    //public const float randomRange1 = 1000.0f;   //未使用 現在のランダムがいい感じなら消す
    //public const float randomRange2 = 3000.0f;

    private float angleCheckValueX = 7.0f; //角度調整に使ういい感じの数値
    private float angleCheckValueZ = 3.0f; //角度調整に使ういい感じの数値

    [SerializeField]private float SpeedUpValue = 1.2f;       //速度上昇倍率
    [SerializeField]private float SpeedDownValue = 0.9f;     //速度下降倍率
    [SerializeField]private float MaxSpeed = 150.0f;         //速度上限
    [SerializeField]private float MinSpeed = 60.0f;          //速度下限

    //{//テスト運用
    //壁の数だけ速度上限が上がる
    public float MaxSpeedStanderd = 100.0f;  //速度上限基準値
    public float MaxSpeedAddition = 4.0f;   //速度上限上昇値
    //}

    private int m_State;			//0：無属性 //1：プレイヤ１ //2：プレイヤ２
	private int StartInterval;      // スタートするまでのインターバル
	private int StartDirect;		// スタートの向き

	private bool StartBallFlag;     // ボールスタートフラグ
	private bool GameSetFlag;		// ゲーム終了フラグ

	private MeshRenderer m_MeshRenderer;    //色の変更に使用

	// Use this for initialization
	void Start()
    {
        //レンダラ取得
        m_MeshRenderer = GetComponent<MeshRenderer>();

        //ボール初期化
        m_rigidbody.position = Vector3.zero;
        m_rigidbody.velocity = Vector3.zero;
        SetBollState(0);
        
        // 321スタートの後にボールをスタートさせるためコメント
        //m_rigidbody.AddForce(new Vector3(Random.Range(randomRange1, randomRange2),
        //    0.0f,
        //    Random.Range(randomRange1, randomRange2)));

    }

    // Update is called once per frame
    void Update()
    {
		//CheckSpeed();   //毎フレーム速度を監視する
		//CheckAngle();

		// ゲーム終了フラグがオフなら
		if (GameSetFlag == false)
		{
			// スタートフラグがオンなら
			if (StartBallFlag == true)
			{
				// インターバルを取る
				if (StartInterval >= BALL_START_INTERVAL)
				{
					// ボールスタート
					StartBall();

					// スタートフラグオフ
					StartBallFlag = false;

					// インターバル初期化
					StartInterval = 0;
				}
				else if (StartInterval < BALL_START_INTERVAL)
				{
					// インターバル加算
					StartInterval++;
				}
			}
		}
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
        //m_rigidbody.velocity *= SpeedUpValue;
        m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x * SpeedUpValue * 1.1f,
            0.0f,
            m_rigidbody.velocity.z * SpeedUpValue);
        //Debug.Log("[Ball.cs]SpeedUp() 加速度：" + m_rigidbody.velocity);
    }

    //減速
    public void SpeedDown()
    {
        m_rigidbody.velocity *= SpeedDownValue;
       //Debug.Log("[Ball.cs]SpeedDown() 加速度：" + m_rigidbody.velocity);
    }

    //角度調整
    public void CheckAngle()
    {
        if (Mathf.Abs(m_rigidbody.velocity.z) < angleCheckValueZ)
        {
            float z = m_rigidbody.velocity.z * angleCheckValueZ;
            m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, m_rigidbody.velocity.y, z);
            Debug.Log("角度修正(z方向) 加速度：" + z);
            Debug.Assert(z < angleCheckValueZ * angleCheckValueZ, "速度がありえない数値になっている？");
        }
        if (Mathf.Abs(m_rigidbody.velocity.x) < angleCheckValueX)
        {
            float x = m_rigidbody.velocity.x * angleCheckValueX;
            m_rigidbody.velocity = new Vector3(x, m_rigidbody.velocity.y, m_rigidbody.velocity.z);
            Debug.Log("角度修正(x方向) 加速度：" + x);
            Debug.Assert(x < angleCheckValueX * angleCheckValueX, "速度がありえない数値になっている？");
        }
    }

    //速度調整
    public void CheckSpeed()
    {
        if (m_rigidbody.velocity.magnitude > MaxSpeed)
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * MaxSpeed;
            //Debug.Log("[Ball.cs]最大値検知 修正後：" + m_rigidbody.velocity);
        }
        if (m_rigidbody.velocity.magnitude < MinSpeed)
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * MinSpeed;
            //Debug.Log("[Ball.cs]最小値検知 修正後：" + m_rigidbody.velocity);
        }
    }

    //位置、速度初期化
    public void ResetPosition()
    {
        m_rigidbody.position = Vector3.zero;
        m_rigidbody.velocity = Vector3.zero;
            //Debug.Log("[Ball.cs]位置初期化");
    }

	// ボールスタート 他クラス呼び出し用
	// オーバーロード
	public void StartBall(int direct)
    {
		// 向きを保存
		StartDirect = direct;

		// スタートフラグオン
		StartBallFlag = true;
	}

	//力を与える(動かす)
	//引数 direct：飛ばしたい向き (1...左(1P)側 2...右(2P)側 0...ランダム)
	//ゴールして位置のリセットをした後に呼び出す。
	private void StartBall()
	{
		float randomMin = Mathf.PI * 0.25f;   //だいたい45°～70°くらいの角度にする
		float randomMax = Mathf.PI * 0.4f;
		float radian = Random.Range(randomMin, randomMax);
		float x = Mathf.Cos(radian);
		float z = Mathf.Sin(radian);

		//向きの調整
		switch (StartDirect)
		{
			case 1:
				//左側にする
				x *= -1.0f;
				break;
			case 2:
				//右側にする
				x *= 1.0f;
				break;
			default:
				{//適当にランダムに左右を逆にしたい
					if (Random.Range(0.0f, 1.0f) < 0.5f)
					{
						x *= -1.0f;
					}
				}
				break;
		}

		{//適当にランダムに上下を逆にしたい
			if (Random.Range(0.0f, 1.0f) < 0.5f)
			{
				z *= -1.0f;
			}
		}

		m_rigidbody.velocity = (new Vector3(x, 0.0f, z));
		CheckSpeed();   //速度を最低値に合わせる
	}


	// ゲーム終了時処理
	public void GameEndBall()
	{
		//ボール初期化
		m_rigidbody.position = Vector3.zero;
		m_rigidbody.velocity = Vector3.zero;
		SetBollState(0);

		// ゲーム終了
		GameSetFlag = true;
	}

    //最大速度設定(直接設定)
    public void SetMaxSpeed(float speed)
    {
        MaxSpeed = speed;
    }
    //最大速度設定(要素だけ渡す)
    public void SetMaxSpeed(int wallCount)
    {
        MaxSpeed = MaxSpeedStanderd + MaxSpeedAddition * wallCount;
    }
}
