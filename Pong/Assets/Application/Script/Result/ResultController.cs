using UnityEngine;
using System.Collections;

public class ResultController : MonoBehaviour{


    /// <summary>
    /// タイトルへ遷移する
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Mgrs.sceneMgr.LoadScene(DEFINE.SCENE_TITLE);
        }
    }

}

