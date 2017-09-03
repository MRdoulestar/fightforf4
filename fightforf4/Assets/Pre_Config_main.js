#pragma strict
//初始化配置数据
var hptotal : int;
var hpleft : int;
function Start () {
	if(PlayerPrefs.HasKey ("hptotal")){
	}else{
		PlayerPrefs.SetInt("hptotal",100);
		PlayerPrefs.SetInt("hpleft",100);
	}
}

function Update () {

}