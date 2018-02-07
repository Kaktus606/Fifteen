using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

namespace ff
{
		public class Grids : MonoBehaviour
		{
				public Text tapCountTextData;
				public Text secondsTextData;
				public bool endGame;
				public bool startGame;
				public System.Timers.Timer gameTimer;
				public int tapCount;
				public int seconds;
				private float[] rand;
				private float[] randObj;
				public Vector3[] gridPoint;
				public List<GameObject> tiles;
				private enum State
				{
						Loaded, 
						WaitingForInput, 
						CheckingMatches,
						GameOver
				}
				private State state;

				public Vector3[] getGridPoint ()
				{
						return gridPoint;
				}

				public GameObject findObject (Vector3 u, Vector3 d, Vector3 l, Vector3 r)
				{
						for (int i = 0; i < 16; i++) {
								if (u == tiles [i].transform.localPosition) {
										if (tiles [i].tag == "Trat")
												return tiles [i];
								} else if (d == tiles [i].transform.localPosition) {
										if (tiles [i].tag == "Trat")
												return tiles [i];
								} else if (l == tiles [i].transform.localPosition) {
										if (tiles [i].tag == "Trat")
												return tiles [i];
								} else if (r == tiles [i].transform.localPosition) {
										if (tiles [i].tag == "Trat")
												return tiles [i];
								}
						}
						return null;
				}

				public void checkFinal ()
				{
						bool flag = true;
						for (int i = 0; i < 16; i++) {
								if (tiles [i].transform.localPosition != gridPoint [i])
										flag = false;
						}
						//flag = true;-------------------------------------------------------------------------------------------------
						if (flag) {
								GameObject SoundToggle = (GameObject)GameObject.Find ("congrats");
								Image congrtOn = (Image)SoundToggle.GetComponent ("Image");
								Thread.Sleep (500);
								congrtOn.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
								gameTimer.Stop ();
								endGame = true;
								int resultScore = seconds * tapCount;
				//---1st place
								if (1 < resultScore && resultScore< 4000) {
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQAg", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQAw", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBA", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBQ", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBg", 100.0f, (bool success) => {
								});
								}
				//---2nd place
								if (4001 < resultScore && resultScore< 8000) {
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQAw", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBA", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBQ", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBg", 100.0f, (bool success) => {
								});
								}

