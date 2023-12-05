using UnityEngine;
using System;

public class SoundTest : MonoBehaviour
{
    [Range(20, 5000)] public float frequency = 440;
    [Range(0, 1)] public float gain = 0.2f;
    private float increment;//2πf/sampleFreq
    private float phase;//0~2π
    private float sampleFreq = 44100;

    void Update()
    {

    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        //data length:512 channels:2
        increment = frequency * 2 * Mathf.PI / sampleFreq;
        float max = 0; //最大振幅

        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;
            data[i] = 0;
            data[i] += (float)(gain * Math.Sin(phase));
            if (max < data[i]) max = data[i];
            if (channels == 2) data[i + 1] = data[i];
            if (phase > 2 * Math.PI) phase = 0;
        }

        if (max > 1) for (int i = 0; i < data.Length; i++) data[i] /= max; //音割れの防止
        //  Debug.Log(max);
    }
}