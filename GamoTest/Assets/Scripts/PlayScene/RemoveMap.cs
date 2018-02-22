using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMap : MonoBehaviour
{
	[SerializeField] string groundTag = "Ground";
	[SerializeField] string barrielTag = "GroupBarriel";

	void OnTriggerEnter2D (Collider2D hit)
	{
		GameObject obj = hit.gameObject;
		if (hit.CompareTag (groundTag)) {
			Pool.pool.AddGround (obj);
		} else if (hit.CompareTag (barrielTag)) {
			Pool.pool.AddBarriel (obj);
		}
	}
}
