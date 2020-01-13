using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(AudioSource))]
public class AudioRecorder : MonoBehaviour {
  
  //  - Microphone,
  AudioSource _AudioSrc;

  
  //  NEEDS:
  public AudioClip _audioClip;
  public bool _useMic;
  private bool _hasPermission;


  //  - - 
  //  - float[] for: audioBandBuffer, audioBand,
  private float[] _audioBand = new float[8];
  private float[] _audioBandBuffer = new float[8];

  //  - - 
  //  - float[512] for: samplesLeft, samplesRight

  private float[] _audioSample = new float[512];
  private float[] _sampleLeft = new float[512];
  private float[] _sampleRight = new float[512];

  //  - - 
  //  - float[8] for: freqBand, bandBuffer, bufferDecrease, freqBandPeak,
  float[] _freqBand = new float[8];
  float[] _bandBuffer = new float[8];
  float[] _bufferDecrease = new float[8];
  float[] _freqBandPeak = new float[8];

  //  - -
  //  - bool if mic is detected (Microphone.devices.length > 0),
  private bool _micDetected;

  //  - -
  //  - public float _Amplitude, _AmplitudeBuffer,
  //  - public float _AmplitudePeak,
  //  - public float _audioProfile
  private float _Amplitude, _AmplitudeBuffer;
  private float _AmplitudePeak;
  private float _audioProfile;

  // - - 
  //  - public enum _channel {Stereo, Left, Right}
  //  - public _channel channel = new _channel();
  private enum _Channel {Stereo, Left, Right};
  private _Channel channel = new _Channel();

  //  - -
  // Audio64:
  //  - freqBand64, bandBuffer64, bufferDecrease64, freqBandPeak64, audioBandBuffer64, audioBand64
  private float[] _freqBand64 = new float[64];
  private float[] _bandBuffer64 = new float[64];
  private float[] _bufferDecrease64 = new float[64];
  private float[] _freqBandPeak64 = new float[64];
  private float[] _audioBand64 = new float[64];
  private float[] _audioBandBuffer64 = new float[64];



  private void Start() {
    _AudioSrc = GetComponent<AudioSource>();
    _AudioSrc.loop = true;
    while(!(Microphone.GetPosition(null) > 0)){}
    // _AudioSrc.Play();
  }

  private void GetPermission(){

  }

  private void GetMic(){
    if(Microphone.devices.ToString().Length > 0){
      _AudioSrc.clip = Microphone.Start("Built-In Microphone", true, 30, AudioSettings.outputSampleRate);
    }
  }

  private void GetSampleData(){
    _AudioSrc.GetSpectrumData(_audioSample, 0, FFTWindow.BlackmanHarris);
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