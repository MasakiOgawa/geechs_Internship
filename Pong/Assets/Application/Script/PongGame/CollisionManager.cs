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
    //private Player1 player1;
    //private Player2 player2;

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
        if (col.gameObject.tag == "Racket1")
        {//ボールと1Pのラケットが当たった場合
            ball.SetBollState(1);
        }
        else if (col.gameObject.tag == "Racket2")
        {//ボールと2Pのラケットが当たった場合
            ball.SetBollState(2);
        }

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
                }
                else
                {
                    wallState = ballState;
                    wall.SetWallState(wallState);
                    ball.SpeedDown();
                }
            }
            else
            {
                ball.SpeedUp();
            }

            //反射ベクトルを計算
            ball.AngleCheck();
        }
        else if (col.gameObject.tag == "GoalArea1")
        {//1P側のゴールエリアに入った場合(2Pに得点が入る)
            //ボールの位置の初期化
            this.gameObject.GetComponent<Ball>().Start();

            //属性の無い球が入ったら、得点は何もしない
            int ballState = this.gameObject.GetComponent<Ball>().GetBallState();
            if (ballState == 0)
            {
                return;
            }

            //得点の計算
            int score = 100;    //基本点を入れておく
            int wallState;
            for (int i = 0; i < wallList.Count; i++)
            {//同じ属性の壁を数える
                wallState = wallList[i].GetWallState();
                if (wallState == ballState)
                {
                    score += 10;    //ボーナスを追加
                    wallList[i].SetWallState(0);    //属性を初期化
                }
            }

            //プレイヤ2に得点を渡す
            //player2.SetScore(score);
        }
        else if (col.gameObject.tag == "GoalArea2")
        {//2P側のゴールエリアに入った場合(1Pに得点が入る)
            //ボールの位置の初期化
            this.gameObject.GetComponent<Ball>().Start();

            //属性の無い球が入ったら、得点は何もしない
            int ballState = this.gameObject.GetComponent<Ball>().GetBallState();
            if (ballState == 0)
            {
                return;
            }

            //得点の計算
            int score = 100;    //基本点を入れておく
            int wallState;
            for (int i = 0; i < wallList.Count; i++)
            {//同じ属性の壁を数える
                wallState = wallList[i].GetWallState();
                if (wallState == ballState)
                {
                    score += 10;    //ボーナスを追加
                    wallList[i].SetWallState(0);    //属性を初期化
                }
            }

            //プレイヤ1に得点を渡す
            //player1.SetScore(score);
        }

    }
}
