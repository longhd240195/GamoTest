using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
	[SerializeField] float distanceBarriel = 11f;
	[SerializeField] float distanceGround = 10f;
	[SerializeField] string groundTag = "Ground";
	[SerializeField] string barrielTag = "GroupBarriel";


	void OnTriggerEnter2D (Collider2D hit)
	{
		if (hit.CompareTag (groundTag)) {
			
		} else if (hit.CompareTag (barrielTag)) {
			
		}
	}
}
