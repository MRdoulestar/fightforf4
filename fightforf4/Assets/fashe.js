var music:AudioClip;
var music_no:AudioClip;
var music_change:AudioClip;
var aim:Transform;  
//克隆子弹  
var prefab:GameObject;
private var ball:GameObject;  
//绘制准星的材质  
var material:Material;  
var danyao=30;	//弹夹内弹药数
var sum_danyao=90;	//弹药总数
var fire:Texture2D;
// #region IEnumerable
// public System.Collections.IEnumerator Test(){
// yield return new WaitForSeconds(2);//等待5秒
// }
// #endregion
function Start () {  
  
}  
  
function Update () {  

}  
function OnGUI(){

  
//Input.mousePosition
//定义一个方向，为发射点y轴方向  
//var dir=aim.transform.TransformDirection(Vector3.up);  
  
//按下鼠标左键  
//Input.GetMouseButtonDown(0)
GUI.Label(new Rect(Screen.width*0.8,Screen.height*0.6,Screen.width*0.2,Screen.height*0.1),"弹药:  "+danyao+"/"+sum_danyao);
//if(GUI.Button(new Rect(Screen.width*0.8,Screen.height*0.7,Screen.width*0.2,Screen.height*0.2),fire)){  
	
}
function Fashe(){
	var zj=Vector3(Screen.width/2,Screen.height/2,0);  
	var ray:Ray=Camera.main.ScreenPointToRay(zj);
	var dir=ray.direction;
	if(danyao>0){
		//实列化一个球，发射点的位置，  
		AudioSource.PlayClipAtPoint(music,transform.position);
		// GameObject.Find("AK47").GetComponent.<Transform>().rotation = Quaternion.Euler(-4, 0, 0);
		ball=Instantiate(prefab,aim.position*1,Quaternion.identity);  
		//在某一个方向加一个力  
		ball.GetComponent.<Rigidbody>().AddForce(dir.normalized*7600);  
		//一秒后删除小球  
		Destroy(ball.gameObject,1.5); 
		// GameObject.Find("AK47").GetComponent.<Transform>().rotation = Quaternion.Euler(0, 0, 0);
		danyao--;	//弹药减少
	}else{
		if(sum_danyao>0){	//如果总弹药还有
			AudioSource.PlayClipAtPoint(music_change,transform.position);	//调用切换弹药音效
			//if(Time.frameCount % 5 == 0) {
			 //StartCoroutine(Test());
			sum_danyao-=30;	//总弹药减少
			danyao+=30;	//目前弹药增加
			//}
			}else{
				AudioSource.PlayClipAtPoint(music_no,transform.position);	//调用无子弹音效
			}
		}
	}  
