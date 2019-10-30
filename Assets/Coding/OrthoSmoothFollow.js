
// The target we are following
var target : Transform;
// The distance in the x-z plane to the target
var distance:float = 10.0;
// the height we want the camera to be above the target
var height:float = 5.0;
// How much we 
var heightDamping:float = 2.0;
var rotationDamping:float = 0.0;
var isClear: boolean  = false;
var isForward : boolean = false;
var timeB: float;
var valB:float;
var isSetB: boolean;

var timeF : float;
var valF: float;
var isSetF: boolean;
var currentHeight:float = 4.5;
var charfollow : float;


//------------------


function Lcomp( x : int){


	isClear = true;


}

function SetHeight(h : float){

	currentHeight = h;
}


function Fdirection(x: int){


	if(x > 1){ 
	
		if(!isForward){
	
			timeF = 0;
			isForward = true;	
			isSetF = true;
		}
	}
	
	else{
		if(isForward){
			timeB = 0;
			 isForward = false;
			isSetB = true;
		}
	}
}







function Start(){

		
	StartFollow();

}


function StartFollow(){

	yield WaitForSeconds (2);
	isClear = true;
}


function LateUpdate () {

	
	


	if(isClear){

		// Early out if we don't have a target
		if (!target)
			return;
		
		// Calculate the current rotation angles
		var wantedRotationAngle:float = target.eulerAngles.y;
		var wantedHeight:float = target.position.y - height;
			
		var currentRotationAngle:float = transform.eulerAngles.y;
		
		
		if(isForward){
			
				//Mathf.Lerp(minimum, maximum, Time.time)
				
			//	valF = Mathf.Lerp(0, -3,Time.deltaTime * 50);
			if(isSetF)
			timeF =  timeF + Time.deltaTime *10;
			
			
			if(timeF > 2.9){
				
				isSetF = false;
			
			}
			
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle - timeF, wantedRotationAngle, rotationDamping * Time.deltaTime);
				
			
			}
		else{
		
			
			if(isSetB)
			timeB =  timeB + Time.deltaTime *10;
			
			
			if(timeB > 2.9){
				
				isSetB = false;
			
			}
		
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle + timeB, wantedRotationAngle, rotationDamping * Time.deltaTime);
			// Damp the height
			}
			
		//Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
	
		// Convert the angle into a rotation
		 var currentRotation:Quaternion = Quaternion.Euler (0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		transform.position.x = target.position.x + charfollow;
	
		// Set the height of the camera
		//		transform.position.y = target.transform.position.y;//currentHeight;

		transform.position.y = currentHeight;
		
		// Always look at the target
		//transform.LookAt (target);
	}
}