using UnityEngine;
using System.Collections;

public class _GameManager : MonoBehaviour {
	
	
	
	public GUITexture PauseBtn;
	
	public static bool isGameOver;
	
	
	public _GameOver gover;
	public GameObject CameBG;
	
	private bool isGameEnd;
	private float tmx;
	
	public GameObject PauseMenu;

	public GameObject CBMAnager;
	// Use this for initialization
	void Start () {
	
		isGameOver = false;
	}
	
	public void OnGameOver(bool isOver){
		
		isGameOver = isOver;
		isGameEnd = true;
		StartCoroutine(WaitForDelay(0.1f));
		
	}
	
	IEnumerator WaitForDelay(float tm){
		
		yield return new WaitForSeconds(tm);
		
		if(isGameOver){
			gover.onInit();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isGameEnd){
			
			 tmx+= Time.deltaTime * 2;
			
			float alpha = Mathf.Lerp(1.0f,0.2f,tmx/2);
			CameBG.renderer.material.color = new Color(1.0f,1.0f,1.0f,alpha);
				
 		
		}
		
		if(Input.GetMouseButtonDown(0)){
			
			Vector3 pos = Input.mousePosition;
			
			if(PauseBtn.HitTest(pos) && Time.timeScale > 0){
				CBMAnager.SendMessage("CallCBAdds");
				Instantiate(PauseMenu);
				//Time.timeScale= 0;
				
				
			}
			
			
			
		}
		
		
		
	
	}
}
