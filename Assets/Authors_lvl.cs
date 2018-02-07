using UnityEngine;
using System.Collections;

public class Authors_lvl : MonoBehaviour {
		
	public void Backtomenu() {
		
		Application.LoadLevel("Main Menu");
		}
	public void Facebook() {
		
		Application.OpenURL("https://www.facebook.com/yan.asadchy");
	}
	public void Web() {
		
		Application.OpenURL("http://cactus606.carbonmade.com/");
	}
}
