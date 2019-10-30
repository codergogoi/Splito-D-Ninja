using UnityEngine;
using System.Collections;

public class _SwipeControl : MonoBehaviour {

		Vector2 deltaPosition;
        Vector2 afterDeltaPosition;
        float angle;
		public float speed;
	
		public _triggerEnabler trigger;
		

        void FixedUpdate()
        {
		
			if(Input.GetKeyDown(KeyCode.S)){
			
				trigger.StepDown();
			}
		
			if(Input.GetKeyDown(KeyCode.Space)){
			
				SendMessage("JumpAction", 2);
				StartCoroutine(WaitForJumpStop(0.7f));
			}
			
		
            if(Input.touchCount > 0 &&  Input.touches[0].phase == TouchPhase.Moved)
            { 
                //its always x=-1 and y=-1 if touchCount == 0 Resets
                if(deltaPosition.x == -1 && deltaPosition.y == -1)
                    deltaPosition = Input.GetTouch(0).position; //First touch  point stored
                afterDeltaPosition = Input.GetTouch(0).position;//the swiping points
                angle = Mathf.Atan2(afterDeltaPosition.y-deltaPosition.y,afterDeltaPosition.x -deltaPosition.x)* 180/Mathf.PI ; // angle in degrees from 0,-180 and 0,180)
                //Debug.Log("Angle "+ angle);
                
				if(angle < 45f && angle > -45f)
                {
				
              		//SendMessage("JumpAction", 2);
			 		//right
				
		        }
		        else if(angle < 135f && angle > 45f)
		        {
		           
						SendMessage("JumpAction", 2);
						//Log.text ="up";
		               
		        }
		        else if(angle > 135f || angle < -135f)
		        {
						// left
						//SendMessage("JumpAction", 2);
						
						
		        }
		        else if(angle > -135f && angle < -45f)
		        {
					trigger.StepDown();
		            //down
					
		        }
			
    }
    else if( Input.touchCount == 0)
    {
        if(deltaPosition.x != -1 && deltaPosition.y != -1)
        {
            deltaPosition.x=-1;
            deltaPosition.y=-1;
        }
	}
		
	}
	
	
	void Update(){
		
		 
		
		
	}
	
	
	IEnumerator WaitForJumpStop(float tm){
		
		yield return new WaitForSeconds(tm);
		
		SendMessage("JumpAction", 1);
		
	}
	
	
	
	
	
}