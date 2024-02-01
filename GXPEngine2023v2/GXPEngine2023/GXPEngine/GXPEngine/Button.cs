using System;
using GXPEngine;                                
using TiledMapParser;

public class Button : Sprite 
{
	String button_name;
	String button_text;
	String button_type;

	public Button(TiledObject obj=null) : base("button.png")
	{
        //Initialize(obj);
        Console.WriteLine(obj.GetStringProperty("name"));
    }
	{
	}
}
