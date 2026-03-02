using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    public float movespeed = 5f;
    public Vector2 moveInput;
    private Rigidbody2D playerrb;
    [SerializeField] private Animator Playeraim;
    private int MoveInputX = Animator.StringToHash("MoveInputX");
    private int MoveInputY = Animator.StringToHash("MoveInputY");
    private int IsMoving = Animator.StringToHash("IsMoving");
    private void Awake()
    {
        playerrb = GetComponent<Rigidbody2D>();
        if (playerrb == null) ;
        Playeraim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        HandlePlayerAnimations();
    }
    public void HandlePlayerMovement()
    {
        playerrb.MovePosition(playerrb.position + moveInput * movespeed * Time.deltaTime);
    }
    public void HandlePlayerAnimations()
    {
        if (moveInput != Vector2.zero)
        {
            Playeraim.SetFloat(MoveInputX, moveInput.x);
            Playeraim.SetFloat(MoveInputY, moveInput.y);
            Playeraim.SetBool(IsMoving, true);
            
        }
        else
        {
            Playeraim.SetBool(IsMoving, false);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
