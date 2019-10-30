using UnityEngine;
using System.Collections;

public class _SimpleCoins : MonoBehaviour {
	
		
	private float tm;
	
	private float speed;
	

	void Start () {
		Destroy(gameObject,20);
		transform.eulerAngles = new Vector3(90,0,0);
		//speed = Random.Range(50.0f,100.0f);
	}
	
	void Update () {
		
			
		//tm += Time.deltaTime * speed;
		
		
		
		
		
		
	}
	
	
	void OnTriggerEnter(Collider coll){
		
		
		
		if(coll.tag=="Player"){
			
			Destroy(gameObject,0.1f);
		}
	}
	
	
}
