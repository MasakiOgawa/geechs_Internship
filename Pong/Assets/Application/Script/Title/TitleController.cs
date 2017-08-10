using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour
{
	private bool FadeFlag;
	private AudioSource SE_00;

	private void Start()
	{
		Application.targetFrameRate = 60;
		SE_00 = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}

		if (Input.anyKey)
		{
			if (FadeFlag == false)
			{
				if (Input.anyKey /*| Input.GetButtonDown("Fire1")*/)
				{
					//Mgrs.sceneMgr.LoadScene(DEFINE.SCENE_PONG_GAME);
					FadeManager.Instance.LoadScene(DEFINE.SCENE_PONG_GAME, 0.5f);

					FadeFlag = true;

					SE_00.PlayOneShot(SE_00.clip);
				}
			}
		}
	}
}