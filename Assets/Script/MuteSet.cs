using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSet : MonoBehaviour
{
    public Setting setting;
    public void changeMute()
    {
        setting.updateVolume();
    }
}
