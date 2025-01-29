using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioSource impactSound;
    public AudioClip ballImpactSound;    // Top çarpma sesi
    public AudioClip woodImpactSound;    // Tahta çarpma sesi
    public string objectType = "Ball";    // "Ball" veya "Wood" olarak ayarlanabilir

    void Start()
    {
        impactSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        float impactForce = collision.relativeVelocity.magnitude;
        impactSound.volume = impactForce / 10.0f;

        // Ses klibini obje tipine göre ayarla
        if (objectType == "Ball")
        {
            impactSound.clip = ballImpactSound;
        }
        else if (objectType == "Wood")
        {
            impactSound.clip = woodImpactSound;
        }

        impactSound.Play();
    }
} 