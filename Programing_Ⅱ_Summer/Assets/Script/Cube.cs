using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube : MonoBehaviour
{
    //音とかのもろもろ
    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;
    public AudioClip sound7;

    public static int talk_state = 0; //何を話したかの状態変数　すぐに切り替わる
    int count = 0;
    public static bool openingBool = true; //スタート直後の判定
    public static bool endingBool = false; //エンディング判定
    bool comovingBool = false; //動きの最中かどうかの判定
    //public bool boteMode = true; //ぼてモードの判定

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        OpeningMove();
    }

    // Update is called once per frame
    void Update()
    {
        if(!endingBool)
        {
            Move();
            Talk();
            if(count==255) //話状態のリセット
            {
                talk_state = 0;
                count = 0;
            }
            count++;
            if(talk_state == 3) Invoke(nameof(shine), 0.5f);
            if(EventTile.eventNum == 6 && transform.position.x >= -12.5f && transform.position.x <= -11.5f && transform.position.z >= -7.5f && transform.position.z <= -6.5f && !endingBool) endingBool = true;
        }
    }

    //スタート時の動き
    async void OpeningMove()
    {
        await Task.Delay(1000);
        for(int i=0;i<=3;i++)
        {
            for(int boteCount=0;boteCount<=3;boteCount++)
            {
                StartCoroutine("BackMove");
                audioSource.PlayOneShot(sound1);
                Debug.Log("ぼて");
                await Task.Delay(300);
            }
            await Task.Delay(450);

            StartCoroutine("BackMove");
            audioSource.PlayOneShot(sound2);
            Debug.Log("ぼてじん");
            await Task.Delay(750);
            StartCoroutine("FrontMove");
            await Task.Delay(500);
        }

        openingBool = !openingBool;
    }

    //動きの入力とか
    void Move()
    {
        if(!openingBool )
        {
            //後進
            if(Input.GetKeyDown(KeyCode.S))
            {
                if(!comovingBool)
                {
                    comovingBool = true;
                    StartCoroutine("BackMove");
                }
            }
            //前進
            if(Input.GetKeyDown(KeyCode.W))
            {
                if(!comovingBool)
                {
                    comovingBool = true;
                    StartCoroutine("FrontMove");
                }
            }
            //右進
            if(Input.GetKeyDown(KeyCode.D))
            {
                if(!comovingBool)
                {
                    comovingBool = true;
                    StartCoroutine("RightMove");
                }
            }
            //左進
            if(Input.GetKeyDown(KeyCode.A))
            {
                if(!comovingBool)
                {
                    comovingBool = true;
                    StartCoroutine("LeftMove");
                }
            }
        }
    }

    //後進の時間的な動作
    IEnumerator BackMove()
    {
        audioSource.PlayOneShot(sound3);
        for(int i=0;i<25;i++)
            {
                transform.position = transform.position + Vector3.back * 0.04f;
                this.transform.Rotate(-3.6f,0,0,Space.World);
                yield return new WaitForSeconds(0.00001f);
            }
        comovingBool = false;
    }
    //前進の時間的な動作
    IEnumerator FrontMove()
    {
        audioSource.PlayOneShot(sound3);
        for(int i=0;i<25;i++)
            {
                transform.position = transform.position + Vector3.forward * 0.04f;
                this.transform.Rotate(3.6f,0,0,Space.World);
                yield return new WaitForSeconds(0.00001f);
            }
        comovingBool = false;
    }
    //右進の時間的な動作
    IEnumerator RightMove()
    {
        audioSource.PlayOneShot(sound3);
        for(int i=0;i<25;i++)
            {
                transform.position = transform.position + Vector3.right * 0.04f;
                this.transform.Rotate(0,0,-3.6f,Space.World);
                yield return new WaitForSeconds(0.00001f);
            }
        comovingBool = false;
    }
    //左進の時間的な動作
    IEnumerator LeftMove()
    {
        audioSource.PlayOneShot(sound3);
        for(int i=0;i<25;i++)
            {
                transform.position = transform.position + Vector3.left * 0.04f;
                this.transform.Rotate(0,0,3.6f,Space.World);
                yield return new WaitForSeconds(0.00001f);
            }
        comovingBool = false;
    }

    //話す動作
    void Talk()
    {
        if(!openingBool)
        {
            if(!comovingBool)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    /*Debug.Log(this.transform.eulerAngles.x);
                    Debug.Log(this.transform.eulerAngles.y);
                    Debug.Log(this.transform.eulerAngles.z);*/
                    //「ぼてじん」
                    if(this.transform.eulerAngles.x>=269 && this.transform.eulerAngles.x<=271 && this.transform.eulerAngles.y>=-1 && this.transform.eulerAngles.y<=1 && this.transform.eulerAngles.z>=-1 && this.transform.eulerAngles.z<=1)
                    {
                        Debug.Log("ぼてじん");
                        audioSource.PlayOneShot(sound2);
                        talk_state = 1;
                    }
                    //「よろしく」
                    if(this.transform.eulerAngles.x>=-1 && this.transform.eulerAngles.x<=1 && this.transform.eulerAngles.y>=179 && this.transform.eulerAngles.y<=181 && this.transform.eulerAngles.z>=179 && this.transform.eulerAngles.z<=181)
                    {
                        Debug.Log("よろしく");
                        audioSource.PlayOneShot(sound6);
                        talk_state = 2;
                    }
                    //「しね」
                    if(this.transform.eulerAngles.x>=89 && this.transform.eulerAngles.x<=91 && this.transform.eulerAngles.y>=-1 && this.transform.eulerAngles.y<=1 && this.transform.eulerAngles.z>=-1 && this.transform.eulerAngles.z<=1)
                    {
                        Debug.Log("しね");
                        audioSource.PlayOneShot(sound7);
                        talk_state = 3;
                    }
                    //「ぼく」
                    if(this.transform.eulerAngles.x>=89 && this.transform.eulerAngles.x<=91 && this.transform.eulerAngles.y>=89 && this.transform.eulerAngles.y<=91 && this.transform.eulerAngles.z>=-1 && this.transform.eulerAngles.z<=1)
                    {
                        Debug.Log("ぼく");
                        audioSource.PlayOneShot(sound5);
                        talk_state = 4;
                    }
                    //「こんにちは」
                    if(this.transform.eulerAngles.x>=89 && this.transform.eulerAngles.x<=91 && this.transform.eulerAngles.y>=269 && this.transform.eulerAngles.y<=271 && this.transform.eulerAngles.z>=-1 && this.transform.eulerAngles.z<=1)
                    {
                        Debug.Log("こんにちは");
                        audioSource.PlayOneShot(sound4);
                        talk_state = 5;
                    }
                }
            }
        }
    }

    //しね用関数
    void shine()
    {
        SceneManager.LoadScene("Housoujiko");
    }
}
