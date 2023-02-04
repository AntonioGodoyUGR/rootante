using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MoverHormiga : MonoBehaviour
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

    void Start()
    {
        //_playerInput = GetComponent < PlayerInput();
        _myInput = new Map();
        _myInput.Mover.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = _myInput.Mover.Move.ReadValue<Vector2>();
        //Apply deacceleration if one axis is not pressed
        if (movementInput == Vector2.zero)
        {
            movementInput += decceletarion(currentSpeed);
        }
        acctionMove(movementInput);
        Debug.Log(movementInput);
        // change camerap
        if (_myInput.Mover.Action.WasPressedThisFrame())
        {
            sritchCameras();
        }
        //if (_playerInput.actions["Dance"].WasPressedInThisFrame())
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