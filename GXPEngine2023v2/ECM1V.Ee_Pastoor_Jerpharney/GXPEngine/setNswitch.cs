using System;                                    
using GXPEngine;                                
using System.Drawing;
using TiledMapParser;
using System.Runtime.Remoting.Activation;
using System.Collections.Generic;

public class setNswitch : Game {

    Level level = new Level();
    Sound sound;

	public void LoadLevel ()
	{
        // destroy all children
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {   
            if ( child != level) child.Destroy();
        }

        // load level
        TiledLoader tiledLoader = new TiledLoader( level.LevelName );
        tiledLoader.autoInstance = true;
        tiledLoader.rootObject = this;
        tiledLoader.addColliders = false;
        tiledLoader.LoadImageLayers(0);     // background
        tiledLoader.addColliders = true;
        tiledLoader.LoadTileLayers( 0 );    // maptiles
        tiledLoader.addColliders = false;
        tiledLoader.LoadTileLayers( 1 );    // decorations
        tiledLoader.addColliders = true;    
        tiledLoader.LoadObjectGroups( 0 );  // objects
        tiledLoader.addColliders = true;
        tiledLoader.LoadTileLayers( 2 );    // UI
        tiledLoader.addColliders = false;
        tiledLoader.LoadObjectGroups( 1 );
        AddChild(level);
    }   


	public setNswitch() : base(1000, 600, false)   // tiled map should be 63 by 38 
	{
        sound = new Sound("assets/music/Cute Bossa Nova.ogg", false, false);
        sound.Play();
        LoadLevel(); 
	}

	void Update() 
	{
        if ( level.next_level != null )
        {
            level.LevelName = level.next_level;
            LoadLevel();
            level.next_level = null;
        }
	}

	static void Main()                          
	{
		new setNswitch().Start();    
	}
}