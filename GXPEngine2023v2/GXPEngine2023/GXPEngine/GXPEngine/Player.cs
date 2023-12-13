using System;
using GXPEngine;

class Player : AnimationSprite {

    int counter;
    int frame;

    public Player() : base("CMGaTo_sheet.png",6,6) {
        scale = 5;
         
    }
    
    void Update()
    {
        counter++;
        if (counter>10)
        {
            counter = 0;
            frame++;
            if (frame==frameCount)
            {
                frame = 0;
            } 
            SetFrame(frame);
        }
    }
}
