using System;
using GXPEngine.Core;

namespace GXPEngine
{

    public class Level : GameObject
    {
        public String level_name;
        
        public Level( String main_screen = "Menu.tmx" )
        {
            level_name = main_screen;
        }

        public String LevelName
        {
            get { return level_name; }
            set { level_name = value; }
        }   

    }
}   