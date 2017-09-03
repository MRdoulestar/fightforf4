#pragma strict
var mySkin : GUISkin;
function Start () {

}

function Update () {

}
function OnGUI(){
	//GUI.skin = mySkin;
	GUI.skin.label.fontSize = 30;	//设置字体大小
	GUI.Label(new Rect(Screen.width*0.05,Screen.height*0.05,Screen.width*0.4,Screen.height*0.2),"生命上限：  "+GameObject.Find("Player").GetComponent(PlayerDamageNew).maxHitPoints);	//屏幕显示生命上限
	GUI.Label(new Rect(Screen.width*0.05,Screen.height*0.2,Screen.width*0.4,Screen.height*0.1),"生命值:  "+GameObject.Find("Player").GetComponent(PlayerDamageNew).hitPoints);	//屏幕显示生命值

}