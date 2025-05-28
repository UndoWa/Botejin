using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Back_button : MonoBehaviour
{
    [SerializeField] private Transform ButtonTransform;
    private bool once = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Cube.endingBool && !once) Invoke(nameof(Button), 5.0f);
    }

    void Button()
    {
        ButtonTransform.DOLocalMove(new Vector3(0,50,0),0.001f).Play();
    }
}
