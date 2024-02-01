using System;                                    
using GXPEngine;                                
using System.Drawing;
using TiledMapParser;
using System.Runtime.Remoting.Activation;
using System.Collections.Generic;

// tiled mandatory - or something similar to edit matrix without code
// constructor or changing values in tiled?
// code reviews foor better grade 1 teacher & 2 peers 
// get children added from tiled
// save code without needing to rebuild exe
public class setNswitch : Game {

    Level level = new Level();

	public void LoadLevel ()
	{
        // destroy all children
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.Destroy(); 
        }

        // load level
        TiledLoader tiledLoader = new TiledLoader( level.LevelName );
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
    }   


	public setNswitch() : base(600, 600, false)    
	{
        LoadLevel(); 
	}

	void Update() 
	{
		
	}

	static void Main()                          
	{
		new setNswitch().Start();    
	}
}