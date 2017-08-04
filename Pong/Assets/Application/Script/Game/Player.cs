using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//public class//
	public ResultController resultcontroller;
	public GaugeController gaugecontroller;
	public float Speed;
	public int Rote;
	//private class//
	private int Set_Score;
	private int ResolutScore;

	// Use this for initialization
	void Start () {
		Set_Score = 0;
		ResolutScore = 0;
		Speed = 1f;
		Rote = 15;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W) && this.transform.position.z < 23) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 
				this.transform.position.z + Speed);
			
			this.transform.rotation = Quaternion.Euler(0, 21, 0);
		}
		else if (Input.GetKey(KeyCode.S) && this.transform.position.z > -23) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 
				this.transform.position.z - Speed);
			this.transform.rotation = Quaternion.Euler(0, -21, 0);
		} 
		if (Input.GetKeyUp(KeyCode.W)) {
			this.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		if (Input.GetKeyUp(KeyCode.S)) {
			this.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
			
	}
	public void SetScore(int Score){
		Set_Score = Score;

        gaugecontroller.SetGaugeValue(Set_Score);

    }
}
