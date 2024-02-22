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
        var emission = particles.emission;
        lefthandpos = new Vector3(0, 0, 0);
        for (int i = 0; i < 20; i++) {
            lefthandpos = lefthandpos - Gesture.gen.lefthandpos[i];
        }

        lefthandpos = lefthandpos / 20;

        ps.startSpeed = 10 + (1 - (Gesture.gen.lefthandpos[0].y + Gesture.gen.lefthandpos[9].y)/2) * 40;
        emission.rateOverTime = (1 - (Gesture.gen.lefthandpos[0].x + Gesture.gen.lefthandpos[9].x)/2) * 100;

        // Control audio
        sound.pitch = 1 - (Gesture.gen.righthandpos[0].y + Gesture.gen.righthandpos[9].y)/2;
        sound.volume= Mathf.Abs(((Mathf.Abs(Gesture.gen.righthandpos[0].x) + Mathf.Abs(Gesture.gen.righthandpos[9].x)) / 2 * 1.5f) + 0.5f);


        if (GameController.isGameOver)
        {
            Destroy(this.gameObject);
        }
    }

    public Vector3 getRightPos()
    {
        return new Vector3(((1 - Gesture.gen.righthandpos[9].x)*100)-50, ((1 - Gesture.gen.righthandpos[9].y)*50)-25, 0); 
    }
    public Vector3 getLeftPos()
    {
        return new Vector3(((1 - Gesture.gen.lefthandpos[9].x)*100)-50, ((1 - Gesture.gen.lefthandpos[9].y)*50)-25, 0); 
    }
}
