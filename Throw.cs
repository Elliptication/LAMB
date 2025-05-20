using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Ink.Runtime;
using TMPro;

public class Throw : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    [SerializeField] private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        choicesText  = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject c in choices)
        {
            choicesText[index] = c.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        dialoguePanel.gameObject.SetActive(false);
    }

    public void EnterDialogueMode(TextAsset InkJSON)
    {
        dialogueIsPlaying = true;
        dialoguePanel.gameObject.SetActive(true);
        currentStory = new Story(InkJSON.text);
    }

    IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.gameObject.SetActive(false);
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            ContStory();
        }
        
    }

    void ContStory()
    {
        if(currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices() 
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach(Choice choice in currentChoices) 
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++) 
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        // NOTE: The below two lines were added to fix a bug after the Youtube video was made
         // this is specific to my InputManager script
        ContStory();
    }

}
