using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
		
	public GameObject spoint;
	private GameObject toproad;
	//public GameObject road1,road2,road3,road4,road5;
	
	private int roadrand;
	
	private Vector3 pos;
	private bool isTop;
	
	// Use this for initialization
	void Start () {
		pos = spoint.transform.position;
		//ToproadClone();		
		Destroy(gameObject,100.0f);	
		
		
		
	}
	
	
	/*
	void ToproadClone(){
		
		int max = Random.Range(2,5);
		for(int i = 0; i < max; i++){
			
			
			roadrand = Random.Range(0,5);
			
				pos.x += Random.Range(20,26);
				pos.y = Random.Range(3,9);
			
			
			switch(roadrand){
				
			case 0:
				toproad = road1;
				break;
			case 1:
				toproad = road2;
				break;
			case 2:
				toproad = road3;
				break;
			case 3:
				toproad = road4;
				break;
			case 4:
				toproad = road5;
				break;
			default :
				toproad = road1;
				break;
				
			}
			
				//GameObject go = Instantiate(toproad,pos,Quaternion.Euler(270,0,0)) as GameObject;
			
		}
			
			
			
			
		}
		
		*/

	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
}
