using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// ユーザもしくはCPIのラケット管理クラス
/// </summary>
public class RacketComponent : MonoBehaviour {

	public float speed = 10;
	public string axisName;
	public KeyCode name;
	//ラケット傾き  //
	public float angle = 15;
	public float smooth = 2.0F;
	public float tiltAngle = 30.0F;
	/// <summary>
	/// 敵
	/// </summary>
	public bool isAuto = false;
	private const float SPEED = 100f;

	private float _maxPosTop = 0f;

	/// <summary>
	/// 画面上部まで移動しているか
	/// </summary>
	/// <value><c>true</c> if is wall top; otherwise, <c>false</c>.</value>
	private bool isWallTop;
	
	/// <summary>
	/// 画面下部までに移動しているか
	/// </summary>
	/// <value><c>true</c> if is wall botton; otherwise, <c>false</c>.</value>
	private bool isWallBotton;

	/// <summary>
	/// ラケットの更新処理
	/// </summary>
	/// <param name="ball">Ball.</param>
	public void FixedUpdate(LinkedList<BallComponent> ballList) {

		if (this.isAuto) {
			this.Enemy (ballList);
		} else {
			float y = Input.GetAxis ("Horizontal");

			Rigidbody2D rigbody = GetComponent<Rigidbody2D> ();

			rigbody.AddForce(0 , y );
		}


	

		if (Input.GetKey(name)) {
			Debug.Log ("傾くぞ！");
			this.gameObject.transform.rotation = Quaternion.Euler( 0, 0, angle);
		}
		else {
			Debug.Log ("戻る!!");
			this.gameObject.transform.rotation = Quaternion.Euler( 0, 0, 0);
		}
	}
	/// <summary>
	/// ラケットを自動で動かす
	/// </summary>
	/// <param name="ballList">Ball list.</param>
	private void Enemy(LinkedList<BallComponent> ballList) {
		if( ballList == null || ballList.Count == 0) {
				return;
			}
			BallComponent ball = ballList.Last.Value;
			this.transform.position = new Vector3(this.transform.position.x, ball.transform.position.y, this.transform.position.z );
		}
	



	/// <summary>
	/// 衝突開始
	/// </summary>
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall"){

			//壁に接触：壁の方が位置的に上だったら上の壁に接したとする
			Transform target = coll.transform;
			if (target.localPosition.y >= transform.localPosition.y){
				isWallTop = true;
			}
			else{
				isWallBotton = true;
			}
		}
	}

	/// <summary>
	/// 衝突終了
	/// </summary>
	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall"){


			Transform target = coll.transform;

			if (target.localPosition.y >= transform.localPosition.y){
				isWallTop = false;
			}
			else{
				isWallBotton = false;
			}
		}
			
	}
}
