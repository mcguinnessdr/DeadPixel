using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {

    public static Player player;
    public Collider2D groundCollider;
    public bool grounded;
    public Vector2 speed;
    Rigidbody2D rigidbody2D;
    public Transform deadPlayer;
    public Vector2 spawnPoint;
    public UnityEvent died;
    public UnityEvent reallyDied;
    public Transform particlesLeft;
    public Transform particlesRight;
    float oldDir;
    bool justPressed;
    public float acceleration;
    float currentSpeed;
    public Power[] powers = new Power[10];

	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spawnPoint = transform.position;
        player = this;
	}
	
	void Update () {
        //Check if grounded
        grounded = false;
        var layer = LayerMask.GetMask("ground");
        var start = transform.position + transform.right * .49f - transform.up * .5f;
        var end = -transform.up;
        var distance = .1f;
        //if (Physics2D.OverlapArea(groundCollider.bounds.min, groundCollider.bounds.max, layer)) grounded = true;
        RaycastHit2D hit = Physics2D.Raycast(start, end, distance, layer);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - transform.right * .49f - transform.up * .5f, end, distance, layer);
        print(hit.normal);
        Debug.DrawRay(start, end * distance, Color.red);
        grounded = (hit.transform != null && Vector2.Angle(transform.up, hit.normal) < 45f) || (hit2.transform != null && Vector2.Angle(transform.up, hit2.normal) < 45f);

        //Handle Input
        Move(InputHandler.instance.movement);
        if(InputHandler.instance.jump)
        {
            Jump();
        }
        if (InputHandler.instance.stopJump)
        {
            StopJump();
        }

        //Power up test
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(powers[0] != null)
            {
                powers[0].Use();
            }
        }
	}

    void accelerate(float targetSpeed)
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
    }

    public void Jump()
    {
        if(grounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speed.y);
        }
    }

    public void StopJump()
    {
        if(rigidbody2D.velocity.y > 0f)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speed.y * .1f);
        }
    }

    public void Move(float movement)
    {
        if(movement != 0)
        {
            accelerate(movement);
        }
        else
        {
            currentSpeed = 0;
        }
        rigidbody2D.velocity = new Vector2(speed.x * currentSpeed, rigidbody2D.velocity.y);
    }

    public void kill()
    {
        Instantiate(deadPlayer, transform.position, transform.rotation);
        reset();
        died.Invoke();
    }

    public void reset()
    {
        transform.position = spawnPoint;
    }
}
