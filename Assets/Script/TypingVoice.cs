using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;  // UIコンポーネントを扱うために必要

public class TypingVoice : MonoBehaviour
{
    public GameManager gm;
    public Image muteIcon; // インスペクターからアサイン
    public Sprite voiceSprite; // 音声ありの画像
    public Sprite muteSprite; // ミュートの画像
    public AudioSource nya;  // AudioSource コンポーネントへの参照
    public Slider slider;

    // Start is called before the first frame update

    void Start()
    {
        initVolume();
        dispMute();
    }

    public void ToggleMute()
    {
        // ミュート状態を切り替える
        gm.savedata.Settings[se.Mute] = 1 - gm.savedata.Settings[se.Mute];
        dispMute();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);    // EventSystemのフォーカスをクリア
    }

    private void dispMute()
    {
        // アイコンの更新
        if (gm.savedata.Settings[se.Mute] == 0)
        {
            muteIcon.sprite = voiceSprite;
            nya.volume = (float)gm.savedata.Settings[se.Volume] * 0.01f;
            slider.fillRect.GetComponent<Image>().color = new Color(0.502848f, 0.7884344f, 0.9433962f, 1);
        }
        else
        {
            muteIcon.sprite = muteSprite;
            nya.volume = 0;
            slider.fillRect.GetComponent<Image>().color = new Color(0.7075472f, 0.5416017f, 0.4438857f, 1);
        }
    }
    public void updateVolume()
    {
        gm.savedata.Settings[se.Mute] = 0;
        muteIcon.sprite = voiceSprite;
        gm.savedata.Settings[se.Volume] = (int)slider.value;
        nya.volume = (float)gm.savedata.Settings[se.Volume] * 0.01f;
        slider.fillRect.GetComponent<Image>().color = new Color(0.502848f, 0.7884344f, 0.9433962f, 1);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);    // EventSystemのフォーカスをクリア
    }
    public void initVolume()
    {
        if (gm.savedata.Settings[se.Mute] == 1)
        {
            nya.volume = 0.0f;
        }
        else
        {
            slider.value = gm.savedata.Settings[se.Volume];
            nya.volume = (float)gm.savedata.Settings[se.Volume] * 0.01f;
        }
    }

}