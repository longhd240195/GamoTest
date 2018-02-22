using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] string barrielTag = "Barriel";
	[SerializeField] string	jumpSpaceTag = "JumpSpace";

	void OnTriggerEnter2D (Collider2D hit)
	{
		if (hit.CompareTag (barrielTag)) {
			
		}
	}

	void OnTriggerExit2D (Collider2D hit)
	{
		if (hit.CompareTag (jumpSpaceTag)) {
			GameMaster.gm.currentScore++;
		}
	}
}
