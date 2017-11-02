using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;

public class FileManager : MonoBehaviour {

	// Use this for initialization
	public Text fileLocationText;
	public string[] filePaths;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenFile()
	{
		filePaths = StandaloneFileBrowser.OpenFilePanel ("Open Excel Sheet","", "xlsx", false);
		if (filePaths.Length > 0)
			fileLocationText.text = filePaths [0];
		else
			fileLocationText.text = "No file";
	}
}
