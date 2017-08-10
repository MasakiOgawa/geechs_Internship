using UnityEngine;
using System.Collections;

public class ResultController : MonoBehaviour{
	private bool FadeFlag;
	private AudioSource SE_00;

	private void Start()
	{
		SE_00 = GetComponent<AudioSource>();
	}

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
			if (FadeFlag == false)
			{
				FadeManager.Instance.LoadScene(DEFINE.SCENE_TITLE, 0.5f);

				FadeFlag = true;

				SE_00.PlayOneShot(SE_00.clip);
			}
		}
	}
}