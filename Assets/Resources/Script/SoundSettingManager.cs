using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class SoundSettingManager : MonoBehaviour
{
    [SerializeField] Slider soundEffectSlider, backgroundSoundSlider;
    [SerializeField] GameObject SoundSettingGroup;
    void Start()
    {
        StreamReader sr = new StreamReader("Save/soundsetting.txt");
        string data = sr.ReadToEnd();
        sr.Close();
        int idx = data.IndexOf(":");
        soundEffectSlider.value = float.Parse(data.Substring(0, idx));
        backgroundSoundSlider.value = float.Parse(data.Substring(idx + 1, data.Length - idx - 1));

        GameObject.Find("Main Camera").GetComponent<SoundPlaySystem>().gain = soundEffectSlider.value;
        GameObject.Find("Main Camera").GetComponent<Sinus>().gain = backgroundSoundSlider.value;
    }
    public void SwitchSetting()
    {
        SoundSettingGroup.SetActive(!SoundSettingGroup.activeSelf);
    }
    public void ChangeSoundVolume()
    {
        GameObject.Find("Main Camera").GetComponent<SoundPlaySystem>().gain = soundEffectSlider.value;
        GameObject.Find("Main Camera").GetComponent<Sinus>().gain = backgroundSoundSlider.value;

        StreamWriter sw = new StreamWriter("Save/soundsetting.txt", false, Encoding.UTF8);
        sw.Write(soundEffectSlider.value + ":" + backgroundSoundSlider.value);
        sw.Close();
    }
}