				//---3rd place
								if (8001 < resultScore && resultScore< 32000) {
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBA", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBQ", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBg", 100.0f, (bool success) => {
								});
								}
				//---4th place
								if (32001 < resultScore && resultScore< 128000) {
								Social.ReportProgress ("CgkI7-Wxtb8NEAIQBQ", 100.0f, (bool success) => {
								});
										Social.ReportProgress ("CgkI7-Wxtb8NEAIQBg", 100.0f, (bool success) => {
								});
								}
				//---5th place
								if (128001 < resultScore && resultScore< 256000) {
								Social.ReportProgress ("CgkI7-Wxtb8NEAIQBg", 100.0f, (bool success) => {
								});
								}
				//---posting score
								Social.ReportScore (resultScore, "CgkI7-Wxtb8NEAIQAQ", (bool success) => {
								});
								
						}
				}

				public void setNewCoor (Vector3 coor, int id)
				{
						tiles [id].transform.localPosition = coor;
				}

				void sortFloatArray (float[] floatArray)
				{
						bool sort = false;
						float temp = 0.0f;
						while (!sort) {
								sort = true;
								for (int i = 0; i < 14; i++) {
										if (floatArray [i] > floatArray [i + 1]) {
												temp = floatArray [i];
												floatArray [i] = floatArray [i + 1];
												floatArray [i + 1] = temp;
												sort = false;
										}
								}
						}
				}
				// Use this for initialization
				void Awake ()
				{	
						endGame = false;
						startGame = false;

						GameObject tapCountText = (GameObject)GameObject.Find ("taps");
						tapCountTextData = (Text)tapCountText.GetComponent ("Text");
						GameObject secondsText = (GameObject)GameObject.Find ("seconds");
						secondsTextData = (Text)secondsText.GetComponent ("Text");
						seconds = 0;
						tapCount = 0;

						gameTimer = new System.Timers.Timer ();
						gameTimer.Elapsed += new System.Timers.ElapsedEventHandler (OnTimeIvent);
						gameTimer.Interval = 1000;

						//----------------------
						// post score 12345 to leaderboard ID "CgkI7-Wxtb8NEAIQAQ")
						//@@@@@@@@@@@@@    Social.ReportScore(12345, "CgkI7-Wxtb8NEAIQAQ", (bool success) => {
						// handle success or failure
						//@@@@@@@@@@@@@    });
						//----------------------
						rand = new float[15];
						randObj = new float[15];
						//				
						tiles = new List<GameObject> ();
						for (int i = 1; i < 16; i++) {			
								tiles.Add (GameObject.Find (string.Format ("Cube_{0}", i.ToString ("00"))));
						}
						GameObject go = new GameObject ();
						tiles.Add (go);
						//
						gridPoint = new Vector3[16];
						gridPoint [0].Set (0.0f, 0.1f, 0.0f);
						gridPoint [1].Set (0.0f, 0.1f, 0.1f);
						gridPoint [2].Set (0.0f, 0.1f, 0.2f);
						gridPoint [3].Set (0.0f, 0.1f, 0.3f);
						gridPoint [4].Set (0.1f, 0.1f, 0.0f);
						gridPoint [5].Set (0.1f, 0.1f, 0.1f);
						gridPoint [6].Set (0.1f, 0.1f, 0.2f);
						gridPoint [7].Set (0.1f, 0.1f, 0.3f);
						gridPoint [8].Set (0.2f, 0.1f, 0.0f);
						gridPoint [9].Set (0.2f, 0.1f, 0.1f);
						gridPoint [10].Set (0.2f, 0.1f, 0.2f);
						gridPoint [11].Set (0.2f, 0.1f, 0.3f);
						gridPoint [12].Set (0.3f, 0.1f, 0.0f);
						gridPoint [13].Set (0.3f, 0.1f, 0.1f);
						gridPoint [14].Set (0.3f, 0.1f, 0.2f);
						gridPoint [15].Set (0.3f, 0.1f, 0.3f);
						while (!GenerateLevel()) {
						}
						;
						for (int i = 0; i < 15; i++) {			
								ff.Touch h;
								Transform f;
								for (int j = 0; j < 15; j++) {
										if (randObj [i] == rand [j]) {
												f = tiles [j].transform;
												tiles [j].tag = "Player";
												h = (ff.Touch)tiles [j].AddComponent ("Touch");
												h.setGridPoint (gridPoint [i], j, this.gameObject);
												f.localPosition = gridPoint [i];
										}
								}								
						}
						Transform f1 = tiles [15].transform;
						ff.Touch h1 = (ff.Touch)tiles [15].AddComponent ("Touch");
						tiles [15].tag = "Trat";
						h1.setGridPoint (gridPoint [15], 15, this.gameObject);
						f1.localPosition = gridPoint [15];
						state = State.Loaded;
				}

				bool GenerateLevel ()
				{
						System.DateTime dt = System.DateTime.Now;
						int seed = (int)dt.Ticks;
						Random.seed = seed;
						float temp = 0.0f;
						for (var i = 0; i < rand.Length; i++) {
								temp = Random.value;
								rand [i] = temp;
								randObj [i] = temp;
						}
						sortFloatArray (rand);
						//
						int[] teid = new int[15];
						for (int i = 0; i < 15; i++) {			
								for (int j = 0; j < 15; j++) {
										if (randObj [i] == rand [j]) {
												teid [i] = j + 1;
										}
								}								
						}
						int count = 0;
						for (int i = 0; i < 15; i++) {	
								for (int ii = i + 1; ii < 15; ii++) {
										if (teid [i] > teid [ii])
												count++; 								
								}
						}
						int gg = count % 2;
						if (gg == 0)
								return true;
						else
								return false;
				}
			
				void Update ()
				{
						if (!endGame) {
						
								int tempSecond = (seconds % 3600) % 60;
								int hours = seconds / 3600;
								int minutes = (seconds % 3600) / 60;
								secondsTextData.text = hours.ToString ("00") + ":" + minutes.ToString ("00") + ":" + tempSecond.ToString ("00");
								tapCountTextData.text = tapCount.ToString ("0000000");
						}
				}

				void OnDestroy ()
				{
						gameTimer.Stop ();
				}

				void OnTimeIvent (object source, System.Timers.ElapsedEventArgs e)
				{
						seconds++;

						//	secondsTextData.text = hours.ToString ("00") + ":" + minutes.ToString ("00") + ":" + seconds.ToString (":");
				}

		}
}