using UnityEngine;
using System.Collections;

public class ResultController : MonoBehaviour{
    /// <summary>
    /// タイトルへ遷移する
    /// </summary>
    private void Update()
    {
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}

		if (Input.anyKey /*| Input.GetButtonDown("Fire1")*/)
        {
            Mgrs.sceneMgr.LoadScene(DEFINE.SCENE_TITLE);
        }
    }
}