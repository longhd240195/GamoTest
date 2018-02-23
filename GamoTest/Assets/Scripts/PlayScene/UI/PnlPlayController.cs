using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnlPlayController : MonoBehaviour
{
	public Text txtScore;
	public Text txtSpeed;

	void OnEnable ()
	{
		Player.scoreChange += UpdateScore;
		Player.speedChange += UpdateSpeed;
	}

	void OnDisable ()
	{
		Player.scoreChange -= UpdateScore;
		Player.speedChange -= UpdateSpeed;
	}

	public void UpdateScore (int newScore)
	{
		txtScore.text = newScore.ToString ();
	}

	public void UpdateSpeed (float newSpeed)
	{
		txtSpeed.text = "Speed: " + newSpeed.ToString ();
	}

	public void btn_Pause ()
	{
		Time.timeScale = 0f;
	}
}
