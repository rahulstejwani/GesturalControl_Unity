using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gest2World : MonoBehaviour
{
    private ParticleSystem particles;
    Vector3 lefthandpos = Vector3.zero;
    AudioSource sound;

    void Start()
    {
        Gesture.gen.drawLandmarks = false;
        particles = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        sound = GameObject.Find("Particle System").GetComponent<AudioSource>();
    }


    void Update()
    {
        if (GameController.isGameOver)
        {
            sound.Stop();
            particles.Stop();
            return;
        }

        var ps = particles.main;
        lefthandpos = new Vector3(0, 0, 0);
        for (int i = 0; i < 20; i++)
        {
            lefthandpos = lefthandpos - Gesture.gen.lefthandpos[i];
        }
        lefthandpos = lefthandpos / 20;

        ps.startSpeed = 1+ lefthandpos.y*30;
        // Control audio
        sound.pitch = (Mathf.Abs(1 - (Mathf.Abs(Gesture.gen.righthandpos[0].y) + Mathf.Abs(Gesture.gen.righthandpos[9].y))/2)) * 1.5f;
        sound.volume = (Mathf.Abs(1 - (Mathf.Abs(Gesture.gen.righthandpos[0].x) + Mathf.Abs(Gesture.gen.righthandpos[9].x)) / 2 * 1.5f)) + 0.5f;
    }

    public Vector3 getPos()
    {
        return new Vector3(((1 - Gesture.gen.righthandpos[9].x)*100)-50, ((1 - Gesture.gen.righthandpos[9].y)*50)-25, 0); 
    }
}
