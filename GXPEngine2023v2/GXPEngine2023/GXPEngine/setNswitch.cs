using System;                                    
using GXPEngine;                                
using System.Drawing;
using TiledMapParser;

// tiled mandatory - or something similar to edit matrix without code
// constructor or changing values in tiled?
// code reviews foor better grade 1 teacher & 2 peers 
// get children added from tiled
// save code without needing to rebuild exe
public class setNswitch : Game {
	Player player1;

	public setNswitch() : base(600, 600, false)    
	{
		TiledLoader tiledLoader = new TiledLoader("map1.tmx");
		tiledLoader.autoInstance = true;
		tiledLoader.rootObject = this;
		tiledLoader.addColliders = false;
		tiledLoader.LoadImageLayers(0);
		tiledLoader.addColliders = true;
		tiledLoader.LoadTileLayers( 0 );
		tiledLoader.addColliders = true;
		tiledLoader.LoadObjectGroups( 0 );
		tiledLoader.addColliders = true;
		tiledLoader.LoadTileLayers( 1 );
		
		player1 = FindObjectOfType<Player>();
		Camera cam1 = new Camera(0, 0, width/2, height/2, true);
		player1.AddChild(cam1);
	}


	void Update() {
	}

	static void Main()                          
	{
		new setNswitch().Start();    
	}
}