using System;
using GXPEngine;

class Player : AnimationSprite {

    int counter;
    int frame;
    float jumpVelocity = -5;
    float velocity = 5;
    float fallingVelocity = 5;
    //float gravity = 5;
    float backwardsVelocity = -5;
    float noChange = 0;

    public Player() : base("CMGaTo_sheet.png",6,6) {
        scale = 5;
         
    }

    void playerMovement()
    {
        if (Input.GetKey(Key.A))
        {
            MoveUntilCollision(backwardsVelocity, noChange);
        }
        if (Input.GetKey(Key.D))
        {
            MoveUntilCollision(velocity, noChange);
        }
        if (Input.GetKey(Key.W))
        {
            MoveUntilCollision(noChange, jumpVelocity);
        }
        if (Input.GetKey(Key.S))
        {
            MoveUntilCollision(noChange, fallingVelocity);
        }
    }
    
    void Update()
    {
        playerMovement();
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
