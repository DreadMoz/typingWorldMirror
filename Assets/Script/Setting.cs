using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントを使用するために必要
using TMPro;

public class Setting : MonoBehaviour
{
    private bool isWindowShown = false;

    [SerializeField]
    private GameManager gm;
    public Slider volumeSlider;
    public Slider muteSlider;
    public Slider mailCharSlider;
    public Slider necoNumSlider;
    public Slider capitalSlider;
    public GameObject toGas;
    private bool showFlg = false;
    public AudioSource typingAudio;  // AudioSource コンポーネントへの参照
    [SerializeField] private AudioClip outDoor;
    [SerializeField] private AudioClip knock;
    [SerializeField] private AudioClip windowSetting;
    [SerializeField] private AudioClip windowOpen;
    [SerializeField] private AudioClip itemGet;
    [SerializeField] private AudioClip lessMoney;

    // Start is called before the first frame update
    void Start()
    {
        toGas.SetActive(false);
        gm.npcManager.UpdateNPCCount(gm.savedata.Settings[se.CatNum]);
        initVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchWindow()
    {
        if (isWindowShown)
        {
            hide();
        }
        else
        {
            sayWindowSetting();
            show();
        }
    }

    public void hide()
    {
        if (showFlg)
        {
            showFlg = false;
            gm.npcManager.UpdateNPCCount((int)necoNumSlider.value);

            gm.savedata.Settings[se.Volume] = (int)volumeSlider.value;
            gm.savedata.Settings[se.Mute] = (int)muteSlider.value;
            gm.savedata.Settings[se.CatNum] = (int)necoNumSlider.value;
            gm.savedata.Settings[se.MailChar] = (int)mailCharSlider.value;
            gm.savedata.Settings[se.Capital] = (int)capitalSlider.value;
            
            // 画面サイズを都度取得しないと途中での最大化などに対応できない
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            Debug.Log("Width:" + screenWidth + "  Height:" + screenHeight);
            transform.position = new Vector2(screenWidth * 0.5f, screenHeight * 2);
            isWindowShown = false; // 非表示に設定
            gm.exportLocal();

            typingAudio.volume = volumeSlider.value * 0.01f;    // スライダー値をボリュームに
            if (muteSlider.value == 1)
            {
                typingAudio.mute = true;
            }
            else
            {
                typingAudio.mute = false;
            }
        }
    }

    public void show()
    {
        showFlg = true;
        volumeSlider.value = gm.savedata.Settings[se.Volume];
        muteSlider.value = gm.savedata.Settings[se.Mute];
        necoNumSlider.value = gm.savedata.Settings[se.CatNum];
        mailCharSlider.value = gm.savedata.Settings[se.MailChar];
        capitalSlider.value = gm.savedata.Settings[se.Capital];

        // 画面サイズを都度取得しないと途中での最大化などに対応できない
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        Debug.Log("Width:" + screenWidth + "  Height:" + screenHeight);
        transform.position = new Vector2(screenWidth * 0.5f, screenHeight * 0.5f);
        isWindowShown = true; // 表示に設定
    }
    public void initVolume()
    {
        typingAudio.volume = gm.savedata.Settings[se.Volume] * 0.01f;    // スライダー値をボリュームに
        if (gm.savedata.Settings[se.Mute] == 1)
        {
            typingAudio.mute = true;
        }
        else
        {
            typingAudio.mute = false;
        }
    }
    public void sayOutDoor()
    {
        typingAudio.PlayOneShot(outDoor);
    }
    public void sayKnock()
    {
        typingAudio.PlayOneShot(knock);
    }
    public void sayWindowSetting()
    {
        typingAudio.PlayOneShot(windowSetting);
    }
    public void sayWindowOpen()
    {
        typingAudio.PlayOneShot(windowOpen);
    }
    public void sayItemGet()
    {
        typingAudio.PlayOneShot(itemGet);
    }
    public void sayLessMoney()
    {
        typingAudio.PlayOneShot(lessMoney);
    }
}
