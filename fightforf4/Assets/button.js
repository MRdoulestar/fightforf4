function OnGUI()
{
    if(GUI.Button(Rect(100,206,100,50),"↑"))
    {
        print("前进!!");
    }
    if(GUI.Button(Rect(100,256,100,51),"↓"))
    {
        print("后退");
    }
}