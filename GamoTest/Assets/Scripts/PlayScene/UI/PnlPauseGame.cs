using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnlPauseGame : MonoBehaviour
{
	void OnEnable ()
	{
		Time.timeScale = 0f;
	}

	public void btn_Home ()
	{
		GameMaster.gm.LoadScene ("StartScene");
	}

	public void btn_Remuse ()
	{
		Time.timeScale = 1f;
	}
}
