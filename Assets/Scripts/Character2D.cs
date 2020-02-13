using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UNAV2DTools.GameplaySystem;

public class Character2D : MonoBehaviour
{
    
    protected SpriteRenderer spr;
    protected Animator anim;
    protected Rigidbody2D rb2D;
    [SerializeField, Range(0.1f, 10f)]
    protected float jumpForce = 7f;
    [SerializeField, Range(0.1f, 10f)]
    protected float moveSpeed = 3f;

    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField, Range(0.1f, 5f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }


    protected bool FlipSprite
    {
        get => GameplaySystem.Axis.x < 0 ? true : GameplaySystem.Axis.x > 0 ? false : spr.flipX;
    }

    protected bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

}
