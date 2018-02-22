using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
	public Transform player;
	public Transform _trans;
	public Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		offset = _trans.position - player.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 newPos = player.position + offset;
		newPos.y = 0;
		_trans.position = newPos;
	}
}
