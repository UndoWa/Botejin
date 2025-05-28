using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Endmark : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image endmark;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(EndMark), 2.0f);
    }

    void EndMark()
    {
        if(Cube.endingBool) endmark.DOFade(255f,5000f).Play();
    }
}
