using UnityEngine;
using System.Collections;

public class _AdBonus : MonoBehaviour {

	public AudioClip CoinsSound;


	void Start(){

		Initialize();


	}



	void Update(){
 

	}


	public void ShowVideoAdd(){

		PlayAVideo("vzc731a439072747168a");

	}

		public void Initialize()
		{
			// Assign any AdColony Delegates before calling Configure
			AdColony.OnVideoFinished = this.OnVideoFinished;
			
			// If you wish to use a the customID feature, you should call  that now.
			// Then, configure AdColony:
			AdColony.Configure
				(
					"2.0", // Arbitrary app version and Android app store declaration.
					"appd6bb55f42e354847b2",   // ADC App ID from adcolony.com
					"vzc731a439072747168a", // A zone ID from adcolony.com
					"vzc731a439072747168a", // Any number of additional Zone IDS
					"vzc731a439072747168a"
					);
		}
		
		// When a video is available, you may choose to play it in any fashion you like.
		// Generally you will play them automatically during breaks in your game,
		// or in response to a user action like clicking a button.
		// Below is a method that could be called, or attached to a GUI action.
		public void PlayAVideo( string zoneID )
		{
			// Check to see if a video is available in the zone.
			if(AdColony.IsVideoAvailable(zoneID))
			{
				Debug.Log("Play AdColony Video");
				// Call AdColony.ShowVideoAd with that zone to play an interstitial video.
				// Note that you should also pause your game here (audio, etc.) AdColony will not
				// pause your app for you.
				AdColony.ShowVideoAd(zoneID); 
			}
			else
			{
				Debug.Log("Video Not Available");
			}
		}
		
		private void OnVideoFinished(bool ad_was_shown)
		{
			Debug.Log("On Video Finished");
			
			int MyStemina = PlayerPrefs.GetInt("STEMINA");
			MyStemina+=30;
			PlayerPrefs.SetInt("STEMINA",MyStemina);

			audio.PlayOneShot(CoinsSound);
			// load clellange mode here
			// Resume your app here.
		}
	}