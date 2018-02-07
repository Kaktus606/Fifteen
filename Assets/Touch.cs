using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ff
{
		public class Touch : MonoBehaviour
		{
				private Vector3 centV;
				private GameObject parent;
				public int idO;
				// Use this for initialization
				void Awake ()
				{
						
				}

				public void setGridPoint (Vector3 center, int id, GameObject obj)
				{
						parent = obj;
						centV = center;
						idO = id;						
				}

				void OnMouseDown ()
				{
						ff.Grids g = (ff.Grids)parent.GetComponent ("Grids");
			if (!g.startGame) {
				g.gameTimer.Start();
				g.startGame = true;
			}

			g.tapCount++;
						GameObject te = g.findObject (
				centV + new Vector3 (0.1f, 0.0f, 0.0f),
				centV + new Vector3 (-0.1f, 0.0f, 0.0f),
				centV + new Vector3 (0.0f, 0.0f, -0.1f),
				centV + new Vector3 (0.0f, 0.0f, 0.1f)	
						);
						if (te != null) {
								Vector3 temp = this.transform.localPosition;
								this.transform.localPosition = te.transform.localPosition;
								centV = te.transform.localPosition;
								ff.Touch t = (ff.Touch)te.GetComponent ("Touch");
								//g.setNewCoor (te.transform.localPosition, idO);
								te.transform.localPosition = temp;
								t.centV = temp;

								string SoundSettings = PlayerPrefs.GetString ("SoundSettings");
								bool IsOn = bool.Parse (SoundSettings);
								if (!IsOn) {
										AudioSource Asound = (AudioSource)g.GetComponent ("AudioSource");
										Asound.PlayOneShot (Asound.clip);		//g.setNewCoor (temp, t.idO);
								}

						}

						g.checkFinal ();
				}
		}
}
