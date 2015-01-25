using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProcessedElements : MonoBehaviour {

    public int friendship, laughter, nostalgia, fulfillment;
    public float gravity;
    public ParticleSystem ps;
    public Color frColor, lColor, nColor, fuColor;
    public float amountPerElement;
    public List<Color> colors = new List<Color>();

	// Update is called once per frame
	void Update () {
        var particles = new ParticleSystem.Particle[ps.particleCount];
        int sum = friendship + laughter + nostalgia + fulfillment;
        ps.emissionRate = amountPerElement * sum;
        ps.startSpeed = 5 * sum;
        ps.GetParticles(particles);
      

        for (int i = 0; i < particles.Length; i++)
        {
            var thing = particles[i];
            float distanceToCenter = Vector3.Distance(thing.position, transform.position);
            Vector3 directionToCenter = (transform.position - thing.position).normalized;
            thing.velocity = thing.velocity + ((gravity / distanceToCenter * distanceToCenter) * directionToCenter);

            int colorIndex = Random.Range(0, sum);

            thing.color = colors[colorIndex];
            particles[i] = thing;
        }

        ps.SetParticles(particles, particles.Length);
	}
}
