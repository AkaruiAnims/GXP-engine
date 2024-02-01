using System;
using GXPEngine.Core;
using TiledMapParser;

namespace GXPEngine
{
    public class Level : GameObject
    {
        TiledLoader tiledLoader;
        

        public Level ()
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
            this.tiledLoader = tiledLoader;
        }

        public TiledLoader ReturnLevel ()
        {
            return tiledLoader;
        }
    }
}   