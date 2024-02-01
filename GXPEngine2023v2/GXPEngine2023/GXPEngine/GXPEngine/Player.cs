using System;
using System.Runtime.CompilerServices;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

class Player : AnimationSprite {

    float jumpVelocity = -7;
    int lastTouchedGround;
    float velocity = 3;
    float gravity = 5;
    float noChange = 0;
    bool isGrounded = false;
    bool hasKey = false;
    bool hasLastTouchedGround = false;
    Collision collidedObject;

    // animation variables
    int[] idle_animation = { 0, 5 };
    int[] walk_animation = { 6, 5 };
    int[] jump_animation = { 6, 2 };
    int[] fall_animation = { 9, 1 };
    int[] start_crouch_animation = { 12, 2 };
    int[] crouching_animation = { 14, 1 };
    int[] stop_crouch_animation = { 16, 1 };
    int[] turn_around_animation = { 18, 2 };
    int[] ledge_hang_animation = { 21, 4 };
    int[] laser_shoot_animation = { 27, 2 };
    int[] get_hit_animation = { 30, 1 };
    int[] game_over_animation = { 32, 1 };

    // if using image in tiled, tiled asks for image in contructor, otherwise it will use the default constructor
    // 

    public Player() : base("CMGaTo_sheet.png",6,6) {
        scale = 5;
    }
    
    public Player(TiledObject obj=null) : base("CMGaTo_sheet.png",6,6) {
        //Initialize(obj);
        Console.WriteLine(obj.GetStringProperty("name"));
         
    }

// also flip sprite when moving backwards and add gravity
    void playerMovement()
    {
        if (Input.GetKey(Key.A))
        {
            collidedObject = MoveUntilCollision(-velocity, noChange);
        }
        if (Input.GetKey(Key.D))
        {
            collidedObject = MoveUntilCollision(velocity, noChange);
        }
        if (Input.GetKey(Key.SPACE) && isGrounded)
        {
            collidedObject = MoveUntilCollision(noChange, jumpVelocity);
        }
    }

    void sendToOppositeSide()
    {
        if (x < 0)
        {
            x = game.width;
        }
        if (x > game.width)
        {
            x = 0;
        }

        if (y < 0)
        {
            y = game.height;
        }
        if (y > game.height)
        {
            y = 0;
        }
    }   
    
    void updateAnimation()
    {
        _animationDelay = 5;
        if (Input.GetKey(Key.A))
        {
            SetCycle( walk_animation[0], walk_animation[1] );
        }
        if (Input.GetKey(Key.D))
        {
            SetCycle( walk_animation[0], walk_animation[1] );
        }
        if (Input.GetKey(Key.SPACE) && isGrounded)
        {
            SetCycle( jump_animation[0], jump_animation[1] );
        }
        if ( isGrounded == false )
        {
            SetCycle( fall_animation[0], fall_animation[1] );
        }

        // idle animation when no input
        if ( !Input.AnyKey() )
        {
            SetCycle(0, 5);
        }
    }   

    void Update()
    {
        sendToOppositeSide();
        playerMovement();
        updateAnimation();
        AnimateFixed(); 

        // if colided with levelkey, set hasKey to true and destroy levelkey
        if ( collidedObject != null)
        {  
            isGrounded = true;
            gravity = 0;
            lastTouchedGround = Time.now;

            if ( collidedObject.other == parent.FindObjectOfType<Button>() && hasKey  )
            {
                parent.FindObjectOfType<Button>().SetNextLevel();
            }

            if ( collidedObject.other == parent.FindObjectOfType<LevelKey>() )
            {
                Console.WriteLine("Player: has key");
                Sound sound = new Sound("assets/sounds/key_pickup.wav", false, false);
                hasKey = true;
                collidedObject.other.Destroy();
            }
            
        } else
        {
            if ( Time.now - lastTouchedGround > 1000 )
            {
                isGrounded = false;
            }
            gravity += 0.1f;
            collidedObject = MoveUntilCollision( noChange, gravity );
        }
    }
}
