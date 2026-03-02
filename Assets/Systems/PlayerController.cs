using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 5f;
    public Vector2 moveInput;
    private Rigidbody2D playerrb;
    [SerializeField] private Animator Playeraim;
    private int MoveInputXHash = Animator.StringToHash("MoveInputX");
    private int MoveInputYHash = Animator.StringToHash("MoveInputY");
    private int IsMovingHash = Animator.StringToHash("IsMoving");
    private void Awake()
    {
        playerrb = GetComponent<Rigidbody2D>();
        if (playerrb == null) ;
        Playeraim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        HandlePlayerAnimations();
    }
    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }
    public void HandlePlayerMovement()
    {
        playerrb.MovePosition(playerrb.position + moveInput * movespeed * Time.deltaTime);
    }
    public void HandlePlayerAnimations()
    {
        if (moveInput != Vector2.zero)
        {
            Playeraim.SetFloat(MoveInputXHash, moveInput.x);
            Playeraim.SetFloat(MoveInputYHash, moveInput.y);
            Playeraim.SetBool(IsMovingHash, true);
        }
        else
        {
            Playeraim.SetBool(IsMovingHash, false);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}















