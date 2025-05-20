using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] SpriteRenderer playerRenderer;
    [SerializeField] Sprite up;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;
    [SerializeField] Sprite down;
    [SerializeField] Transform t;
    float hor;
    float ver;

    public float runSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 60;
        t = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.D))
        {
            playerRenderer.sprite = right;
        }

        else if(Input.GetKeyDown(KeyCode.A))
        {
            playerRenderer.sprite = left;
        }

        else if(Input.GetKeyDown(KeyCode.S))
        {
            playerRenderer.sprite = down;
        }

        else if(Input.GetKeyDown(KeyCode.W))
        {
            playerRenderer.sprite = up;
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(hor * runSpeed, ver * runSpeed);
    }

    public void SetRunSpeed(float newSpeed)
    {
        runSpeed = newSpeed;
    }

    public void TranslateZ(float z)
    {
        StartCoroutine(TranslateAfterTime(2, 0, 0, z));
    }

    public void TranslateY(float y)
    {
        StartCoroutine(TranslateAfterTime(0.25f, 0, y, 0));
    }

    public void TranslateX(float x)
    {
        StartCoroutine(TranslateAfterTime(2, x, 0, 0));
    }

    IEnumerator TranslateAfterTime(float seconds, float x, float y, float z)
    {
        yield return new WaitForSeconds(seconds);
        t.Translate(x, y, z);
    }
}
