var material:Material;
//绘制准星  
function OnPostRender(){  
DrawRecent(Screen.width/2,Screen.height/2,10,10);  
}  
//绘制四边形的方法  
function DrawRecent(x:float,y:float,width:float,height:float){  
//材质通道设置为默认的0  
 material.SetPass(0);  
 //绘制2D图形  
  GL.LoadOrtho();  
 //绘制长方体  
 GL.Begin(GL.QUADS);  
 //传入四个点的相对屏幕的坐标，先后分别是左上角，左下角，右下角，右上角  
  GL.Vertex(new Vector3(x/Screen.width,y/Screen.height,0));  
  GL.Vertex(new Vector3(x/Screen.width,(y+height)/Screen.height,0));  
  GL.Vertex(new Vector3((x+width)/Screen.width,(y+height)/Screen.height,0));  
  GL.Vertex(new Vector3((x+width)/Screen.width,y/Screen.height,0));  
  //结束绘画  
  GL.End();  
}  