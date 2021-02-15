using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBarController : MonoBehaviour
{
    public GameObject CircleArea;
    public GameObject fill;
    public Vector2 growFill;
    // Start is called before the first frame update
    void Start()
    {
        growFill = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {

        fillerGrow();
    }

    void fillerGrow()
    {
        if(fill.transform.localScale.x <=1)
        {
            growFill = growFill+ new Vector2(0.1f*Time.deltaTime,0.1f*Time.deltaTime);
            fill.transform.localScale=growFill;
        }

    }



}
