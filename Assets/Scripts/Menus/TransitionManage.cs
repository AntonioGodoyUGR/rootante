using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManage : MonoBehaviour
{

    private Map _myInput;
    // Start is called before the first frame update
    void Start()
    {
        _myInput = new Map();
        _myInput.Mover.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (_myInput.Mover.Action.WasPressedThisFrame())
        {
            
        }
    }
}
