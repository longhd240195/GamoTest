using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
	public static Pool pool;
	[SerializeField]GameObject barrielObject;
	[SerializeField]GameObject groundObject;
	[SerializeField] int numberBarriel;
	[SerializeField] int numberGround;

	public List<GameObject> groundInPool;
	public List<GameObject> barrielInPool;
	// Use this for initialization
	void Start ()
	{
		if (!pool) {
			pool = this;
			DontDestroyOnLoad (this.gameObject);

			SpawnObject ();
		} else
			DestroyImmediate (this.gameObject);
	}

	void SpawnObject ()
	{
//		groundInPool = new List<GameObject> ();
//		barrielInPool = new List<GameObject> ();
		StartCoroutine (SpawnObject (groundObject, numberGround, groundInPool));
		StartCoroutine (SpawnObject (barrielObject, numberBarriel, barrielInPool));
	}

	IEnumerator SpawnObject (GameObject obj, int number, List<GameObject> listStore)
	{
		Vector3 initPlace = new Vector3 (-100f, -100f, 0);
		for (int i = 0; i < number; i++) {
			GameObject newObj = Instantiate (obj, initPlace, Quaternion.identity, transform);
			yield return newObj;
			listStore.Add (newObj);
			newObj.SetActive (false);
		}
	}

	public GameObject GetGround ()
	{
		GameObject g = groundInPool [0];
		groundInPool.Remove (g);
		return g;
	}

	public GameObject GetBarriel ()
	{
		GameObject g = barrielInPool [0];
		barrielInPool.RemoveAt (0);
		return g;
	}

	public void AddGround (GameObject ground)
	{
		groundInPool.Add (ground);
		ground.SetActive (false);
	}

	public void AddBarriel (GameObject barriel)
	{
		barrielInPool.Add (barriel);
		barriel.SetActive (false);
	}
}
