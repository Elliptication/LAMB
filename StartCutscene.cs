using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class StartCutscene : MonoBehaviour
{

    public UnityEvent startingCutscene = new UnityEvent();
    public UnityEvent endCutscene = new UnityEvent();
    [SerializeField] MoveCursorLock m;
    PlayableDirector dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = GetComponent<PlayableDirector>();
        StartCoroutine(StartOnCue(dir, 10));
        StartCoroutine(EndOnCue(dir, 10));
    }

    IEnumerator StartOnCue(PlayableDirector dir, float t)
    {
        m.ChangePosition(12.76f, 2.73f);
        yield return new WaitForSeconds(t);
        Debug.Log("DBS");
        startingCutscene.Invoke();
        dir.Play();
    }

    IEnumerator EndOnCue(PlayableDirector dir, float t)
    {
        m.ChangePosition(-24.9f, 0.64f);
        yield return new WaitForSeconds(t + (float)(dir.duration));
        Debug.Log("EDB");
        dir.Stop();
        endCutscene.Invoke();
    } 

}
