using System;                                    
using GXPEngine;                                
using System.Drawing;                          

public class Lab_1_Test : Game {
	public Lab_1_Test() : base(800, 600, false)    
	{
	Sprite sprite = new Sprite("colors.png");
	Player player = new Player();

	AddChild(player);
	AddChild(sprite);

	}

	
	void Update() {
	}

	static void Main()                          
	{
		new Lab_1_Test().Start();             
	}
}