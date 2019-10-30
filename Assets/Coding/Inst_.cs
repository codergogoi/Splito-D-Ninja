using UnityEngine;
using System.Collections;

public class Inst_ : MonoBehaviour {
	
	
	public GameObject New_Path;
	
	private GameObject Path_Node;
	private GameObject Temp_Path;
	//
	
	void OnTriggerEnter(Collider coll){
		
		//print(coll.tag);
		
		if(coll.collider.tag=="StartTrigger"){
			
			Path_Node = GameObject.Find("_path");
			
			Temp_Path = Instantiate(New_Path,Path_Node.transform.position,Path_Node.transform.rotation)as GameObject;			
			
		}
		
		if(coll.collider.tag=="EndTrigger"){
			
			coll.gameObject.GetComponent<EndTrigger>().isDeath = true;
			
		}
		
		if(coll.collider.tag=="_ob1"){
			
			coll.gameObject.GetComponent<obs_1>().isOb1 = true;
			
		}
		if(coll.collider.tag=="_ob2"){
			
			coll.gameObject.GetComponent<obs_1>().isOb1 =true;
			
		}
		
	}
	
	
}
