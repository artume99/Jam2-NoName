using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicTest : MonoBehaviour
{
    public static MicTest Instance { get; private set; }

    public float rmsVal;
    public float dbVal;
    public float pitchVal;

    private const int QSamples = 256;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.00002f;

    float[] _samples;

    private int pitchSamplesInd;
    private int _numOfPitchSamples = 150;
    private float[] _lastPitchSamples;
    
    private float[] _spectrum;
    private float _fSample;
    private string _device;
    private bool _isInitialized;
    
    private AudioSource audioSrc;
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    
    void InitMic(){
        // if(_device == null) _device = Microphone.devices[0];
        // audioSrc.clip = Microphone.Start(_device, true, 10, 44100);
        GameObject a = new GameObject("AudioSource");
        audioSrc = a.AddComponent<AudioSource>();
        Instantiate(a);

        string deviceName = Microphone.devices[0];
        audioSrc.clip = Microphone.Start(deviceName, true, 1000, 44100);
        audioSrc.volume = 0.01f;
        while (!(Microphone.GetPosition(null) > 0)) { }

        audioSrc.Play();
    }
 
    void StopMicrophone()
    {
        Microphone.End(_device);
    }

    void Start()
    {
        _lastPitchSamples = new float[_numOfPitchSamples];
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;
        
        InitMic();
        // GameObject a = new GameObject("AudioSource");
        // audioSrc = a.AddComponent<AudioSource>();
        // Instantiate(a);
        //
        // string deviceName = Microphone.devices[0];
        // // audioSrc.clip = Microphone.Start(deviceName, true, 1000, 44100);
        // audioSrc.volume = 0.01f;
        // while (!(Microphone.GetPosition(null) > 0)) { }
        //
        // audioSrc.Play();
    }

    private void Update()
    {
        AnalyzeSound();
    }

    void FixedUpdate()
    {

        // Debug.Log("RMS: " + rmsVal.ToString("F2"));
        //Debug.Log(dbVal.ToString("F1") + " dB");
        Debug.Log(pitchVal.ToString("F0") + " Hz");
    }



    public float CheckPitchSamples(float startValue, float endValue, int samplesNum = 50)
    {
        float sum = 0;

        int insideCounter = 0;
        
        //Debug.Log(_lastPitchSamples.Count);
        foreach (var lastPitchSample in _lastPitchSamples)
        {
            if (lastPitchSample >= startValue && lastPitchSample <= endValue)
            {
                sum += lastPitchSample;
                insideCounter++;
            }
           
            if (insideCounter >= samplesNum)
                return sum / samplesNum;
        }

        return sum / samplesNum;
    }
    

    void AnalyzeSound()
    {
        int i;

        /*audioSrc.GetOutputData(_samples, 0); // fill array with samples
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        
        rmsVal = Mathf.Sqrt(sum / QSamples); // rms = square root of average
        dbVal = 20 * Mathf.Log10(rmsVal / RefValue); // calculate dB
        if (dbVal < -160) dbVal = -160; // clamp it to -160dB min*/
        
        // get sound spectrum
        audioSrc.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        {
            // find max 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max
        }

        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < QSamples - 1)
        {
            // interpolate index using neighbours
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }

        pitchVal = freqN * (_fSample / 2) / QSamples; // convert index to frequency
        
        _lastPitchSamples[pitchSamplesInd % _numOfPitchSamples] = pitchVal;
        pitchSamplesInd++;

    }
    
    void OnEnable()
    {
        // InitMic();
        _isInitialized=true;
    }
 
    //stop mic when loading a new level or quit application
    void OnDisable()
    {
        StopMicrophone();
    }
 
    void OnDestroy()
    {
        StopMicrophone();
    }
 
 
    // make sure the mic gets started & stopped when application gets focused
    void OnApplicationFocus(bool focus) {
        if (focus)
        {
            //Debug.Log("Focus");
         
            if(!_isInitialized){
                //Debug.Log("Init Mic");
                InitMic();
                _isInitialized=true;
            }
        }      
        if (!focus)
        {
            //Debug.Log("Pause");
            StopMicrophone();
            //Debug.Log("Stop Mic");
            _isInitialized=false;
         
        }
    }
}

