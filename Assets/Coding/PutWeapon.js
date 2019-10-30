
var support : GameObject;



static var menu:boolean=false;
private var X:int=0;
private var Y:int=0;
private var PlaceWeapon:boolean=false;




function Update () 
{
	
		var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		var hit : RaycastHit;
		
		/*
		
		  if(Physics.Raycast (ray, hit, 500.0) && Input.GetKeyDown("mouse 0")) 
		   {
			 Debug.DrawLine (ray.origin, hit.point);

				
			//	print(hit.collider.name);
				
			
			
				
		   } 
		  */
		  
		  
		  if( Physics.Raycast (ray, hit, 5000.0) && Input.GetKeyDown("mouse 0") && hit.collider.name=="Ground")
			 
			{
				Debug.DrawLine (ray.origin, hit.point);
				
				X= Input.mousePosition.x;
				Y= Screen.height - Input.mousePosition.y;
				menu=true;	
			
			}
			
			
			
			if(Physics.Raycast (ray, hit, 5000.0) && hit.collider.name=="Ground" && Input.GetKeyDown("mouse 0")){
			
				var sp : GameObject = Instantiate(support, Vector3(hit.point.x, hit.point.y-0.06, hit.point.z), Quaternion.identity);

			}
			/*
			
				
			if(Physics.Raycast (ray, hit, 100.0) && hit.collider.name=="Ground")
			{
				var w1:GameObject= Instantiate(support,Vector3(hit.point.x,hit.point.y-0.06,hit.point.z),Quaternion.identity);
				
			}
			*/
			
			
			
}


