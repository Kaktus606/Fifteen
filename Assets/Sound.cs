using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sound : MonoBehaviour
{

		// Use this for initialization
		void Awake ()
		{

				string SoundSettings = PlayerPrefs.GetString ("SoundSettings", "Null");
				if (SoundSettings != "Null") {
						bool IsOn = bool.Parse (SoundSettings);
						GameObject Trigger = (GameObject)GameObject.Find ("Sound_button");
						Toggle SoundOff = (Toggle)Trigger.GetComponent ("Toggle");
						if (IsOn) {								
								SoundOff.isOn = true;

						} else {
								SoundOff.isOn = false;

						}
				} else {
						GameObject SoundToggle = (GameObject)GameObject.Find ("Sound_button");
						Toggle SoundOff = (Toggle)SoundToggle.GetComponent ("Toggle");
						PlayerPrefs.SetString ("SoundSettings", SoundOff.isOn.ToString ());
						PlayerPrefs.Save ();

				}
		}
}


