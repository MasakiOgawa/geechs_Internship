using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
	
	//public class//
	public ResultController resultcontroller;
	public GaugeController gaugecontroller;
	public float Speed;
	public int Rota;

	//private class//
	private int Set_Score;
	private int ResolutScore;

	// Use this for initialization
	void Start () {
		Set_Score = 0;
		ResolutScore = 0;
		Speed = 1;
		Rota = 3;
	}

	// Update is called once per frame
	//ラケット操作//
	void Update()
	{
		//ラケット上移動//
		Vector3 euler = transform.rotation.eulerAngles;

		if (Input.GetKey(KeyCode.UpArrow) && this.transform.position.z < 23)
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
				this.transform.position.z + Speed);

			//ラケット回転//		
			this.transform.rotation = Quaternion.Euler(0, -21, 0);

			//ラケット下移動//
		}
		else if (Input.GetKey(KeyCode.DownArrow) && this.transform.position.z > -23)
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
				this.transform.position.z - Speed);
			//ラケット回転//
			this.transform.rotation = Quaternion.Euler(0, 21, 0);
		}
		//ラケット回転リセット//
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			this.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			this.transform.rotation = Quaternion.Euler(0, 0, 0);
		}

	}

	public void SetScore(int Score)
	{
		Set_Score += Score;
		gaugecontroller.SetGaugeValue(Set_Score);
	}
}
