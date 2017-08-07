using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {


	/// <summary>
	/// ゲームをスタートする
	/// </summary>
    private void Update()
    {
        if (Input.anyKey)
        {
            Mgrs.sceneMgr.LoadScene(DEFINE.SCENE_PONG_GAME);
        }
    }
	

}
