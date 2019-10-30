using UnityEngine;
using System.Collections;

public class obs_1 : MonoBehaviour {
	
	
	//obstracle Varity;
	public GameObject Tall_obj;
	public GameObject Mid_obj;
	public GameObject small_obj;
	public GameObject small_Cactus;
	public GameObject big_Cactus;
	public GameObject small_Hunter;
	public GameObject big_Hunter;
	//inherit to RootObj;
	private GameObject RootObj;
	
	//position
	public GameObject _p1;
	public GameObject _p2;
	//vectores 
	
	private Vector3 pos;
	private GameObject temp; 
	
	private float time;
	private float etm;
	public bool isOb1;
	private int rand;
	
	// Use this for initialization
	void Start () {
	
		StartCoroutine(WaitForEnd(3.0f));
		
	}
	
	
	IEnumerator WaitForEnd(float tm){
		
		
		yield return new WaitForSeconds(tm);
		
		isOb1 = false;
	}
	
	
	// Update is called once per frame
	void Update () {

		if(isOb1){
			
			etm += Time.deltaTime;
	
			time += Time.deltaTime;
			
			if(time > 0.33f){
				
				pos = new  Vector3(Random.Range(_p1.transform.position.x,_p2.transform.position.x),0, Random.Range(_p1.transform.position.z,_p2.transform.position.z));
				
				rand = Random.Range(0,8);
				
				switch(rand){
					
					
				case 1:
					RootObj = Tall_obj;
					break;
				case 2:
					RootObj = Mid_obj;
					break;
				case 3:
					RootObj = small_obj;
					break;
				case 4:
					RootObj = small_Cactus;
					break;
				case 5:
					RootObj = big_Cactus;
					break;
				case 6:
					RootObj = small_Hunter;
					break;
				case 7:
					RootObj = big_Hunter;
					break;
				default:
					RootObj = Mid_obj;
					break;
				}
				
				temp = Instantiate(RootObj,pos,_p1.transform.rotation) as GameObject;
				time = 0;
			}
			
			if(etm > 6.0f){
				
				StartCoroutine(WaitForEnd(0.2f));
				etm = 0;
			}
		
		}
	}
}
