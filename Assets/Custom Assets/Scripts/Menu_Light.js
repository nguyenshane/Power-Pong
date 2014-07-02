﻿#pragma strict

function Start () {

}

var speed : float = 4.0; //how fast the object should rotate
var activate = true;

 function Update(){
 if (activate){
      transform.Rotate(
      Vector3(0, Input.GetAxis("Mouse X"), 0)  * speed);
      //Debug.Log(transform.localRotation.y);
      var y = transform.localRotation.y;
      if(y<-0.3) transform.localRotation.y = -0.3;
      if(y>0.3) transform.localRotation.y = 0.3;
      if(Input.GetMouseButtonDown(0)){
      	if(y>-0.3 && y<-0.18){
			Debug.Log("Pressed Play");
			Application.LoadLevel("Level1");
	 	}else if(y>-0.09 && y<0.09){
	 		var linkToScript = GameObject.Find("Camera").GetComponent(Menu_Camera);
	 		linkToScript.ToOptions();
	 		var linkToScript2 = GameObject.Find("Options Menu Light").GetComponent(Options_Light);
	 		linkToScript2.activate = true;
	 		activate = false;
			Debug.Log("Pressed Options");
		} else if(y>0.19 && y<0.3){
			Debug.Log("Pressed Credits");
		} else Debug.Log("Outside");
	}
 }
 }