using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{
    public Wall wall;
    public Ball ball;
    public bool hitPlayer1;
    public bool hitPlayer2;
    public int hitWall;

    private int ballState;  //ボールの属性を格納
    private int wallState;  //壁の属性を格納

    // Use this for initialization
    void Start()
    {
        hitPlayer1 = false;
        hitPlayer2 = false;
        hitWall = 0;
        ballState = 0;
        wallState = 0;
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

            //ボールの属性を変更
        }
        else if (col.gameObject.tag == "Racket2")
        {//ボールと2Pのラケットが当たった場合
            hitPlayer1 = false;
            hitPlayer2 = true;
        }
        else if (col.gameObject.tag == "Wall")
        {//ボールと壁が当たった場合
            wallState = wall.GetWallState();
            ballState = ball.GetBallState();
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
                    //ball.SpeedDown(); //減速
                }
            }
            else
            {
                //加速
            }
        }
    }
}
