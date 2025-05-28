using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Image = UnityEngine.UI.Image;

public class Kanpe : MonoBehaviour
{
    [SerializeField] private Transform KanpeTransform;
    [SerializeField] UnityEngine.UI.Image KanpeImage;
    int start=0; //スタート動作用変数
    private Image k_Image;
    public Sprite k_Sprite_1;
    public Sprite k_Sprite_2;
    int Image_change = 1;

    // Start is called before the first frame update
    void Start()
    {
        k_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    async void Update()
    {
        DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity:2000, sequencesCapacity:5000);

        if(start==0 && !Cube.openingBool)
        {
            FadeIn();
            start++;
        }
        
        if(EventTile.EV)
        {
            FadeOut();
            await Task.Delay(1500);
            switch(Image_change)
            {
                case 1:
                    k_Image.sprite = k_Sprite_1;
                    break;
                case 240:
                    k_Image.sprite = k_Sprite_2;
                    break;
                default:
                    break;
            }
            FadeIn();
            EventTile.EV = false;
            Image_change++;
        }
        if(Cube.endingBool) FadeOut();
    }

    void FadeIn()
    {
        KanpeTransform.DOLocalMove(new Vector3(-380,-150.5f,-365),1.5f).Play();
    }

    void FadeOut()
    {
        KanpeTransform.DOLocalMove(new Vector3(-1000,-150.5f,-365),1.5f).Play();
    }
}
