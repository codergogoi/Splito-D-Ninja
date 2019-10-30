using UnityEngine;
using System.Collections;

public class _DimondCollect : MonoBehaviour {
	
	
	private  Vector3 OldPos;
	private  Vector3 FinalPos;
	private float time;
	private float c;
	private float TempRotation;
	public bool isTrue;
	public GameObject JemsPlan;
	private float autodestroy;
	
	
	void Start () {
		
		JemsPlan = GameObject.Find("GoldBox");
		
		time=0;

		
		OldPos=transform.position;
		

	}
	
	void Update () {
		
		if(isTrue){
			
			FinalPos = JemsPlan.transform.position;
			autodestroy += Time.deltaTime;
						
		}
		
		if(autodestroy > 0.5f){
			
			Destroy(gameObject);
		}
	
	}
	
		void FixedUpdate()
		{
			
				if(Input.GetMouseButtonDown(0)){
					
					//isTrue = true;
				
				}
					
			
				if(isTrue)
				{
				
					c = 0.02f;
							
					if(transform.localScale.x<0.4f)
					transform.localScale+= new Vector3(Time.deltaTime*c,Time.deltaTime*c,Time.deltaTime*c);
					
					if(transform.eulerAngles.y<=360){
						TempRotation = transform.eulerAngles.y;
						TempRotation +=(Time.deltaTime*170);
						}
					
						transform.eulerAngles = new Vector3(transform.eulerAngles.x, TempRotation, transform.eulerAngles.z);
						
						transform.position=Vector3.Lerp(OldPos,FinalPos,time);
				
				time+=Time.deltaTime*2.5f;
			
			   }
	
	
	}
	
	
}
