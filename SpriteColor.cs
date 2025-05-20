using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor : MonoBehaviour
{

    [SerializeField] Color red;
    [SerializeField] SpriteRenderer l;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Red()
    {
        l.color = red;
    }

    public void Green()
    {
        l.color = Color.green;
    }
}
