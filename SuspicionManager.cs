using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Ink.Runtime;

public class SuspicionManager : MonoBehaviour
{
    public Image suspicionBar;
    public float suspicionAmount = 0f;
    public UnityEvent _onExceeded70;
    public UnityEvent _onBelow70;
    public UnityEvent _onBelow30;
    public bool bodyHidden;
    public bool lambThrown;
    public bool lambCooked;

    // Set this file to your compiled json asset
	public TextAsset inkAsset;

	// The ink story that we're wrapping
	Story _samStory;

    private int diff;

    private bool sub30;
    private bool sub70;
    private bool sup70;

    private float prevSusp = 10f;
    private float gainSusp;
    private float loseSusp;

    bool hasDiffBeenSet = false;

    // Start is called before the first frame update
    void Start()
    {
        _samStory = new Story(inkAsset.text);
    }

    // Update is called once per frame
    void Update()
    {

        diff = (int) _samStory.variablesState["diff"];
        
//ACTION

        prevSusp = suspicionAmount;
        if(diff != 0 && !hasDiffBeenSet){
            switch(diff){
                case 1:
                    suspicionAmount = 30;
                    gainSusp = 10;
                    loseSusp = 20;
                    break;
                case 2:
                    suspicionAmount = 35;
                    gainSusp = 15;
                    loseSusp = 15;
                    break;
                case 3:    
                    suspicionAmount = 40;
                    gainSusp = 25;
                    loseSusp = 10;
                    break;
                case 0:
                    Debug.Log("RJSHBXCNDKJNX");
                    break;    
            }    
        }

//PROCESSING

        if (suspicionAmount >= 70)
        {
            sup70 = true;
            sub30 = false;
            sub70 = false;
        }
        else if (suspicionAmount < 30)
        {
            sub30 = true;
            sub70 = false;
            sup70 = false;
        }
        else if (suspicionAmount < 70)
        {
            sub70 = true;
            sub30 = false;
            sup70 = false;
        }

//EXECUTION

        if(sub30)
        {
            _onBelow30.Invoke();
     
        }
        else if(sub70)
        {
            _onBelow70.Invoke();
   
        }
        else if(sup70)
        {
            _onExceeded70.Invoke();
        
        }
    }

    public void IncreaseSuspicion(float amtOfTimes)
    {
        suspicionAmount += amtOfTimes*gainSusp;
        suspicionBar.fillAmount = suspicionAmount / 100f;
    }

    public void DecreaseSuspicion(float amtOfTimes)
    {
        suspicionAmount -= amtOfTimes*loseSusp;
        suspicionAmount = Mathf.Clamp(suspicionAmount, 0 , 100);

        suspicionBar.fillAmount = suspicionAmount / 100f;
    }
}


