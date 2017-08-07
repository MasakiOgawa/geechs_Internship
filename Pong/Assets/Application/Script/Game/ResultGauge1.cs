using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGauge1 : MonoBehaviour {
	private int Score;
	public Slider Gauge;
	// Use this for initialization
	void Start () {
		Gauge = GetComponent<Slider>();
		Score = Player.GetScore();
	}
	
	// Update is called once per frame
	void Update () {
		Gauge.value = Score;
	}
}
