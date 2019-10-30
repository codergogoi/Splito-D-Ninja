    var flyingSpeed = 500;
    var minThrust = 20;
    var maxThrust = 300;
    var Accel = maxThrust / 4;
    //var Jumpspeed = maxThrust *5;
    var turnSpeed = 100;
     
     
    function Update() {
     
     
        if(Input.GetButton("Jump")){  
        flyingSpeed = flyingSpeed+maxThrust;
        if(flyingSpeed>2000)
        {
        flyingSpeed= flyingSpeed-500;
        }
        }
        if(!Input.GetButton("Jump"))
        {
        flyingSpeed = Accel + Mathf.Clamp(flyingSpeed, minThrust, maxThrust + Accel);
        }
     
        //Quando for necessario habilitar o Q para reduzir a velocidade
        /*if (Input.GetButton("Q")){
        flyingSpeed = Accel + Mathf.Clamp(flyingSpeed--, minThrust -Accel, maxThrust);
        //flyingSpeed = flyingSpeed - maxThrust;
        }
        /*if(!Input.GetButton("Q"))
        }
        flyingSpeed=500;
        }
        */
        if(("Jump"))
        {
       rigidbody.velocity = transform.forward * Time.deltaTime * flyingSpeed; //Apply velocity in Update()
        }
     
       
       if(Input.GetAxis("Mouse X") > 0.0){ //if the right arrow is pressed
          transform.Rotate(0.0, turnSpeed * Time.deltaTime, 0.0 * Time.deltaTime, Space.World); //and then turn the plane
       }
       if(Input.GetAxis("Mouse X") < 0.0){ //if the left arrow is pressed
          transform.Rotate(0.0, -turnSpeed * Time.deltaTime, 0.0 * Time.deltaTime, Space.World); //The X-rotation turns the plane - the Z-rotation tilts it
       }
       if(Input.GetAxis("Mouse Y") > 0.0){ //if the up arrow is pressed
          transform.Rotate(-20.0 * Time.deltaTime, 0.0, 0.0);
       }
       
       if(Input.GetAxis("Mouse Y") < 0.0){ //if the down arrow is pressed
          transform.Rotate(20.0 * Time.deltaTime, 0.0, 0.0);
         }
     
     
    }