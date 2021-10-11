using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound Collection")]
public class SoundCollection : ScriptableObject
{
    
    public List<AudioClip> audioClips;
    [Range(0,1)]
    [SerializeField] public float volume;
    public void PlayAudioClip(AudioSource source, int index)
    {
        if(audioClips!=null&&audioClips.Count>0&&source!=null)
        {
            source.clip = audioClips[index];
            source.Play();
        }
      
    }
    public void PlayAudioClipUnitlEndByIndex(AudioSource source, int index)
    {

        if (audioClips != null && audioClips.Count > 0 && source != null&&!source.isPlaying)
        {
            source.loop = true;
            source.clip = audioClips[index];
            source.Play();
        }
    }
    public void PlayOnDisable(int index, Transform transform)
    {
        AudioSource.PlayClipAtPoint(audioClips[index], transform.position);
        GameObject.Find("One shot audio").transform.SetParent(Camera.main.transform);
        
    }
    public void SetVolume(float newValue)
    {
        volume = newValue;
    }
}
