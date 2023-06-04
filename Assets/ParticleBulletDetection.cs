using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBulletDetection : MonoBehaviour
{
    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;
    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        if (other.CompareTag("Player")){
            Debug.Log(other.name + ": " + collisionEvents[0].velocity);

        }

        //arrowSystem.TargetHit(collisionEvents[0].velocity);
    }

}
