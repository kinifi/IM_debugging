using UnityEngine;
using System.Collections;

public class mainFileRead : MonoBehaviour {

	public bool saveFile = false, statsFile = false, debugFile = false;
	public GUISkin skin;
	private string fileLocation;

	// Use this for initialization
	void Start () {
	
		fileLocation = Application.dataPath + "/" + "Debugfiles" + "/";

		if(checkIfFilesExist("Debug.txt"))
			debugFile = true;

		if(checkIfFilesExist("stats.txt"))
			statsFile = true;

		if(checkIfFilesExist("imsave.txt"))
			saveFile = true;

	}

	private bool checkIfFilesExist(string fileName) {

		if(ES2.Exists(fileLocation + fileName))
		{
			return true;
		}
		else
		{
			return false;
		}
	}


	void OnGUI () {

		GUI.skin = skin;

		GUILayout.BeginArea(new Rect( 10, 10, Screen.width/2, Screen.height));
		GUILayout.Label("Debug File Information");
		debugFileInformation();

		GUILayout.Label("Stats File Information");
		statsFileInformation();

		GUILayout.Label("Save File Information");
		saveFileInformation();


		GUILayout.EndArea();
	}

	private void saveFileInformation() {

		if(!saveFile)
		{
			GUILayout.Label("Save File .txt does not exist in the folder");
			GUILayout.Space(10);
		}
		else
		{
			int _test;
			_test = ES2.Load<int>(fileLocation + "imsave" + ".txt" + "?tag=levelUnlock");
			
			GUILayout.Label("tag: levelUnlock: " + _test);

		}
	}

	private void statsFileInformation() {

		if(!statsFile)
		{
			GUILayout.Label("Stats File .txt does not exist in the folder");
			GUILayout.Space(10);
		}
		else
		{
			int _stat1;
			int _stat2;
			int _stat3;
			int _stat4;

			_stat1 = ES2.Load<int>(fileLocation + "stats" + ".txt" + "?tag=deathBySpike");
			_stat2 = ES2.Load<int>(fileLocation + "stats" + ".txt" + "?tag=deathByFalling");
			_stat3 = ES2.Load<int>(fileLocation + "stats" + ".txt" + "?tag=trampolineJumps");
			_stat4 = ES2.Load<int>(fileLocation + "stats" + ".txt" + "?tag=normalJumps");


			if(_stat1 != null)
			{
				GUILayout.Label("tag: deathBySpike: " + _stat1);
				GUILayout.Label("tag: deathByFalling: " + _stat2);
				GUILayout.Label("tag: trampolineJumps: " + _stat3);
				GUILayout.Label("tag: normalJumps: " + _stat4);

			}
		}

	}

	private void debugFileInformation () {

		if(!debugFile)
		{
			GUILayout.Label("Debug File .txt does not exist in the folder");
			GUILayout.Space(10);
		}
		else
		{
			string _test;
			_test = ES2.Load<string>(fileLocation + "Debug" + ".txt" + "?tag=achievement");

			GUILayout.Label("tag: achievement: " + _test);
		}
	}

}
