using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HighScores : MonoBehaviour {

	public Text Player1;
	public Text Player2;
	public Text Player3;

	public Text Score1;
	public Text Score2;
	public Text Score3;


	int currentScore;
	string currentUser;



	// Use this for initialization
	void Start () {
		updateHierachy ();
		viewHierachy ();
	}



	void updateHierachy(){
		currentUser = PlayerPrefs.GetString ("User name");
		currentScore = PlayerPrefs.GetInt ("User score");

		string User1 = PlayerPrefs.GetString ("User1 name");
		string User2 = PlayerPrefs.GetString ("User2 name");
		string User3 = PlayerPrefs.GetString ("User3 name");

		int s1 = PlayerPrefs.GetInt ("User1 score");
		int s2 = PlayerPrefs.GetInt ("User2 score");
		int s3 = PlayerPrefs.GetInt ("User3 score");

		// if best score 

		if (currentScore > s1) {


			PlayerPrefs.SetString ("User3 name", User2);
			PlayerPrefs.SetInt ("User3 score", s2);

			PlayerPrefs.SetString ("User2 name", User1);
			PlayerPrefs.SetInt ("User2 score", s1);

			PlayerPrefs.SetString ("User1 name", currentUser);
			PlayerPrefs.SetInt ("User1 score", currentScore);

		}
		// second 
		else if (currentScore < s1 && currentScore > s2) {
			
			PlayerPrefs.SetString ("User3 name", User2);
			PlayerPrefs.SetInt ("User3 score", s2);

			PlayerPrefs.SetString ("User2 name", currentUser);
			PlayerPrefs.SetInt ("User2 score", currentScore);

		}

		//third

		else if (currentScore < s2 && currentScore > s3) {

			PlayerPrefs.SetString ("User3 name", currentUser);
			PlayerPrefs.SetInt ("User3 score", currentScore);

		}
			
	}



	void viewHierachy(){


		string User1 = PlayerPrefs.GetString ("User1 name");
		string User2 = PlayerPrefs.GetString ("User2 name");
		string User3 = PlayerPrefs.GetString ("User3 name");

		int s1 = PlayerPrefs.GetInt ("User1 score");
		int s2 = PlayerPrefs.GetInt ("User2 score");
		int s3 = PlayerPrefs.GetInt ("User3 score");


		int first = 0;

		int third = 0;
	



		// fill first place

		if (s1 >= s2 && s1 >= s3) {
			Player1.text = User1;
			Score1.text = " " + s1;
			first = 1;
		} else if (s2 >= s1 && s2 >= s3) {
			Player1.text = User2;
			Score1.text = " " + s2;
			first = 2;
		} else if (s3 >= s1 && s3 >= s2) {
			Player1.text = User3;
			Score1.text = " " + s3;
			first = 3;
		}

		//fill last place

		if (s1 <= s2 && s1 <= s3) {
			Player3.text = User1;
			Score3.text = " " + s1;
			third = 1;
		} else if (s2 <= s1 && s2 <= s3) {
			Player3.text = User2;
			Score3.text = " " + s2;
			third = 2;
		} else if (s3 <= s1 && s3 <= s2) {
			Player3.text = User3;
			Score3.text = " " + s3;
			third = 3;
		}

		if (first == 1 && third == 2) {
			Player2.text = User3;
			Score2.text = " " + s3;
		}
		else if (first == 1 && third == 3) {
			Player2.text = User2;
			Score2.text = " " + s2;
		}
		else if (first == 2 && third == 1) {
			Player2.text = User3;
			Score2.text = " " + s3;
		}
		else if (first == 2 && third == 3) {
			Player2.text = User1;
			Score2.text = " " + s1;
		}
		else if (first == 3 && third == 1) {
			Player2.text = User2;
			Score2.text = " " + s2;
		}
		else if (first == 3 && third == 2) {
			Player2.text = User1;
			Score2.text = " " + s1;
		}
			
	}
	

}
