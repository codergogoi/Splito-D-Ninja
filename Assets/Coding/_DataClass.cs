using UnityEngine;
using System.Collections;

public class _DataClass : MonoBehaviour {
	
	
	private float time;
	public static int Score;
	public GUIText txtScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		
		
		time += Time.deltaTime * 10;
							
		Score = ((int) Mathf.Round(time));
		
		txtScore.text = ""+Score;
}
}
