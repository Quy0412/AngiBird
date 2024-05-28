using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AmmoMechaism : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    private EventTrigger eventTrigger;
    private SpriteRenderer spriteRenderer;

    private bool isPowered = false;
    private bool isShooted;
    private bool shouldFaceVelDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        eventTrigger =  GetComponent<EventTrigger>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
    }

    private void FixedUpdate()
    {   if (isShooted && shouldFaceVelDirection)
        {
            transform.right = rb.velocity;
        }    
            
    }
    private void Start()
    {
        rb.isKinematic = true;
        circleCollider.enabled = false;
    }
    public void ShootAmmo( Vector2 direction, float force)
    {
        rb.isKinematic = false;
        circleCollider.enabled = true;

        //apply force
        rb.AddForce(direction * force, ForceMode2D.Impulse);

        isShooted = true;
        shouldFaceVelDirection = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shouldFaceVelDirection = false;
    }

    private void OnMouseDown()
    {
        if (isPowered == false){
            PowerUp();
            isPowered = true;
        }
    }

    private void PowerUp()
    {
        circleCollider.radius = 1.5f;
        spriteRenderer.size = new Vector2(3, 3);
    }
}
