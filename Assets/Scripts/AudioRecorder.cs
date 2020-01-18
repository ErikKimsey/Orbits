using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(AudioSource))]
public class AudioRecorder : MonoBehaviour {
  
  public bool _useMic;
  public bool _hasPermission;


  //  - - 
  //  - float[] for: audioBandBuffer, audioBand,
  public float[] _audioBand = new float[8];
  public float[] _audioBandBuffer = new float[8];

  //  - - 
  //  - float[512] for: samplesLeft, samplesRight

  public static float[] _audioSamples = new float[512];
  public float[] _sampleLeft = new float[512];
  public float[] _sampleRight = new float[512];

  //  - - 
  //  - float[8] for: freqBand, bandBuffer, bufferDecrease, freqBandPeak,
  public float[] _freqBand = new float[8];
  float[] _bandBuffer = new float[8];
  float[] _bufferDecrease = new float[8];
  float[] _freqBandPeak = new float[8];

  //  - -
  //  - bool if mic is detected (Microphone.devices.length > 0),
  public bool _micDetected;

  //  - -
  //  - public float _Amplitude, _AmplitudeBuffer,
  //  - public float _AmplitudePeak,
  //  - public float _audioProfile
  public float _Amplitude, _AmplitudeBuffer;
  public float _AmplitudePeak;
  public float _audioProfile;

  // - - 
  //  - public enum _channel {Stereo, Left, Right}
  //  - public _channel channel = new _channel();
  public enum _Channel {Stereo, Left, Right};
  public _Channel channel = new _Channel();

  //  - -
  // Audio64:
  //  - freqBand64, bandBuffer64, bufferDecrease64, freqBandPeak64, audioBandBuffer64, audioBand64
  public float[] _freqBand64 = new float[64];
  public float[] _bandBuffer64 = new float[64];
  public float[] _bufferDecrease64 = new float[64];
  public float[] _freqBandPeak64 = new float[64];
  public float[] _audioBand64 = new float[64];
  public float[] _audioBandBuffer64 = new float[64];

  // ------------------- >>
  // ------------------- >>
  // ------------------- >>
  public AudioSource _AudioSrc;

  public AudioClip _audioClip;
  // ------------------- << 
  // ------------------- << 
  // ------------------- <<


  public void Start() {
    _AudioSrc = GetComponent<AudioSource>();
    _AudioSrc.loop = true;
  }

  public void PlayClip(){
    _AudioSrc.Play();
  }

  public void Update() {
    GetSampleData();
    MakeFrequencyBands();
    BandBuffer();
  }

  // public void GetPermission(){}

  public void SetMic(){
    // if(Microphone.devices.ToString().Length > 0){
      // while ( !( Microphone.GetPosition( Microphone.devices[0] ) > 0 ) ) { }
      // _AudioSrc.clip = Microphone.Start(Microphone.devices[0], true, 10, AudioSettings.outputSampleRate);
    // }
  }

  public void BandBuffer(){
    for (int i = 0; i < 8; i++){
      if(_freqBand[i] > _bandBuffer[i]){
        _bandBuffer[i] = _freqBand[i];
        _bufferDecrease[i] = 0.005f;
      }
      if(_freqBand[i] < _bandBuffer[i]){
        _freqBand[i] = _bandBuffer[i];
        _bufferDecrease[i] *= 1.2f;
      }
    }
  }

  public void GetSampleData(){
    _AudioSrc.GetSpectrumData(_audioSamples, 0, FFTWindow.BlackmanHarris);
  }

  void MakeFrequencyBands() {
    /*
      *  22050 / 512 - 43hz per sample
      *  
      *  20 - 60hz
      *  60 - 250hz
      *  250 - 500hz
      *  2000 - 4000hz
      *  4000 - 6000hz
      *  6000 - 20000hz
      *  
      *  0 - 2 = 86hz
      *  1 - 4 = 172hz - 87-258
      *  2 - 8 = 344hz - 259-602
      *  3 - 16 = 688hz - 603-1290
      *  4 - 32 = 1376hz - 1291-2666
      *  5 - 64 = 2752hz - 2667-5418
      *  6 - 128 = 5504hz - 5419-10922
      *  7 - 256 = 11008hz - 10923-21930
      *  510
      */
    int count = 0;
    for(int i=0; i < 8; i++){
      float average = 0f;
      int sampleCount = (int)Mathf.Pow(2,i) * 2;

      if(i == 7){
        sampleCount += 2;
      }

      for(int j=0; j < sampleCount; j++){
        average += _audioSamples[count] * count + 1;
        count++;
      }

      average /= count;
      _freqBand[i] = average * 10;
      // Debug.Log(_freqBand[i]);
    }
  }

  /**
    - get permissions,
    - get microphone source,
    - if no permission, set default audio clip
    - if yes permission, begin recording,
    - set recording as audio clip,
    - make audio clip accessible 
  */


}