using UnityEngine;
using System;

public class Sinus : MonoBehaviour
{
    public float frequency = 440, overtonesRange = 1;
    public float freqRandRange;
    private float randomFreq;
    [Range(0, 1)] public float gain = 0.2f;
    private float increment;//2πf/sampleFreq
    private float phase;//0~2π
    private float sampleFreq = 44100;

    void Update()
    {
        randomFreq = Mathf.PerlinNoise(0, Time.timeSinceLevelLoad) * freqRandRange; //未使用
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
            for (int j = 1; j <= overtonesRange; j++) data[i] += (float)(gain * Math.Sin(phase * j + randomFreq)) / (float)j; //振幅が周波数に反比例する倍音を足す //音割れ防止処理が必要
            if (max < data[i]) max = data[i];
            if (channels == 2) data[i + 1] = data[i];
            if (phase > 2 * Math.PI) phase = 0;
        }

        if (max > 1) for (int i = 0; i < data.Length; i++) data[i] /= max; //音割れの防止
        //  Debug.Log(max);
    }
}