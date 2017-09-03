
@script ExecuteInEditMode()

var maxHitPoints : int;	//最大生命值
var hitPoints : int;	//目前生命值
var painSound : AudioClip;	//设置角色受伤音效
var die : AudioClip;	//设置角色死亡音效
var deadReplacement : Transform;
var mySkin : GUISkin;	//获得skin管理器
var explShake : GameObject;
private var radar : GameObject;
var damageTexture : Texture;
private var time : float = 0.0;
private var alpha : float;
private var callFunction : boolean = false;

function Start(){
	//使受到的伤害为最大伤害
	maxHitPoints = PlayerPrefs.GetInt("hptotal");
	hitPoints = maxHitPoints;
	alpha = 0;
}

function Update(){
    if (time > 0){ 
        time -= Time.deltaTime;
    }
    alpha = time;
}

function PlayerDamage (damage : int) {
	if (hitPoints < 0.0)
		return;

		// 应用伤害
		hitPoints -= damage;
		GetComponent.<AudioSource>().PlayOneShot(painSound, 1.0 / GetComponent.<AudioSource>().volume);
		time = 2.0;		
	

	// 判断死亡
	if (hitPoints <= 0.0){
		hitPoints=0.0;
		Die();
		}
}

//捡起医疗包
function Medic (medic : int){
	
	hitPoints += medic;
	
	if(hitPoints > maxHitPoints)
	hitPoints = maxHitPoints;
}

function Die () {
	if(callFunction)
	return;
	callFunction = true;
	
	if (die && deadReplacement)
		AudioSource.PlayClipAtPoint(die, transform.position);

	// 取消所有脚本的控制行为
	var coms : Component[] = GetComponentsInChildren(MonoBehaviour);
	for (var b in coms) {
		var p : MonoBehaviour = b as MonoBehaviour;
		if (p)
			p.enabled = false;
	}
	// 取消所有renderers
	var gos = GetComponentsInChildren(Renderer);
	for( var go : Renderer in gos){
		go.enabled = false;

    }
	if(radar != null){
		radar = gameObject.FindWithTag("Radar");
		radar.gameObject.SetActive(false);
	}
	Instantiate(deadReplacement, transform.position, transform.rotation);
}


function OnGUI () {
    GUI.skin = mySkin;	//调用skin
	GUI.color = Color(1.0, 1.0, 1.0, alpha); //颜色(r,g,b,a)
	GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), damageTexture);	//屏幕绘制受伤界面
}

function Exploasion(){
	explShake.GetComponent.<Animation>().Play("exploasion");
}