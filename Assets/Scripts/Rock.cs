using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource boulderSmashAudioSource;
    [SerializeField] float collisionCooldown = 1f;

    CinemachineImpulseSource cinemachineImpulseSource;

    float collisionTimer = 0f;

    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update() 
    {
        collisionTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(collisionTimer < collisionCooldown) return;
        FireImpulse();
        CollisionFX(other);

        collisionTimer = 1f;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shackIntensity = 1f / distance;
        shackIntensity = Mathf.Min(shackIntensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(shackIntensity);
    }

    void CollisionFX(Collision other)
    {
        // build in methods!!!
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        boulderSmashAudioSource.Play();
    }
}
