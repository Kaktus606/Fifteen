using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.Advertisements;
using UnityEngine.Advertisements;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class play : MonoBehaviour {
	void Awake ()
	{
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
			//.EnableSavedGames()
				// registers a callback to handle game invitations received while the game is not running.
				//.WithInvitationDelegate(<callback method>)
				// registers a callback for turn based match notifications received while the
				// game is not running.
				//.WithMatchDelegate(<callback method>)
				.Build();
		
		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
			//----выпиленая реклама   Advertisement.Initialize ("25545");
	}
	public void ToggleButtonChange (){
		//
		GameObject SoundToggle = (GameObject)GameObject.Find("Sound_button");
		Toggle SoundOff = (Toggle)SoundToggle.GetComponent ("Toggle");
		PlayerPrefs.SetString("SoundSettings",SoundOff.isOn.ToString());
		PlayerPrefs.Save();
	}
	public void StartGame() {

		Application.LoadLevel("Level1");
	}
	public void ExitGame() {
				Application.Quit() ;
	}
	public void Authors() {

		Application.LoadLevel ("Authors_scene") ;
	}
	public void ShowLeaderboard() {
		
		PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI7-Wxtb8NEAIQAQ");
	}
	public void ShowAchievements() {
		Social.ShowAchievementsUI();
	}
	public void CompleteAchievement() {
		Social.ReportProgress ("CgkI7-Wxtb8NEAIQAw", 100.0f, (bool success) => {
			});
			//		Social.ReportProgress ("CgkI7-Wxtb8NEAIQAw", 100.0f, (bool success) => {
			//		});
	}
}