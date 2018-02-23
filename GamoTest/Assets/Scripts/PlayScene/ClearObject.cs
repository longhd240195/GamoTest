using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearObject : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D hit)
	{
		GameObject obj = hit.gameObject;
		if (hit.CompareTag (Constant.groundTag)) {
			Pool.pool.AddGround (obj);
		} else if (hit.CompareTag (Constant.groupBarrielTag)) {
			Pool.pool.AddBarriel (obj);
		}
	}
}
