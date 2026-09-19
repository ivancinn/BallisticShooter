using UnityEngine;
using UnityEngine.UI;

public class BallisticShooter : MonoBehaviour
{
    [Header("Controles de Interfaz (UI)")]
    public Slider angleSlider;
    public Slider forceSlider;
    public Slider massSlider;

    [Header("Configuración del Proyectil")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Visuales del Cañón")]
    [Tooltip("El objeto que va a rotar visualmente (el tubo del cañón)")]
    public Transform pivoteCañon;
    [Tooltip("Activa esto si el cañón rota hacia abajo en lugar de hacia arriba")]
    public bool invertirRotacionEjeX = true;

    [Header("Ajustes de Potencia")]
    public float multiplicadorFuerza = 100f;

    void Update()
    {
        if (pivoteCañon != null && angleSlider != null)
        {
            float anguloVisual = angleSlider.value;

            if (invertirRotacionEjeX)
            {
                anguloVisual = -anguloVisual;
            }

            // ¡AQUÍ ESTÁ EL CAMBIO! 
            // Pasamos "anguloVisual" al tercer espacio, que corresponde al eje Z.
            pivoteCañon.localEulerAngles = new Vector3(0f, 0f, anguloVisual);
        }
    }

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        rb.mass = massSlider.value;

        Vector3 direccionAdelante = firePoint.forward;
        direccionAdelante.y = 0;
        direccionAdelante.Normalize();

        float angleInRadians = angleSlider.value * Mathf.Deg2Rad;

        Vector3 fireDirection = (direccionAdelante * Mathf.Cos(angleInRadians) + Vector3.up * Mathf.Sin(angleInRadians)).normalized;

        float fuerzaTotal = forceSlider.value * multiplicadorFuerza;
        rb.AddForce(fireDirection * fuerzaTotal, ForceMode.Impulse);

        ImpactTracker tracker = projectile.AddComponent<ImpactTracker>();
        tracker.BeginTracking();
    }
}