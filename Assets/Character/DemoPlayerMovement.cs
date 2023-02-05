using UnityEngine;
using UnityEngine.InputSystem;

public class DemoPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1;
    public float deacceleration = 3;
    public float acceleration = 6;
    public ParticleSystem walkTrail;
    public FrameAnimation idle;
    public FrameAnimation walk;

    //pickup
    private bool touchingpickup = false;
    private GameObject go;
    public GameObject caldero;
    private CalderoBehaviour cb;
    public Map _myInput;

    //The vector for acceleration
    private Vector2 moveVector;
    //Frame animator to play walk and idle animation
    private FrameAnimator frameAnimator;

    //Initialization
    private void Start(){
        frameAnimator = GetComponentInChildren<FrameAnimator>();
        cb = caldero.GetComponent("CalderoBehaviour") as CalderoBehaviour;
        _myInput = new Map();
        _myInput.Mover.Enable();

    }
    //Called each frame, used for key recognition
    private void Update()
    {
        //Apply deacceleration if one axis is not pressed
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector.x = moveVector.x < 0 ? Mathf.Clamp(moveVector.x + deacceleration * Time.deltaTime, -1, 0) : Mathf.Clamp(moveVector.x - deacceleration * Time.deltaTime, 0, 1);
        }
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            moveVector.y = moveVector.y < 0 ? Mathf.Clamp(moveVector.y + deacceleration * Time.deltaTime, -1, 0) : Mathf.Clamp(moveVector.y - deacceleration * Time.deltaTime, 0, 1);
        }

        //Apply acceleration if key pressed
        moveVector.x = Input.GetKey(KeyCode.RightArrow) ? Mathf.Clamp(moveVector.x + acceleration * Time.deltaTime, -1, 1) : moveVector.x;
        moveVector.x = Input.GetKey(KeyCode.LeftArrow) ? Mathf.Clamp(moveVector.x - acceleration * Time.deltaTime, -1, 1) : moveVector.x;
        moveVector.y = Input.GetKey(KeyCode.UpArrow) ? Mathf.Clamp(moveVector.y + acceleration * Time.deltaTime, -1, 1) : moveVector.y;
        moveVector.y = Input.GetKey(KeyCode.DownArrow) ? Mathf.Clamp(moveVector.y - acceleration * Time.deltaTime, -1, 1) : moveVector.y;

        if (_myInput.Mover.Pickup.WasPressedThisFrame())
        {
            Debug.Log("pickuping");
            if (touchingpickup){
                go.transform.SetParent(this.transform);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (true)
        {
           go = other.gameObject;
            if (go.tag == "Raiz") 
            {
                touchingpickup=true;

            } else if (go.tag == "Caldero" && cb.cocinada)
            {
                touchingpickup=true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        touchingpickup=false;
    }

    //Refresh the dash gauge by checking time list
    private void FixedUpdate()
    {
        //Get walk trail particle emission module
        ParticleSystem.EmissionModule emissionModuleW = walkTrail.emission;

        //If walking, play walk animation
        if (moveVector.x != 0 || moveVector.y != 0) { frameAnimator.Play(walk); emissionModuleW.enabled = true; }

        //If not moving, play idle animation
        else { frameAnimator.Play(idle); emissionModuleW.enabled = false; }

        if (moveVector.x > 0)
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        else if (moveVector.x < 0)
            GetComponentInChildren<SpriteRenderer>().flipX = true;

        //Move the player using move vector, we use fix update (fixed delta time) without delta time to get smooth physics
        //Also set interpolate on rigid body to get a smoother movement
 Vector2 f_MoveVector = new Vector2(Mathf.Abs(moveVector.x), Mathf.Abs(moveVector.y)).normalized;
 GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + f_MoveVector * moveVector * movementSpeed);
    }
}
