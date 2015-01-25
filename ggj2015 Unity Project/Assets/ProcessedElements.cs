using UnityEngine;
using System.Collections;

public class ProcessedElements : MonoBehaviour {

    public int friendship, laughter, nostalgia, fulfillment;
    public float gravity;
    public ParticleSystem ps;
    public Color frColor, lColor, nColor, fuColor;

	// Update is called once per frame
	void Update () {
        var particles = new ParticleSystem.Particle[ps.particleCount];
        
        ps.GetParticles(particles);

        for (int i = 0; i < particles.Length; i++)
        {
            var thing = particles[i];
            float distanceToCenter = Vector3.Distance(thing.position, transform.position);
            Vector3 directionToCenter = (transform.position - thing.position).normalized;
            thing.velocity = thing.velocity + ((gravity / distanceToCenter * distanceToCenter) * directionToCenter);

            particles[i] = thing;
        }

        ps.SetParticles(particles, particles.Length);
	}
}
