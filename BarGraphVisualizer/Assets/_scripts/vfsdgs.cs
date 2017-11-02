using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FileManager : MonoBehaviour {

	// Use this for initialization
	private string filePath;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenFile()
	{
		filePath = EditorUtility.OpenFilePanel ("Open the excel sheet", "D", "csv");
		Debug.Log ("File Location="+filePath);
	}
}
