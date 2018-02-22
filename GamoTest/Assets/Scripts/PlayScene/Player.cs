using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] string barrielTag = "Barriel";
	[SerializeField] string	jumpSpaceTag = "JumpSpace";
	[SerializeField] Rigidbody2D _rigid;
	[SerializeField] Transform _trans;
	[SerializeField] float speed;
	[SerializeField] float speedJump;

	void Update ()
	{
		Vector2 velo = _rigid.velocity;
		velo.x = speed * Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Space)) {
			velo.y = speedJump * Time.deltaTime;
		}

		_rigid.velocity = velo;
	}

	void OnTriggerEnter2D (Collider2D hit)
	{
		if (hit.CompareTag (barrielTag)) {
			Debug.Log ("GameOver");
		}
	}

	void OnTriggerExit2D (Collider2D hit)
	{
		if (hit.CompareTag (jumpSpaceTag)) {
			GameMaster.gm.currentScore++;
		}
	}
}
