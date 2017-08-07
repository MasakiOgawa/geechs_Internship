using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript2 : MonoBehaviour {
	public int P1Score;
	public int P2Score;
	public Text text;
	// Use this for initialization
	void Start () {
		P1Score = Player.GetScore ();
		P2Score = Player2.GetScore ();
	}

	// Update is called once per frame
	void Update () {
		if (P2Score > P1Score) {
			this.GetComponent<Text> ().text = "WIN";

		}
	}
}
