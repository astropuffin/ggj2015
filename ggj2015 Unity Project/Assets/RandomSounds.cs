using UnityEngine;
using System.Collections;

public class RandomSounds : MonoBehaviour {

    public AudioClip[] sounds;


    public void playRandomSound()
    {
        var clip = sounds[Random.Range(0, sounds.Length)];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

}
