using UnityEngine;
using System.Collections;

public class _AIProjectileDestroy : MonoBehaviour {
	
	
	public GameObject explosionParticle;
	
	public GameObject box;
	
	// Use this for initialization
	void Start () {
		
		Destroy(gameObject,5.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
	
	}
	
	
	void OnCollisionEnter(Collision coll){
		
		
		//print("collision");
		
		if(coll.collider.tag == "Player"){
			
			explosionParticle.SetActive(true);
			Destroy(gameObject,1f);
			
		}
		
		if(coll.collider.tag == "ground"){
			
			/*
			GameObject go;
			
			for(int i = 0; i < Random.Range(4,10); i++){
			
					go = Instantiate(box,transform.position,transform.rotation) as GameObject;	
					//go.rigidbody.rigidbody.velocity = new Vector3(Random.Range(-2,-15),Random.Range(1,15),0);
				
			}
			*/
			
			
			explosionParticle.SetActive(true);
			Destroy(gameObject,0.5f);
		}
		
		if(coll.collider.tag =="axe"){
		
			Destroy(gameObject,0.2f);
		}
		
		
		
}
}
