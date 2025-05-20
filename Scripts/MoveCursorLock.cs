using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveCursorLock : MonoBehaviour
{

    [SerializeField] Transform t;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePosition(float x, float y)
    {
        Vector3 v = new Vector3(x, y, 5);
        t.SetPositionAndRotation(v, t.rotation);
    }

    

    public void emp(float f)
    {

    }

    public void empr(float f, float w)
    {

    }


}
