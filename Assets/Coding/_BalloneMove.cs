using UnityEngine;
using System.Collections;

public class _BalloneMove : _BaseClass {
	
	private float moveSpeed;
	
	public GameObject BlastParticle;
	private bool isBlast;
	public GameObject BalloneTop;
	private float RotSpeed;
	
	public PlayerControl pc;   
	
	
	
	// Use this for initialization
	void Start () {
		
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		moveSpeed = Random.Range(0.5f,4.0f);
		
		Destroy(gameObject,17.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		
		RotSpeed+= Time.deltaTime * 50;
		 
		BalloneTop.transform.rotation = Quaternion.Euler(0,RotSpeed,0);
	}
	
	
	void OnTriggerEnter(Collider coll){
		
		if(coll.collider.tag=="surican"){
		
			if(!isBlast){
				CurrentGameScore+= Random.Range(10,100);
				GameObject go = Instantiate(BlastParticle,transform.position,transform.rotation) as GameObject;
				isBlast = true;
				Destroy(gameObject,0.1f);
			}
		}
		
		
		if(coll.collider.tag=="lifepot"){
			
			pc.DestroyMe();
			
		}
	}
}
