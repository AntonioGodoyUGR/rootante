using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManage : MonoBehaviour
{

    public GameObject actual;
    public GameObject next=null;
    
    private Map _myInput;


    [SerializeField] private bool fadeIN;
    [SerializeField] private bool fadeOUT;
    // Start is called before the first frame update
    void Start()
    {
        _myInput = new Map();
        _myInput.Mover.Enable();
        fadeIN = false;
        fadeOUT = false;
        //actual.GetComponent<Image>().color += new Color(0,0,0,0);
        ShowUI();
        //GetComponent<Image>().GetComponent<TextMeshProUGUI>().text = "";

    }

    private void OnEnable()
    {
        actual.GetComponent<Image>().color += new Color(0, 0, 0, -1);
        ShowUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (_myInput.Mover.Action.WasPressedThisFrame())
        {
            Debug.Log("Action");
            HideUI();
            if (next == null)
            {
                SceneManager.LoadScene("Scenes/LoadGame");
            }
        }

        if (actual.GetComponent<Image>().color.a >= 1)
            StartCoroutine(WriteText());


        if (actual.GetComponent<Image>().color.a < 1 && fadeIN)
        {

            actual.GetComponent<Image>().color += new Color(0,0,0, Time.deltaTime);
            if (actual.GetComponent<Image>().color.a >= 1)
            {
                fadeIN = false;
                //next.enabled = true;
                //actual.enabled = false;
                    
            }

        }
        else if (next != null)
        {
            if (next.GetComponent<Image>().color.a >= 0 && fadeOUT)
            {
                actual.GetComponent<Image>().color -= new Color(0, 0, 0, Time.deltaTime);
                if (actual.GetComponent<Image>().color.a <= 0)
                {
                    fadeOUT = false;
                    next.gameObject.SetActive(true);
                    next.GetComponent<Image>().color += new Color(0, 0, 0, 0);
                    actual.gameObject.SetActive(false);
                }
            }
        }
        
    }


    IEnumerator WriteText()
    {
        foreach (char c in "AYUDA")
        {
            GetComponent<Image>().GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void animateWrite()
    {
        GetComponent<Image>().GetComponent<TextMeshProUGUI>().text += "a";
    }

    public void ShowUI()
    {
        fadeIN = true;
    }

    public void HideUI()
    {
        fadeOUT = true;
    }


}
