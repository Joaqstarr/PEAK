using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBulletDetection : MonoBehaviour
{
    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;
    SoldierData _data;
    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        _data = transform.root.GetComponent<SoldierStateManager>()._data;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        if (other.CompareTag("Player")){
            other.GetComponent<PlayerHealth>().Damage(_data.damage, transform.root.position, false);

        }

        //arrowSystem.TargetHit(collisionEvents[0].velocity);
    }

}
