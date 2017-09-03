using UnityEngine;  
using System.Collections;  
public class touchmove : MonoBehaviour {  
    private CharacterController controller; 
	private Vector3 Direction;
    void Start () {  
      
        controller = GetComponent<CharacterController>();  
    
    } 
  
    //当摇杆可用时注册事件  
    void OnEnable()  
    {  
        EasyJoystick.On_JoystickMove += OnJoystickMove;  
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;  
    }  
  
    //当摇杆不可用时移除事件  
    void OnDisable()  
    {  
        EasyJoystick.On_JoystickMove -= OnJoystickMove;  
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;  
    }  
  
    //当摇杆销毁时移除事件  
    void OnDestroy()  
    {  
        EasyJoystick.On_JoystickMove -= OnJoystickMove;  
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;  
    }  
  
    //当摇杆处于停止状态时，角色进入待机状态  
    void OnJoystickMoveEnd(MovingJoystick move)  
    {  
        if (move.joystickName == "EasyJoystick")  
        {  
            //GetComponent<Animation>().CrossFade("idle");  
			//GetComponent<Animation>().CrossFade("idle"); 
        }  
    }  
	void Jump(){
		//this.GetComponent<Rigidbody>().AddForce(Vector3.up * 300F);

		controller.Move(Vector3.up * 2);

	}
    //当摇杆处于移动状态时，角色开始奔跑  
    void OnJoystickMove(MovingJoystick move)  
    {  
        if (move.joystickName != "EasyJoystick")  
        {  
            return;  
        }  
        //获取摇杆偏移量  
        float joyPositionX = move.joystickAxis.x;  
        float joyPositionY = move.joystickAxis.y;  
        if (joyPositionY != 0 || joyPositionX != 0)  
        {  
			//print(joyPositionY);	//调试摇杆值
			//print(joyPositionX);
            //设置角色的朝向（朝向当前坐标+摇杆偏移量）  
			//transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY)); 
			//Direction = new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY);

           
			//print (Direction.right);
			//print (Vector3.forward);
			//transform.Translate(way.right * Time.deltaTime * 5F);
            //float rx = GameObject.Find ("Player").GetComponent<Transform> ().localEulerAngles.x;  
            float ry = GameObject.Find ("Player").GetComponent<Transform> ().localEulerAngles.y;  //获取当前角色的y方向
            float rz = GameObject.Find ("Player").GetComponent<Transform> ().localEulerAngles.z;  //获取当前角色的z方向
			this.GetComponent<Transform>().rotation=Quaternion.Euler(0, ry, rz);	//设置当前视角方向水平
             //移动玩家的位置（按朝向位置移动）  
            transform.Translate(Vector3.forward * Time.deltaTime * joyPositionY*7.5F); 	//不稳定
            transform.Translate(Vector3.right * Time.deltaTime * joyPositionX*5F); 
			//controller.Move(Vector3.forward * (Time.deltaTime * joyPositionY*7.5F));  
			//controller.Move(Vector3.right * (Time.deltaTime * joyPositionX*5F));  
            //播放奔跑动画  
            //GetComponent<Animation>().CrossFade("Run");  
        }  
    }  
} 