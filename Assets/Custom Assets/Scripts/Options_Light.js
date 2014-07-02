#pragma strict

function Start () {

}

var activate = false;
var speed : float = 1.0; //how fast the object should rotate

 function Update(){
 if (activate){
      transform.Rotate(Vector3(-Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X"), 0)  * speed);
      Debug.Log("x= " + transform.localRotation.y + " y= "+ transform.localRotation.x);
      var y = transform.localRotation.x;
      var x = transform.localRotation.y;
      transform.localRotation.z = 0;
      if(x<-0.2) transform.localRotation.y = -0.2;
      if(x>0.2) transform.localRotation.y = 0.2;
      if(y<0.65) transform.localRotation.x = 0.65;
      if(y>0.748) transform.localRotation.x = 0.748;
      
      if(Input.GetMouseButtonDown(0)){
      	if(x>0.11 && y>0.716){
      		// Audio Low
			Debug.Log("Pressed Audio Low");
			
	 	}else if(x<0.045 && x>-0.065 && y>0.716){
	 		// Audio Medium
	 		//var linkToScript = GameObject.Find("Camera").GetComponent(Menu_Camera);
	 		//linkToScript.ToOptions();
			Debug.Log("Pressed Audio Medium");
		}else if(x<-0.013 && y>0.716){
      		// Audio High
			Debug.Log("Pressed Audio High");
		}else if(x>0.103 && y>0.67 && y<0.7){
      		// Brightness Low
			Debug.Log("Pressed Brightness Dark");
		}else if(x<0.05 && x>-0.055 && y<0.716 && y>0.698){
      		// Brightness Medium
			Debug.Log("Pressed Brightness Medium");
		}else if(y>0.19 && y<0.3){
			Debug.Log("Pressed Credits");
		} else Debug.Log("Outside options");
	}
  }
}