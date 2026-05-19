using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private PlayerControl playerControls;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
     private SpriteRenderer sprite;



    private void Awake()
    {
        playerControls = new PlayerControl();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }




    void Start()
    {

    }


    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
        FlipX();
    }
    private void PlayerInput()
    {
        movement = playerControls.Moviment.Move.ReadValue<Vector2>();
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);

    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void FlipX()
    {
        if(movement.x > 0)
        {
            sprite.flipX = false;
        }
        else if(movement.x < 0)
        {
            sprite.flipX = true;
        }
    }
}
