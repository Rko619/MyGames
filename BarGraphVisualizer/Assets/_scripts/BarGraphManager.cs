using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGraphManager : MonoBehaviour {
	
	public Transform origin;
	public GameObject cubePrefab;
	public int maxAge;
	public float spaceCorrectionValue;
	[System.Serializable]
	public struct BarData
	{
		public string userName;
		public float age;
		public GameObject cubePrefab;
	};
	public BarData[] userData;


	private float spaceBetweenBars;




	void Start () 
	{
		spaceBetweenBars = cubePrefab.GetComponent<Renderer> ().bounds.extents.z+spaceCorrectionValue;
		InitializeBarGraph ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DrawBarGraph() {
		
		for (int i = 0; i < userData.Length; i++) {
			userData [i].cubePrefab.transform.localScale = new Vector3 (userData [i].cubePrefab.transform.localScale.x, userData [i].age, userData [i].cubePrefab.transform.localScale.y);
		}
	}

	void InitializeBarGraph() {
		Vector3 lastPosition=Vector3.zero;
		float cubeBoundZValue = 0;
		cubeBoundZValue=cubePrefab.GetComponent<Renderer> ().bounds.extents.z*2f;
		for (int i = 0; i < userData.Length; i++) {
			lastPosition = new Vector3(origin.position.x,origin.position.y,cubeBoundZValue+lastPosition.z+ spaceBetweenBars);
			userData[i].cubePrefab=Instantiate (cubePrefab, lastPosition, Quaternion.identity);
		}

		DrawBarGraph ();
	}
}
