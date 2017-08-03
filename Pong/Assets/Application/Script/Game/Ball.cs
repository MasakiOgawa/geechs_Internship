using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private int m_State;

    // Use this for initialization
    void Start ()
    {
        m_State = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public int GetBallState()
    {
        return m_State;
    }
}
