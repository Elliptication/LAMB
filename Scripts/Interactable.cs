using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public GameObject linked;
    public InteractionHandler handler;
    public float cooldown;
    public bool isDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        linked.SetActive(false);
    }

    void HideUI()
    {
        linked.SetActive(false);
    }

    void ShowUI()
    {
        linked.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "InteractionHandler")
        {
            linked.SetActive(true);
            handler.interactableButtons.Add(linked.GetComponent<Button>());
            handler.interactableTransforms.Add(linked.GetComponent<Transform>());
            handler.interactableScripts.Add(GetComponent<Interactable>());
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if(c.tag == "InteractionHandler")
        {
            linked.SetActive(false);
            handler.interactableButtons.Remove(linked.GetComponent<Button>());
            handler.interactableTransforms.Remove(linked.GetComponent<Transform>());
            handler.interactableScripts.Remove(GetComponent<Interactable>());
        }
    }

}
