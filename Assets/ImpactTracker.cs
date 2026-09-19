using UnityEngine;

public class ImpactTracker : MonoBehaviour
{
    private float startTime;
    private bool hasImpacted = false;

    public void BeginTracking()
    {
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ignoramos choques contra el propio cañón
        if (hasImpacted || collision.gameObject.name.Contains("Cañon") || collision.gameObject.name.Contains("FirePoint")) return;

        hasImpacted = true;

        float flightTime = Time.time - startTime;
        Vector3 impactPoint = collision.contacts[0].point;
        float relativeVel = collision.relativeVelocity.magnitude;
        float collisionImpulse = collision.impulse.magnitude;

        // Mandamos los datos al GameManager
        if (GameManager.Instancia != null)
        {
            GameManager.Instancia.RegistrarImpacto(flightTime, impactPoint, relativeVel, collisionImpulse);
        }
    }
}