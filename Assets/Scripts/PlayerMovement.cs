using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private PlayerControl playerControls;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
     private SpriteRenderer mySpriteRenderer;



    private void Awake()
    {
        playerControls = new PlayerControl();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
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
        AdjustPlayerFacingDirection();
    }

    private void FixedUpdate()
    {
        Move();
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

    private void FlipSpriteX()
    {
        if(movement.x > 0)
        {
            mySpriteRenderer.flipX = false;
        }
        else if(movement.x < 0)
        {
            mySpriteRenderer.flipX = true;
        }
    }
    
    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if(mousePos.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }
}
