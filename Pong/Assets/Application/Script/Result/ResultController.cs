using UnityEngine;
using System.Collections;

public class ResultController : MonoBehaviour{
<<<<<<< Updated upstream
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
=======
	private bool FadeFlag;
	
	/// <summary>
	/// タイトルへ遷移する
	/// </summary>
	/// 
	private void Update()
	{
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}

		if (Input.anyKey /*| Input.GetButtonDown("Fire1")*/)
		{
			if (FadeFlag == false)
			{
				FadeManager.Instance.LoadScene(DEFINE.SCENE_TITLE, 0.5f);

				FadeFlag = true;
			}
		}
	}
>>>>>>> Stashed changes
}