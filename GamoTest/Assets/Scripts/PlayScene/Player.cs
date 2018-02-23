using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	public static Action<float> speedChange;
	public static Action<int> scoreChange;

	[SerializeField] Vector3 startPosition;
	[SerializeField] GameObject pnlGameOver;
	[SerializeField] Rigidbody2D _rigid;
	[SerializeField] Transform _trans;
	bool canJump = false;
	[SerializeField] float baseSpeed = 600f;
	[SerializeField] float speed;
	[SerializeField] float speedJump;
	[SerializeField] float accleration = 10f;

	void Start ()
	{
		InitMap ();

		InitGame ();
		UpdateUI ();
	}

	void Update ()
	{
		// Velocity multiple with delta time to make game more smooth
		// Velocity in x axis alway const
		Vector2 velo = _rigid.velocity;
		velo.x = speed * Time.deltaTime;

		// Add velocity in y axis when space button click
		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			velo.y = speedJump * Time.deltaTime;
			canJump = false;
		}

		_rigid.velocity = velo;
	}

	void OnTriggerEnter2D (Collider2D hit)
	{
		if (hit.CompareTag (Constant.barrielTag)) {
			Debug.Log ("GameOver");
			GameMaster.gm.GameOver ();
			pnlGameOver.SetActive (true);
			Time.timeScale = 0;
		}
	}

	void OnTriggerExit2D (Collider2D hit)
	{
		if (hit.CompareTag (Constant.jumpSpaceTag)) {
			GameMaster.gm.currentScore += 10;
			speed += accleration;
			UpdateUI ();
		}
	}

	void OnCollisionEnter2D (Collision2D hit)
	{
		if (hit.transform.CompareTag (Constant.groundTag)) {
			canJump = true;
		}
	}

	void UpdateUI ()
	{
		if (scoreChange != null)
			scoreChange.Invoke (GameMaster.gm.currentScore);
		if (speedChange != null)
			speedChange.Invoke (speed);
	}

	public void ReStart ()
	{
		ClearMap ();
		InitMap ();

		InitGame ();
		UpdateUI ();
	}

	void InitGame ()
	{
		transform.position = startPosition;
		GameMaster.gm.currentScore = 0;
		speed = baseSpeed;
		Time.timeScale = 1f;
		pnlGameOver.SetActive (false);
	}

	void InitMap ()
	{
		float positionGroundX = -5f;
		float positionGroundY = -5f;
		for (int i = 0; i < 3; i++) {
			GameObject ground = Pool.pool.GetGround ();
			ground.transform.position = new Vector3 (positionGroundX, positionGroundY, 0);
			positionGroundX += 10f;
			ground.SetActive (true);
		}

		GameObject barriel = Pool.pool.GetBarriel ();
		barriel.transform.position = new Vector3 (15f, 0, 0);
		barriel.SetActive (true);
	}

	public void ClearMap ()
	{
		GameObject[] grounds = GameObject.FindGameObjectsWithTag ("Ground");
		for (int i = 0; i < grounds.Length; i++) {
			Pool.pool.AddGround (grounds [i]);
		}

		GameObject[] barriels = GameObject.FindGameObjectsWithTag ("GroupBarriel");
		for (int i = 0; i < barriels.Length; i++) {
			Pool.pool.AddBarriel (barriels [i]);
		}
	}
}

