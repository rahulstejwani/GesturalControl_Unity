using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gest2World : MonoBehaviour
{
    private ParticleSystem particles;
    Vector3 lefthandpos = Vector3.zero;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        Gesture.gen.drawLandmarks = false;
        particles = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        sound = GameObject.Find("Particle System").GetComponent<AudioSource>();
    }


    void Update()
    {
        var ps = particles.main;
        lefthandpos = new Vector3(0, 0, 0);
        for (int i = 0; i < 20; i++)
        {
            lefthandpos = lefthandpos - Gesture.gen.lefthandpos[i];
        }
        lefthandpos = lefthandpos / 20;

        ps.startSpeed = 1+ lefthandpos.y*30;
        ps.startColor = new Color(Gesture.gen.righthandpos[0].x, Gesture.gen.righthandpos[0].y, Gesture.gen.righthandpos[0].z) ;
        // Control audio
        //sound.pitch = Mathf.Abs(Gesture.gen.righthandpos[0].y) + Mathf.Abs(Gesture.gen.righthandpos[9].y)/2 * 1.5f;
        //sound.volume = (1 - (Mathf.Abs(Gesture.gen.righthandpos[0].x) + Mathf.Abs(Gesture.gen.righthandpos[9].x)) / 2 * 1.5f) + 0.5f;
        sound.pitch = (Mathf.Abs(1 - (Mathf.Abs(Gesture.gen.righthandpos[0].y) + Mathf.Abs(Gesture.gen.righthandpos[9].y))/2)) * 1.5f;
        sound.volume = (Mathf.Abs(1 - (Mathf.Abs(Gesture.gen.righthandpos[0].x) + Mathf.Abs(Gesture.gen.righthandpos[9].x)) / 2 * 1.5f)) + 0.5f;

        //sound.pitch = Mathf.Abs(Gesture.gen.righthandpos[0].y) * 1.5f;

        //sound.pitch = Mathf.Max(0, 1 - (Mathf.Abs(Gesture.gen.righthandpos[0].y) + Mathf.Abs(Gesture.gen.righthandpos[9].y)) / 2 * 1.5f);
        //sound.volume = Mathf.Max(0, 1 - (Mathf.Abs(Gesture.gen.righthandpos[0].x) + Mathf.Abs(Gesture.gen.righthandpos[9].x)) / 2 * 1.5f) + 0.5f;
    }
}
