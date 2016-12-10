using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour {

	public void ChangeToScene ( int noScene ){

		SceneManager.LoadScene ( noScene );
	}
			
}
