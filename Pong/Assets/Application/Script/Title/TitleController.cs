using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour
{
	private bool FadeFlag;

	private void Start()
	{
		Application.targetFrameRate = 60;
	}
	/// <summary>
	/// ゲームをスタートする
	/// </summary>
	private void Update()
	{
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
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
}
