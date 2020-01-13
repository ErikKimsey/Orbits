using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioRecorder : MonoBehaviour {
  
  AudioSource m_AudioSrc;

  /**
   NEEDS:
   - AudioClip,
   - AudioSource,
   - Microphone,
   - bool permission,
   - float[] for audioBuffer64, audioBand,
   - bool if mic is detected (Microphone.devices.length > 0)
  */
  private void Start() {
    m_AudioSrc = GetComponent<AudioSource>();
    m_AudioSrc.clip = Microphone.Start("Built-In Microphone", true, 30, AudioSettings.outputSampleRate);
    m_AudioSrc.loop = true;
    while(!(Microphone.GetPosition(null) > 0)){}
    m_AudioSrc.Play();
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