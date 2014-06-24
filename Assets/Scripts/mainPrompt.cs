using UnityEngine;
using System.Collections;
using System.IO;

public class mainPrompt : MonoBehaviour {

	private bool hasPlaceFiles = false;

	// Use this for initialization
	void Start () {
	
		if(ES2.Exists(Application.dataPath + "/" + "Debugfiles"))
		{
			Debug.Log("File Exists");
		}
		else
		{
			ES2.Save(123, Application.dataPath + "/Debugfiles/dummyfile.txt");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		GUILayout.BeginArea(new Rect(Screen.width/2-200, Screen.height-100, 200, 200));
		if(GUILayout.Button("Open Folder"))
		{
			OpenInFileBrowser(Application.dataPath + "/" + "Debugfiles");
			hasPlaceFiles = true;
		}
		if(hasPlaceFiles)
		{
			if(GUILayout.Button("Read Files"))
			{
				Debug.Log("Go Read Files");
				Application.LoadLevel("scene2");
			}
		}

		GUILayout.EndArea();
	}

	public static void OpenInMacFileBrowser(string path)
	{
		bool openInsidesOfFolder = false;
		
		// try mac
		string macPath = path.Replace("\\", "/"); // mac finder doesn't like backward slashes
		
		if (Directory.Exists(macPath)) // if path requested is a folder, automatically open insides of that folder
		{
			openInsidesOfFolder = true;
		}
		
		//Debug.Log("macPath: " + macPath);
		//Debug.Log("openInsidesOfFolder: " + openInsidesOfFolder);
		
		if (!macPath.StartsWith("\""))
		{
			macPath = "\"" + macPath;
		}
		if (!macPath.EndsWith("\""))
		{
			macPath = macPath + "\"";
		}
		string arguments = (openInsidesOfFolder ? "" : "-R ") + macPath;
		//Debug.Log("arguments: " + arguments);
		try
		{
			System.Diagnostics.Process.Start("open", arguments);
		}
		catch(System.ComponentModel.Win32Exception e)
		{
			// tried to open mac finder in windows
			// just silently skip error
			// we currently have no platform define for the current OS we are in, so we resort to this
			e.HelpLink = ""; // do anything with this variable to silence warning about not using it
		}
	}
	
	public static void OpenInWinFileBrowser(string path)
	{
		bool openInsidesOfFolder = false;
		
		// try windows
		string winPath = path.Replace("/", "\\"); // windows explorer doesn't like forward slashes
		
		if (Directory.Exists(winPath)) // if path requested is a folder, automatically open insides of that folder
		{
			openInsidesOfFolder = true;
		}
		try
		{
			System.Diagnostics.Process.Start("explorer.exe", (openInsidesOfFolder ? "/root," : "/select,") + winPath);
		}
		catch(System.ComponentModel.Win32Exception e)
		{
			// tried to open win explorer in mac
			// just silently skip error
			// we currently have no platform define for the current OS we are in, so we resort to this
			e.HelpLink = ""; // do anything with this variable to silence warning about not using it
		}
	}
	
	public static void OpenInFileBrowser(string path)
	{
		OpenInWinFileBrowser(path);
		OpenInMacFileBrowser(path);
	}

}
