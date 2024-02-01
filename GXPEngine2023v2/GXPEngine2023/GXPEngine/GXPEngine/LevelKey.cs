using System;
using GXPEngine;                                
using TiledMapParser;


class LevelKey : Sprite
{
    public LevelKey(TiledObject obj=null) : base("assets/Tilemap/key.png")
    {
        //Initialize(obj);
    }

    // if collided with player destroy key and add to inventory
}
