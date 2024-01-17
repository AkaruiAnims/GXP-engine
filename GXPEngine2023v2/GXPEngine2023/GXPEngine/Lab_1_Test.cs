using System;                                    
using GXPEngine;                                
using System.Drawing;
using TiledMapParser;

public class Lab_1_Test : Game {


	public Lab_1_Test() : base(640, 640, false)    
	{
		TiledLoader tiledLoader = new TiledLoader("map1.tmx");
		tiledLoader.autoInstance = true;
		tiledLoader.rootObject = this;
		//tiledLoader.addColliders = false;
		//tiledLoader.LoadImageLayers( 0 );
		tiledLoader.addColliders = true;
		tiledLoader.LoadObjectGroups( 0 );
		tiledLoader.addColliders = true;
		tiledLoader.LoadTileLayers( 0 );
	}

	
	void Update() {
	}

	static void Main()                          
	{
		new Lab_1_Test().Start();    
	}
}