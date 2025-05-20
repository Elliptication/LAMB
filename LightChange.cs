using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{

    [SerializeField] Color red;
    [SerializeField] Light l;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Red()
    {
        l.color = Color.red;
    }

    public void Green()
    {
        l.color = Color.green;
    }
}
