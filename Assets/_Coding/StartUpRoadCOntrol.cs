using UnityEngine;
using System.Collections;

public class StartUpRoadCOntrol : MonoBehaviour {
	
	public GameObject[] roads;
	

	// Use this for initialization
	void Start () {
	
		int rand = Random.Range(0,20);
		
		if(rand < 5){
			
			roads[0].SetActive(true);
			roads[1].SetActive(false);
			roads[2].SetActive(false);
			roads[3].SetActive(false);
			
		}else if(rand < 10){
			
			roads[0].SetActive(false);
			roads[1].SetActive(true);
			roads[2].SetActive(false);
			roads[3].SetActive(false);
			
		}else if(rand < 16){
			
			roads[0].SetActive(false);
			roads[1].SetActive(false);
			roads[2].SetActive(true);
			roads[3].SetActive(false);
			
		}else if(rand < 21){
			
			roads[0].SetActive(false);
			roads[1].SetActive(false);
			roads[2].SetActive(false);
			roads[3].SetActive(true);
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
