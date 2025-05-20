using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhaseManager : MonoBehaviour
{

    public UnityEvent _onDeathStart;
    public UnityEvent _onDeathEnd;
    public UnityEvent _onHideStart;
    public UnityEvent _onHideEnd;
    public UnityEvent _onSamStart;
    public UnityEvent _onSamEnd;
    public UnityEvent _onRegStart;
    public UnityEvent _onRegEnd;
    public UnityEvent _onWin;
    public UnityEvent _onEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        _onDeathStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void DeathEnd()
    {
        _onDeathEnd.Invoke();
    }

    public void HideStart()
    {
        _onHideStart.Invoke();
    }

    public void HideEnd()
    {
        _onHideEnd.Invoke();
    }

    public void SamStart()
    {
        _onSamStart.Invoke();
    }

    public void SamEnd()
    {
        _onSamEnd.Invoke();
    }

    public void RegStart()
    {
        _onRegStart.Invoke();
    }

    public void RegEnd()
    {
        _onRegEnd.Invoke();
    }

    public void Win()
    {
        _onWin.Invoke();
    }

    public void UponEnd()
    {
        _onEnd.Invoke();
    }


}
