using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGauge2 : MonoBehaviour {
	private int Score;
	public Slider Gauge;
	// Use this for initialization
	void Start () {
		Gauge = GetComponent<Slider>();
		Score = Player2.GetScore();
	}

	// Update is called once per frame
	void Update () {
		Gauge.value = Score;
	}
}