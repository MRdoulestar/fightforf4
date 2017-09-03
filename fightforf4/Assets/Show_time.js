#pragma strict
var timeLeft:String;
static var FightLeftTime:int = 120;
var Win_flag:int;
function Start () {
	 InvokeRepeating("CountDown", 0, 1);
	 FightLeftTime = GameObject.Find("Start_end").GetComponent(Func_GUIWindow_after_battle).total_timer;
	 //print(FightLeftTime);
}

function Update () {
	
}
function OnGUI(){
 	Win_flag = GameObject.Find("Start_end").GetComponent(Func_GUIWindow_after_battle).win_or_lose;	//判断是否已经胜利
 	if(FightLeftTime == 0 || Win_flag==1 || Win_flag==0){
 		 CancelInvoke("CountDown");
 	}
 	GUI.Label (Rect (Screen.width*0.9, Screen.height*0.1, 200, 300), timeLeft);
}
 /*
 *倒计时函数
 */
function CountDown()	
{
	FightLeftTime -= 1;
    timeLeft = ((FightLeftTime / 60) % 60).ToString() + "分"  
             + (FightLeftTime % 60).ToString() + "秒";
 
}
