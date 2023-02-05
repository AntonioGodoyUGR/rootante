using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MoverHormiga2 : MonoBehaviour
{
    public float speed = 45.0f;
    public float deacceleration = 3;
    public float acceleration = 6;
    public ParticleSystem walkTrail;
    public FrameAnimation idle;
    public FrameAnimation walk;
    public GameObject gridCamera;
    public GameObject playerCamera;
    private Map _myInput;
    private Vector2 currentSpeed;
    // Start is called before the first frame update
    //Frame animator to play walk and idle animation
    private FrameAnimator frameAnimator;

    //pickup
    private bool pocionLista = false;
    private GameObject go;
    public GameObject caldero;
    private CalderoBehaviour cb;
    private GameObject pickable;
    public GameObject pickedObject;
    public GameObject antidoto;
    public SpriteRenderer spritePlayer;
    public GameObject mainPlayerGrapic;

    void Start()
    {
        //_playerInput = GetComponent < PlayerInput();
        _myInput = new Map();
        _myInput.Mover.Enable();
        cb = caldero.GetComponent("CalderoBehaviour") as CalderoBehaviour;
        pickable = null;
        pickedObject = null;

        // Find player and sprite
       //spritePlayer = 

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = _myInput.Mover.Move.ReadValue<Vector2>();
        //Apply deacceleration if one axis is not pressed
        if (movementInput[0] > 0)
        {
            spritePlayer.flipX = false;
        }
        else if (movementInput[0] < 0 )
        {
            spritePlayer.flipX = true;
        }
        if (movementInput == Vector2.zero)
        {
            movementInput += decceletarion(currentSpeed);
        }
        acctionMove(movementInput);
        // change camerap
        if (_myInput.Mover.Action.WasPressedThisFrame())
        {
            sritchCameras();
        }
        //if (_playerInput.actions["Dance"].WasPressedInThisFrame())
        if (_myInput.Mover.Pickup.WasPressedThisFrame())
        {
            if (pickable != null && pickedObject == null)
            {
                pickable.transform.SetParent(this.transform);
                pickedObject = pickable;
            } 
            else if (pickedObject != null) {
                pickedObject.transform.SetParent(null);
                pickedObject = null;
            }
            else if (pocionLista)
            {
                antidoto.SetActive(true);
                pickedObject = antidoto;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        go = other.gameObject;
        if (go.tag == "Raiz")
        {
            pickable = go;
        }
        else if (go.tag == "Caldero" && cb.cocinada)
        {

            pocionLista = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        go = other.gameObject;
        if (go.tag == "Raiz")
        {
            pickable = null;
        }
        else if (go.tag == "Caldero")
        {
            pocionLista = false;
        }
    }

    // Move the player
    private void acctionMove(Vector2 move)
    {
        float horizontal = move.x;
        float vertical = move.y;

        Vector2 direction = new Vector2(horizontal, vertical);
        //direction = Mathf.Clamp(direction.x + acceleration, -1, 1) * direction.normalized : direction;
        //Vector2 f_MoveVector = new Vector2(Mathf.Abs(direction.x), Mathf.Abs(direction.y)).normalized;
        GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);

        //transform.position += direction * speed * Time.deltaTime;
    }

    private Vector2 decceletarion(Vector2 move)
    {
        Vector2 res = new Vector2();
        res.x = move.x < 0 ? Mathf.Clamp(move.x + deacceleration * Time.deltaTime, -1, 0) : Mathf.Clamp(move.x - deacceleration * Time.deltaTime, 0, 1);
        res.y = move.y < 0 ? Mathf.Clamp(move.y + deacceleration * Time.deltaTime, -1, 0) : Mathf.Clamp(move.y - deacceleration * Time.deltaTime, 0, 1);
        return res;
    }

    private void sritchCameras()
    {
        if (gridCamera.activeSelf)
        {
            gridCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        else
        {
            gridCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
    }
}