using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;


public class GUI_Manager : MonoBehaviour {
	public void Back() {

		if(Advertisement.isReady()){ Advertisement.Show(); }

		Application.LoadLevel("Main menu");
	}
	public void Reset() {
		Application.LoadLevel("Level1");
	}
	public void CongrCont() {
		if(Advertisement.isReady()){ Advertisement.Show(); }
		Application.LoadLevel("Main menu");
	}
}
