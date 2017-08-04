using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{
    public Wall wall;
    public Ball ball;
    public bool hitPlayer1; //必要ないかも
    public bool hitPlayer2;
    public int hitWall;

    [SerializeField]
    private List<Wall> wallList;
    public Player player1;
    public Player2 player2;


    // Use this for initialization
    void Start()
    {
        hitPlayer1 = false;
        hitPlayer2 = false;
        hitWall = 0;
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
            Debug.Log("１に当たった");
        }
        else if (col.gameObject.tag == "Player2")
        {//ボールと2Pのラケットが当たった場合
            ball.SetBollState(2);
        }
        //else if (col.gameObject.tag == "Wall")
        //{//ボールと壁が当たった場合
        //    wall = col.gameObject.GetComponent<Wall>();
        //    ball = this.gameObject.GetComponent<Ball>();
        //    int ballState = ball.GetBallState();
        //    int wallState = wall.GetWallState();

        //    if (ballState == 0)
        //    {
        //    }
        //    else if (wallState != ballState)
        //    {
        //        if (wallState == 0)
        //        {
        //            wallState = ballState;  //デバッグ確認用
        //            wall.SetWallState(wallState);
        //            Debug.Log("無色");
        //        }
        //        else
        //        {
        //            wallState = ballState;
        //            wall.SetWallState(wallState);
        //            //ball.SpeedDown();
        //            Debug.Log("違う色");
        //        }
        //    }
        //    else
        //    {
        //        Debug.Log("同じ色");
        //        //ball.SpeedUp();
        //    }

        //    //反射ベクトルを計算
        //    ball.AngleCheck();
        //}

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
            else if (wallState != ballState)
            {
                if (wallState == 0)
                {
                    wallState = ballState;  //デバッグ確認用
                    wall.SetWallState(wallState);
                    Debug.Log("無色");
                }
                else
                {
                    wallState = ballState;
                    wall.SetWallState(wallState);
                    //ball.SpeedDown();
                    Debug.Log("違う色");
                }
            }
            else
            {
                Debug.Log("同じ色");
                //ball.SpeedUp();
            }

            //反射ベクトルを計算
            ball.AngleCheck();
        }
        else if (col.gameObject.tag == "GoalArea1")
        {//1P側のゴールエリアに入った場合(2Pに得点が入る)
            Debug.Log("ゴールチェック");
            //得点の計算
            int score = 100;    //基本点を入れておく
            int wallState;
            for (int i = 0; i < wallList.Count; i++)
            {//同じ属性の壁を数える
                wallState = wallList[i].GetWallState();
                if (wallState == 2)
                {
                    score += 10;    //ボーナスを追加
                }
                wallList[i].SetWallState(0);    //属性を初期化
            }

            //プレイヤ2に得点を渡す
            Debug.Log(score);
            player2.SetScore(score);

            //ボールの初期化
            ball.ResetPosition();
            ball.SetBollState(0);
            ball.StartBall(0.0f);   //1P側のほうへ
        }
        else if (col.gameObject.tag == "GoalArea2")
        {//2P側のゴールエリアに入った場合(1Pに得点が入る)
            Debug.Log("ゴールチェック");
            //得点の計算
            int score = 100;    //基本点を入れておく
            int wallState;
            for (int i = 0; i < wallList.Count; i++)
            {//同じ属性の壁を数える
                wallState = wallList[i].GetWallState();
                if (wallState == 1)
                {
                    score += 10;    //ボーナスを追加
                }
                wallList[i].SetWallState(0);    //属性を初期化
            }

            //プレイヤ1に得点を渡す
            Debug.Log(score);
            player1.SetScore(score);

            //ボールの初期化
            ball.ResetPosition();
            ball.SetBollState(0);
            ball.StartBall(0.0f);   //1P側のほうへ
        }

    }
}
