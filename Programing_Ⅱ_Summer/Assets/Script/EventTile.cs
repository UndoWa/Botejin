using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTile : MonoBehaviour
{
    [SerializeField] GameObject target;
    public static int eventNum = 1; //イベント管理変数
    public static bool EV = false; //イベント発生時の判定 Kanpeで使用
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        //座標取得
        Vector3 pos = this.transform.position;
        //座標初期設定
        if(Cube.openingBool) pos.y = -100;
        else pos.y = -0.85f;

        switch(eventNum)
        {
            case 1:
                if(target.transform.position.x>=-0.5f && target.transform.position.x<=0.5f && target.transform.position.z>=-7.5f && target.transform.position.z<=-6.5f)
                {  
                    if(Cube.talk_state == 5)
                    {
                        Debug.Log("おせ");
                        pos.x = -2; //タイルの座標指定
                        pos.z = -5;
                        eventNum++; //管理変数のインクリメント
                        Cube.talk_state = 0; //話状態のリセット
                        EV = true;
                    }
                }
                break;
            case 2:
                if(target.transform.position.x>=-2.5f && target.transform.position.x<=-1.5f && target.transform.position.z>=-5.5f && target.transform.position.z<=-4.5f)
                {  
                    if(Cube.talk_state == 4)
                    {
                        Debug.Log("ちん");
                        pos.x = 1; //タイルの座標指定
                        pos.z = -7;
                        eventNum++; //管理変数のインクリメント
                        Cube.talk_state = 0; //話状態のリセット
                        //EV = true; //カンペ移動不要のため
                    }
                }
                break;
            case 3:
                if(target.transform.position.x>=0.5f && target.transform.position.x<=1.5f && target.transform.position.z>=-7.5f && target.transform.position.z<=-6.5f)
                {  
                    if(Cube.talk_state == 1)
                    {
                        Debug.Log("こ");
                        pos.x = -2; //タイルの座標指定
                        pos.z = -5;
                        eventNum++; //管理変数のインクリメント
                        Cube.talk_state = 0; //話状態のリセット
                        //EV = true; //カンペ移動不要のため
                    }
                }
                break;
            case 4:
                if(target.transform.position.x>=-2.5f && target.transform.position.x<=-1.5f && target.transform.position.z>=-5.5f && target.transform.position.z<=-4.5f)
                {  
                    if(Cube.talk_state == 2)
                    {
                        Debug.Log("ちんちんちんちんちんちんちんちんちん");
                        pos.x = 100; //タイルの座標指定
                        eventNum++; //管理変数のインクリメント
                        Cube.talk_state = 0; //話状態のリセット
                        //EV = true; //カンペ移動不要のため
                    }
                }
                break;
            case 5:
                EV = true;
                eventNum=6;
                break;
            default:
                break;
        }

        this.transform.position = pos; //座標移動
    }

}
