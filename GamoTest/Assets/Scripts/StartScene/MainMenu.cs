using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public void btn_Quit ()
	{
		Application.Quit ();
	}

	public void btn_Play ()
	{
		GameMaster.gm.LoadScene ("PlayScene");
	}
}
