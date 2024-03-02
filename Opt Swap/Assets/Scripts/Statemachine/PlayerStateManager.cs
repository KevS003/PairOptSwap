using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    //MOVEMENT VARS
    public Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveInput;
    public PlayerInput playerInput;
    //Attacking vars
    [SerializeField] public LayerMask attackableLayer;
    [SerializeField] public Transform attackTransform;
    [SerializeField] public float attackRange = 1.5f;
    //damage vars
    public int damage;
    //can change this based on powerups n stuff^

    /* InputAction move;
    InputAction dash;
    InputAction attack; */ 

    /* private float horizontal;
    private float vertical;
 */    public float speed = 8f;
    public float dashPower = 2f;
    public float dashTime = .2f;
    //private bool isFacingRight = true;
    private bool dashing;
    
    //STATEMACHINE STUFF
    PlayerBaseState currentState;//This is what gives structure to all other states
    
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerMoveState MoveState = new PlayerMoveState();
    //public PlayerDashState DashState = new PlayerDashState();
    public PlayerAttackState AttackState = new PlayerAttackState();
    

    // Start is called before the first frame update
    void Start()
    {
        //First state of the player
        /* playerInput = new PlayerInput();
        move = playerInput.currentActionMap.FindAction("Move");
        playerInput. */
        //playerInput.actions.move += Move();
        //playerInput = new PlayerInput();//Get input system to turn on and off
        currentState = IdleState;
        currentState.EnterState(this);//calls the enterstate method at the start of IDLE 
    }

    // Update is called once per frame
    void Update()
    {
        currentState.tick(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState.OnExit(this);
        currentState = state;
        state.EnterState(this);
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput.x = context.ReadValue<Vector2>().x;
        moveInput.y = context.ReadValue<Vector2>().y;
        SwitchState(MoveState);

    }
    public void Dash(InputAction.CallbackContext context)
    {
        
        //dashing = true;
        /* Debug.Log("We dash?");
        if(context.performed) //does a full dash
        {
            Debug.Log("We Dash");
            //speed = dashPower;
            Debug.Log(moveInput*(speed+dashPower));
            
        }
        if(context.canceled)//Does half a dash
        {
            Debug.Log("We Dash/2");
             rb.AddForce(moveInput * dashPower * 0.5f, ForceMode2D.Impulse);
             
        } */
        //dashing = false;
        //SwitchState(DashState);

        //Running coroutine instead of state cuz move is always overwritting dash
        if(context.started)
            StartCoroutine(DashCoolDown());
        
    } 

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.started)
            SwitchState(AttackState);
    }

    private IEnumerator DashCoolDown()
    {
        Debug.Log("Dashing");
        dashing = true;
        speed+=dashPower;
        yield return new WaitForSeconds(dashTime);
        speed-=dashPower;
        dashing = false;
    }


}
