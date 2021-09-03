using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class EnterTrigger : MonoBehaviour
{
    public PlayableDirector playableDirector001;
    public TimelineAsset timeline001;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        playableDirector001.Play();

    }

}
