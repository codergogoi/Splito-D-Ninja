using UnityEngine;
using System.Collections;

public class _BalloneShooter : MonoBehaviour {


	private float rotX;
	private float speed;
	public GameObject[] spoint;
	
	public GameObject Bomb;
	private float bombTime;
	private int rand;
 	
	
	// Use this for initialization
	void Start () {
		
		speed = Random.Range(50,200);
		
	 
	}
	
	// Update is called once per frame
	void Update () {
	
		 bombTime+= Time.deltaTime;
		
		if(bombTime > Random.Range(0.9f,3.5f)){
			rand = Random.Range(0,6);
			
			if(rand > 3){
				GameObject go1 = Instantiate(Bomb,spoint[0].transform.position,spoint[0].transform.rotation)as GameObject;
				go1.rigidbody.velocity = new Vector3(Random.Range(-5,30),Random.Range(-5,-50),0);
			}else{
				GameObject go2 = Instantiate(Bomb,spoint[1].transform.position,spoint[1].transform.rotation)as GameObject;
				go2.rigidbody.velocity = new Vector3(Random.Range(-5,30),Random.Range(-5,-50),0);
			}
			
			bombTime = 0;
		}
		
		rotX+= Time.deltaTime * speed;
		 
		transform.rotation = Quaternion.Euler(0,rotX,0);
		
	}
	
	
}
