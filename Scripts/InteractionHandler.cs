using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractionHandler : MonoBehaviour
{

    public List<Button> interactableButtons = new List<Button>();
    public List<Transform> interactableTransforms = new List<Transform>();
    public List<Interactable> interactableScripts = new List<Interactable>();
    List<float> magnitudes = new List<float>();
    Transform currentPos;
    public bool isInCycle = false;

    // Start is called before the first frame update
    void Start()
    { 
        currentPos = GetComponent<Transform>();
    }

    void HideUI()
    {
        this.gameObject.SetActive(false);
    }

    void ShowUI()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = GetComponent<Transform>();
        foreach(Transform t in interactableTransforms)
        {
            Vector2 dist = new Vector2(Mathf.Abs(t.position.x - currentPos.position.x), Mathf.Abs(t.position.y - currentPos.position.y));
            magnitudes.Add(dist.magnitude);
        }
        if((SearchForMin() != -1))
        {
            int minDex = SearchForMin();
            if(!isInCycle){
                if(!interactableScripts[minDex].isDisabled)
                {
                    interactableButtons[minDex].animator.CrossFade("Highlighted", 0.3f);
                }
                else
                {
                    interactableButtons[minDex].animator.CrossFade("Disabled", 0.3f);
                }
                
            }    

            if(Input.GetKeyDown(KeyCode.E) && (!interactableScripts[minDex].isDisabled))
            {
                
                //interactableButtons[minDex].onClick;
                isInCycle = true;
                interactableButtons[minDex].onClick.Invoke();
                interactableButtons[minDex].animator.Play("Pressed");
                interactableScripts[minDex].isDisabled = true;
                StartCoroutine(Cooldown(minDex));
                isInCycle = false;

            }    

            for(int i = 0; i < interactableButtons.Count; i++)
            {
                if(i!= minDex)
                {
                    if(!interactableScripts[i].isDisabled)
                    {
                        interactableButtons[i].animator.CrossFade("Normal", 0.3f);
                    }
                    else
                    {
                        interactableButtons[i].animator.CrossFade("Disabled", 0.3f);
                    }
                }
            }
            
        }
            

        magnitudes.Clear();
    }

    int SearchForMin()
    {
        float minVal = 120120;
        int minDex = -1;
        int currDex = 0;

        foreach(float i in magnitudes)
        {
            if(i < minVal)
            {
                minVal = i;
                minDex = currDex;
            }
            currDex++;
        }
        return minDex;
    }

    IEnumerator Cooldown(int minDex)
    {
        yield return new WaitForSeconds(interactableScripts[minDex].cooldown);
        interactableScripts[minDex].isDisabled = false;
    }
}
