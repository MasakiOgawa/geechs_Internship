using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{
    private Wall wall;
    private Ball ball;

    [SerializeField]private List<Wall> wallList;
    public Player player1;
    public Player2 player2;


    // Use this for initialization
    void Start()
    {
        ball = this.gameObject.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //当たった場合の処理(物理的な当たり判定)
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player1")
        {//ボールと1Pのラケットが当たった場合
            ball.SetBollState(1);
            //Debug.Log("1Pに当たった");
        }
        else if (col.gameObject.tag == "Player2")
        {//ボールと2Pのラケットが当たった場合
            ball.SetBollState(2);
            //Debug.Log("2Pに当たった");
        }

        ball.CheckAngle();
        ball.CheckSpeed();
    }

    //当たった場合の処理(物理的な当たりではない)
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {//ボールと壁が当たった場合
            wall = col.gameObject.GetComponent<Wall>();
            ball = this.gameObject.GetComponent<Ball>();
            int ballState = ball.GetBallState();
            int wallState = wall.GetWallState();

            if (ballState == 0)
            {
            }
            else if (wallState == ballState)
            {
                //Debug.Log("同じ色");
                ball.SpeedUp();
            }
            else
            {
                if (wallState == 0)
                {
                    //Debug.Log("無色");
                }
                else
                {
                    ball.SpeedDown();
                    //Debug.Log("違う色");
                }
                wallState = ballState;  //デバッグ確認用
                wall.SetWallState(wallState);
            }

            //反射時の調整
            //ball.CheckSpeed();
            //ball.CheckAngle();
        }
        else if (col.gameObject.tag == "GoalArea1")
        {//1P側のゴールエリアに入った場合(2Pに得点が入る)
            //得点の計算
            int score = DEFINE.GoalScore;    //基本点を入れておく
            for (int i = 0; i < wallList.Count; i++)
            {//同じ属性の壁を数える
                if (2 == wallList[i].GetWallState())
                {
                    score += DEFINE.WallScore;    //ボーナス加算
                }
                wallList[i].SetWallState(0);    //属性のリセット
            }

            //プレイヤ2に得点を渡す
            player2.SetScore(score);

            //ボールの初期化
            ball.ResetPosition();
            ball.SetBollState(0);
            ball.StartBall(2);   //2P側のほうへ
        }
        else if (col.gameObject.tag == "GoalArea2")
        {//2P側のゴールエリアに入った場合(1Pに得点が入る)
            //得点の計算
            int score = DEFINE.GoalScore; ;
            for (int i = 0; i < wallList.Count; i++)
            {//同じ属性の壁を数える
                if (1 == wallList[i].GetWallState())
                {
                    score += DEFINE.WallScore;
                }
                wallList[i].SetWallState(0);
            }

            //プレイヤ1に得点を渡す
            player1.SetScore(score);

            //ボールの初期化
            ball.ResetPosition();
            ball.SetBollState(0);
            ball.StartBall(1);   //1P側のほうへ
        }

    }
}
