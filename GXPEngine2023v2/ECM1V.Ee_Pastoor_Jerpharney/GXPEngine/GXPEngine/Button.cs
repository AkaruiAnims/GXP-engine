using System;
using GXPEngine;                                
using TiledMapParser;

public class Button : Sprite 
{
	public String button_text;
	public String button_type;
    public String[] button_types = { "next_level", "restart_level", "main_menu" };

	public Button(TiledObject obj=null) : base("assets/UI/coll_trans.png")
	{
        //Initialize(obj);
        button_type = obj.GetStringProperty("button_type");
        button_text = obj.GetStringProperty("button_text");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (HitTestPoint(Input.mouseX, Input.mouseY))
            {
                RunButtonMethod();
            }
        }
    }   
    
    public void RunButtonMethod ()
    {
        switch ( button_type )
            {
                case "next_level":
                    //Console.WriteLine("Button: next level");
                    this.SetNextLevel();
                    break;
                case "restart_level":
                    //Console.WriteLine("Button: restart level");
                    this.SetNextLevel();
                    break;
                case "main_menu":
                    //Console.WriteLine("Button: main menu");
                    this.SetNextLevel();
                    break;
                default:
                    //Console.WriteLine("Button: no function set");
                    break;
            }
    }

	public void SetNextLevel()
	{
        parent.FindObjectOfType<Level>().SetNextLevel(button_text);
    }
}
