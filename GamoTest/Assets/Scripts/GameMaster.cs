using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
	public static GameMaster gm;
	public int highScore;
	public int currentScore;

	void Start ()
	{
		if (!gm) {
			gm = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			DestroyImmediate (this.gameObject);
		}
	}

	void OnEnable ()
	{
		LoadData ();
	}

	void OnDisable ()
	{
		if (gm == this)
			SaveData ();
	}

	void LoadData ()
	{
		highScore = PlayerPrefs.GetInt ("highScore", 0);
	}

	void SaveData ()
	{
		PlayerPrefs.SetInt ("highScore", highScore);
	}

	public void LoadScene (string newScene)
	{
		SceneManager.LoadScene (newScene);
	}
}
