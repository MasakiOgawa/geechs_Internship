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

    //当たった場合の処理
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Racket1")
        {//ボールと1Pのラケットが当たった場合
            hitPlayer1 = true;
            hitPlayer2 = false;
            ball.SetBollState(1);
        }
        else if (col.gameObject.tag == "Racket2")
        {//ボールと2Pのラケットが当たった場合
            hitPlayer1 = false;
            hitPlayer2 = true;
            ball.SetBollState(2);
        }
        else if (col.gameObject.tag == "Wall")
        {//ボールと壁が当たった場合

            wall = col.gameObject.GetComponent<Wall>();
            ball = this.gameObject.GetComponent<Ball>();

            int ballState = ball.GetBallState();
            int wallState = wall.GetWallState();

            //{//デバッグテスト
            //    Debug.Log("デバッグ");
            //    ball.SpeedUp();
            //    ball.SetBollState(1);
            //}

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
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {//ボールと壁が当たった場合

            wall = col.gameObject.GetComponent<Wall>();
            ball = this.gameObject.GetComponent<Ball>();

            int ballState = ball.GetBallState();
            int wallState = wall.GetWallState();

            //{//デバッグテスト
            //    Debug.Log("デバッグ");
            //    ball.SpeedUp();
            //    ball.SetBollState(1);
            //}

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
        }
    }
}
