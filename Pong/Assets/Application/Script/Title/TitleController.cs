using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {


	/// <summary>
	/// ゲームをスタートする
	/// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Mgrs.sceneMgr.LoadScene(DEFINE.SCENE_PONG_GAME);
        }
    }
	

}
