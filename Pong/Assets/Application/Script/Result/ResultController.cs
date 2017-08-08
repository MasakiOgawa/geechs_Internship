using UnityEngine;
using System.Collections;

public class ResultController : MonoBehaviour{

	/// <summary>
	/// タイトルへ遷移する
	/// </summary>
	/// 
	private bool FadeFlag;
	
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
}