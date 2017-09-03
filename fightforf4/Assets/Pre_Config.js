#pragma strict
//初始化配置数据
var zombie : GameObject[];
var zombienum : int;
var hptotal : int;
var hpleft : int;
function Start () {
	zombie = GameObject.FindGameObjectsWithTag("Enemy");
	zombienum = zombie.length/2;
	PlayerPrefs.SetInt("zombies_left_amount",zombienum);
	PlayerPrefs.SetInt("zombies_total_amount",zombienum);
	if(PlayerPrefs.HasKey ("hptotal")){
		hptotal = PlayerPrefs.GetInt("hptotal");
		//PlayerPrefs.SetInt("gas_amount",100000);
		//PlayerPrefs.SetInt("metal_amount",100000);
		//PlayerPrefs.SetInt("crystal_amount",10000);
	}else{
		PlayerPrefs.SetInt("hptotal",100);
		PlayerPrefs.SetInt("hpleft",100);
	}
}

function Update () {

}