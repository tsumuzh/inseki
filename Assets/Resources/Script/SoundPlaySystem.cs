using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundPlaySystem : MonoBehaviour
{
    public AudioClip soundEffect;
    private bool isReady = false;
    public float[] soundData;
    private int count = 0, sampleLength;
    [Range(0, 1)] public float gain = 0.5f;

    public void SetSoundData(AudioClip audioClip)
    {
        soundEffect = audioClip;
        sampleLength = soundEffect.samples * soundEffect.channels;
        soundData = new float[sampleLength];
        soundEffect.GetData(soundData, 0);
        isReady = true;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!isReady) return;

        for (int i = 0; i < data.Length; i += channels)
        {
            if (count >= sampleLength)
            {
                isReady = false;
                //  count -= samplingRate;
                count = 0;
            }
            if (count < sampleLength) data[i] = gain * soundData[count];
            if (channels == 2) data[i + 1] = data[i];
            count++;
        }
    }
}
