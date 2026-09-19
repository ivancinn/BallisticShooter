using UnityEngine;

public class TargetPiece : MonoBehaviour
{
    public bool fueDerribada = false;

    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    void Start()
    {
        // Guardamos dónde y cómo estaba el bloque al inicio
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        if (!fueDerribada)
        {
            // Si el bloque se mueve más de medio metro o se inclina más de 30 grados, cuenta como derribado
            if (Vector3.Distance(posicionInicial, transform.position) > 0.5f ||
                Quaternion.Angle(rotacionInicial, transform.rotation) > 30f)
            {
                fueDerribada = true;
            }
        }
    }
}