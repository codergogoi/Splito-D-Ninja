using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {
	
	public bool isDeath;
	public GameObject p;
	public GameObject S_point;
	
	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(isDeath){
			Destroy(S_point);
			StartCoroutine(WaitForDestroy(3.5f));
		}
	}
	
	IEnumerator WaitForDestroy(float tm){
		
		yield return new WaitForSeconds(tm);
		
		Destroy(p);
		
	}
	

		
}
