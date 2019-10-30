using UnityEngine;
using System.Collections;

public class _Options : MonoBehaviour {
	
	public GUITexture back,buyFullGame,BuyAddFree,SoundOn;
	
	public Texture2D[] soundImg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButtonDown(0)){
			
			
			Vector3 pos = Input.mousePosition;
			
			if(back.HitTest(pos)){
				
				Application.LoadLevel(0);
			}
			
			
			if(buyFullGame.HitTest(pos)){
				
				
			}
			
			
			if(BuyAddFree.HitTest(pos)){
				
				
			}
			
			
			if(SoundOn.HitTest(pos)){
				
				if(PlayerPrefs.GetInt("BGFX") > 0){
					SoundOn.texture = soundImg[0];
					PlayerPrefs.SetInt("BGFX", 0);
				}else{
					SoundOn.texture = soundImg[1];
					PlayerPrefs.SetInt("BGFX", 1);
				}
				
			}
			
			
			
			
		}
	
	}
}
