using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


public Transform target ; //目标物体
public LayerMask mask;//layer层           //只检测在mask 包含的层里的碰撞体是否会遮挡视线
 
public float targetHeight = 2.0f; //实际聚焦点位置处于目标坐标上方的高度值          //不宜过高,否则会影响视线检测的位置
public float distance = 5.0f;// 摄像机距离实际聚焦点的距离
 
public float maxDistance = 20; //摄像机距离实际聚焦点的最大距离
public float minDistance = 2.5f; //摄像机距离实际聚焦点的最小距离
 
public float xSpeed = 250.0f; //横向移动速度(eulerAngles.y)
public float ySpeed = 120.0f; //纵向移动速度(eulerAngles.x)
 
public float yMinLimit = -20; //摄像机仰角(eulerAngles.x)最小值
public float yMaxLimit = 80; //摄像机仰角(eulerAngles.x)最大值
 
public float zoomRate = 20; //推拉摄像机的速度
 
public float rotationDampening = 2.0f; //摄像机移动阻尼              //数值越小摄像机停止的速度越慢, 数值越高停止的速度越快
 
private float x = 0.0f; //水平旋转角度
private float y = 0.0f; //仰角旋转角度
 
private float xDampMove=0;//水平旋转阻尼速度
private float yDampMove=0;//仰角旋转阻尼速度
 
private float targetDistance=0;
 
 
void Awake () {
    Vector3 angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;
 
       // Make the rigid body not change rotation
       //防止刚体影响物体旋转
       if (GetComponent<Rigidbody>())
              GetComponent<Rigidbody>().freezeRotation = true;
             
       targetDistance=distance;
}
 
//摄像机位移应该在所有其他物体计算之后处理            //LateUpdate 晚于 Update
//防止摄像机移动后有其他物体移动道遮挡的位置, 或者与目标物体位移不同步
void LateUpdate () {
   if(!target)
      return;
      
       // If either mouse buttons are down, let them govern camera position
       //鼠标点击移动摄像机
       if(Input.GetMouseButton(2) || Input.GetMouseButton(1)){
              xDampMove=Input.GetAxis("Mouse X") * xSpeed;
              yDampMove=Input.GetAxis("Mouse Y") * ySpeed;
       } 
      
       // move cam using arrow keys
       //使用键盘移动摄像机
       //~xDampMove-=(xDampMove<xSpeed/2f)?(Input.GetAxis("Horizontal")*xSpeed*0.25f):0;
       //~ yDampMove-=(xDampMove<xSpeed/2f)?(Input.GetAxis("Vertical")*ySpeed*0.25f):0;
      
       //clamp speed
       //限制移动速度最大值
       xDampMove=Mathf.Clamp(xDampMove,-xSpeed,xSpeed);
       yDampMove=Mathf.Clamp(yDampMove,-ySpeed,ySpeed);
      
       //apply
       //施加摄像机移动
       x+=xDampMove*Time.deltaTime;
       y-=yDampMove*Time.deltaTime;
      
       //distance change
       //更改摄像机与目标之间的距离
       if(Input.GetKey(KeyCode.Q))
              distance-=zoomRate*0.25f*Time.deltaTime;
      
       if(Input.GetKey(KeyCode.E))
              distance+=zoomRate*0.25f*Time.deltaTime;
      
       distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
       distance = Mathf.Clamp(distance, minDistance, maxDistance);
   
       //缩放施加阻尼
       targetDistance=Mathf.Lerp(targetDistance,distance,2*Time.deltaTime);
      
       //限制仰角
       y = ClampAngle(y, yMinLimit, yMaxLimit);
   
       //calcu
       //计算摄像机的角度和方向
       Quaternion rotation = Quaternion.Euler(y, x, 0);
       Vector3 position= rotation *Vector3.forward * -targetDistance + target.position+new Vector3(0,targetHeight,0);
   
       //slowDown
       //对摄像机的移动施加阻尼
       xDampMove=Mathf.Lerp(xDampMove,0,rotationDampening*Time.deltaTime);
       yDampMove=Mathf.Lerp(yDampMove,0,rotationDampening*Time.deltaTime);
 
      
       //checkLineOfSign and Collision
       //检测是否有碰撞体遮挡视线
       //如果有则移动摄像机的位置到障碍物前面
       position=SignUpdate(target.position+Vector3.up*targetHeight,position,0.3f, distance,0.6f,mask);
      
       //change distance if want
       //更改摄像机位置的同时更改距离    如果需要
       //开启时摄像机离开障碍物遮挡后不会突然跳跃
       //
       targetDistance=Vector3.Distance(position,target.position+Vector3.up*targetHeight);
       //
      
      
       //Apply
       //施加摄像机位移和旋转
       transform.rotation=rotation;
       transform.position=position;
      
}
 
//限制角度
static float ClampAngle (float angle,float min,float max ) {
   if (angle < -360)
      angle += 360;
   if (angle > 360)
      angle -= 360;
   return Mathf.Clamp (angle, min, max);
}
 
//检测是否有碰撞体遮挡在 targetPoint 和 selfPosition 之间
//targetPoint                         目标位置
//selfPosition                 自身位置
//checkRadios                      球星检测区域半径
//maxDis                             最大检测距离
//stepDis                              检测倒碰撞后向前偏移的位置,  建议大于检测半径*2
//s_mask                             碰撞检测遮罩
 Vector3 SignUpdate(Vector3 targetPoint,Vector3 selfPosition,float checkRadios,float maxDis,float stepDis,LayerMask s_mask){
       Ray ray=new Ray(targetPoint,selfPosition-targetPoint);
       RaycastHit hit=new RaycastHit();
      
       if(Physics.SphereCast(ray,checkRadios,out hit,maxDis,s_mask)){
             
              return ray.GetPoint(hit.distance-stepDis);
       }
      
       //无碰撞返回原始位置
       return selfPosition;
}
}
