using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseCharacter
{
    private InputManager input;
    /*public float Speed = 30f;
    public float JumpForce = 3f;*/
    private float movementValue;
    private InputAction.CallbackContext movementContext;
    public LayerMask JumpLayerMask;
    //private Rigidbody2D rb;
    private RecordAbility recAbility;
    private MovementCommand movement;
    private JumpCommand jump;
    [SerializeField] private GameObject ghost;

    public InputManager Input { get => input; }
    public RecordAbility RecAbility { get => recAbility; }
    public InputAction.CallbackContext MovementContext { get => movementContext; set => movementContext = value; }
    public GameObject Ghost { get => ghost;}
    public JumpCommand JumpCommand { get => jump; set => jump = value; }

    private void Awake()
    {
        input = GetComponent<InputManager>();
        recAbility = GetComponent<RecordAbility>();
        Rb = GetComponent<Rigidbody2D>();
        movement = new MovementCommand();
        jump = new JumpCommand();
    }

    private void OnEnable()
    {
        input.onMovement += StartMovement;
        input.onStopMovement += StopMovement;
        input.onJumpStarted += Jump;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementValue = input.Input.Movement.Forward.ReadValue<float>();
        Rb.velocity = new Vector2(Vector2.right.x * Speed * movementContext.ReadValue<float>() * Time.deltaTime, Rb.velocity.y);

        //movement.Execute(this, movementContext);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!Physics2D.Raycast(transform.position, Vector2.down, 0.3f, JumpLayerMask)) return;
        jump.Execute(this);
        if (recAbility.IsRecording)
        {
            recAbility.AddCommand(CommandType.jump, recAbility.RecordingTime);
        }
    }

    public void StartMovement(InputAction.CallbackContext context)
    {
        //movementContext = context;
        movement.Execute(this, context);
    }
    
    public void StopMovement(InputAction.CallbackContext context)
    {
        movement.Execute(this, context);
    }

}
