using UnityEngine;
using System.Collections;
public class shoot : MonoBehaviour {
	#region 1 - 变量
	public AudioClip hurt;
	   /// <summary>
	   /// 总生命值
	   /// </summary>
	   public int hp = 1;

	   /// <summary>
	   /// 敌人标识
	   /// </summary>
	   public bool isEnemy = true;

	   #endregion

	   /// <summary>
	   /// 对敌人造成伤害并检查对象是否应该被销毁
	   /// </summary>
	   /// <param name="damageCount"></param>
	   public void Damage(int damageCount)
	   {
		   AudioSource.PlayClipAtPoint(hurt,transform.position);
	       hp -= damageCount;
	       if (hp <= 0)
	       {
				//gameObject.GetComponent<AI>().chaseRange = 0;
				//Instantiate(dead,GameObject.Find("Zombie2").transform,Quaternion.identity);
				Destroy(gameObject); // 死亡! 销毁对象!
				int zombies_left_amount = PlayerPrefs.GetInt("zombies_left_amount");
				zombies_left_amount--;
				PlayerPrefs.SetInt("zombies_left_amount",zombies_left_amount);
				//GameObject.Find ("Player").GetComponent<Func_GUIWindow_after_battle>().zombies_left_amount--;
				
	       }
	   }

	   void OnTriggerEnter(Collider otherCollider)
	   {
	       ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
	       if (shot != null)
	       {
	           // 判断子弹归属,避免误伤
	           if (shot.isEnemyShot != isEnemy)
	           {
	               Damage(shot.damage);

	               // 销毁子弹
	               Destroy(shot.gameObject); 
	           }
	       }
	   }
}
