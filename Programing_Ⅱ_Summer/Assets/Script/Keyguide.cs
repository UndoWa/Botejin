using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyguide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text text = this.GetComponent<Text>();
        if(!Cube.openingBool) text.color = new Color(255f,255f,255f,255f);
        if(Cube.endingBool) text.color = new Color(255f,255f,255f,0f);
    }
}
