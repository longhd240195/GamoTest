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
			GameObject ground = Pool.pool.GetGround ();
			Vector2 newPosition = hit.transform.position;
			newPosition.x += distanceGround;
			ground.transform.position = newPosition;
			ground.SetActive (true);
		} else if (hit.CompareTag (barrielTag)) {
			GameObject barriel = Pool.pool.GetBarriel ();
			Vector2 newPosition = hit.transform.position;
			newPosition.x += distanceBarriel;
			barriel.transform.position = newPosition;
			barriel.SetActive (true);
		}
	}
}
