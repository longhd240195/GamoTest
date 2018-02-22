using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrielSetup : MonoBehaviour
{
	//	public float maxTop;
	//	public float minTop;
	[SerializeField] float maxBotton;
	[SerializeField] float minBottom;

	[SerializeField] float minSize;
	[SerializeField] float maxSize;
	[SerializeField] float sizeYBarriel = 10f;
	[SerializeField] Transform topBarriel;
	[SerializeField] Transform bottomBarriel;

	void OnEnable ()
	{
		SetUp ();
	}

	public void SetUp ()
	{
		float bottomBarrielPosition = Random.Range (minBottom, maxBotton);
		float sizeHold = Random.Range (minSize, maxSize);

		topBarriel.localPosition = new Vector3 (0, bottomBarrielPosition + sizeHold + sizeYBarriel, 0);
		bottomBarriel.localPosition = new Vector3 (0, bottomBarrielPosition, 0);
	}
}
