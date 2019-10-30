using UnityEngine;
using System.Collections;

public class CoinsControl : MonoBehaviour {
	
	public GameObject sPoint,ePoint;
	
	public GameObject coins;
	
	private int counter;
	private int curvcoin;
	private Vector3 newPos;
	private float ctime;
	
	// Use this for initialization
	void Start () {
	
		counter = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
		ctime+= Time.deltaTime * 2;
		
		if(ctime > Random.Range(5f,10.0f)){
			
			ctime = 0;
			counter = Random.Range(3,9);
			curvcoin = Random.Range(0,8);
			newPos =  new Vector3(sPoint.transform.position.x,Random.Range(0.7f,8.0f),sPoint.transform.position.z);
						
			
			int j = 0;
			int k = 0;

			for(int i = 0; i < counter; i++){
				
				if(curvcoin == 2 || curvcoin == 7){
					
						
					if(i > counter/2){
							
							newPos.y -= 0.5f;
							
						}else{
							
							newPos.y += 0.5f;
						}
						
						
						if(i > counter/2 -2 && j < 3){
							j++;
						
							newPos.x += 0.6f;
							
							if(j == 2){
							
								newPos.y -= 0.5f;
							}
						}
						
					newPos.x += 0.4f;
					
				}else{
					
					newPos.x += 1.0f;
				
				}
				
				GameObject go = Instantiate(coins,newPos,Quaternion.identity) as GameObject;
			
			}
			
		}
		
		/*
		if(Input.GetMouseButtonDown(0)){
			
			
			
			
			
			newPos.x += 2;
			
			sPoint.transform.position =  new Vector3(newPos.x,sPoint.transform.position.y,sPoint.transform.position.z);
			
			transform.position = new Vector3(newPos.x,transform.position.y,transform.position.z);
			
			
		}
		
	*/
	}
}
