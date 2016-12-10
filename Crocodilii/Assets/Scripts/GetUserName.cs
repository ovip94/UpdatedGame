using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetUserName : MonoBehaviour {

	public InputField User;

	/*// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

*/

	public void ApplyPressed()
	{
		int score = 70;
	

		PlayerPrefs.SetString ("User name", User.text);
		PlayerPrefs.SetInt ("User score", score);

		if (0 == PlayerPrefs.GetInt ("User1 score")) {
			PlayerPrefs.SetString ("User1 name", "User1");
			PlayerPrefs.SetInt ("User1 score", 30);
		}
		if (0 == PlayerPrefs.GetInt ("User2 score")) {
			PlayerPrefs.SetString ("User2 name", "User2");
			PlayerPrefs.SetInt ("User2 score", 20);
		}
		if (0 == PlayerPrefs.GetInt ("User3 score")) {
			PlayerPrefs.SetString ("User3 name", "User3");
			PlayerPrefs.SetInt ("User3 score", 10);
		}


	
	
	}
}
