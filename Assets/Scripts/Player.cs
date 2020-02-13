using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UNAV2DTools.GameplaySystem;

public class Player : Character2D
{
    void Update()
    {

        GameplaySystem.MovementTransform(transform, moveSpeed, spr, FlipSprite, anim);
        
        //jump
        if(GameplaySystem.JumpButton && Grounding)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
        anim.SetBool("ground", Grounding);
    }
}
