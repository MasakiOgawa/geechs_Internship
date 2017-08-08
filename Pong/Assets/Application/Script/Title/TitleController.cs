using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {

<<<<<<< Updated upstream

=======
	private bool FadeFlag;

	private void Start()
	{
		Application.targetFrameRate = 60;
	}
>>>>>>> Stashed changes
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
	

<<<<<<< Updated upstream
=======
		if (FadeFlag == false)
		{
			if (Input.anyKey /*| Input.GetButtonDown("Fire1")*/)
			{
				//Mgrs.sceneMgr.LoadScene(DEFINE.SCENE_PONG_GAME);
				FadeManager.Instance.LoadScene(DEFINE.SCENE_PONG_GAME, 0.5f);

				FadeFlag = true;
			}
		}
	}
>>>>>>> Stashed changes
}
