using System;
using GXPEngine;
using GXPEngine.Managers;

class Level : GameObject
{
    public String level_name;
    public String last_level;
    public String next_level;
    
    public Level( String main_screen = "Menu.tmx" )
    {
        level_name = main_screen;
        last_level = main_screen;
    }

    public String LevelName
    {
        get { return level_name; }
        set { last_level = level_name; level_name = value; }
    }   

    public void SetNextLevel( String next_level )
    {
        this.next_level = next_level;
    }   
}