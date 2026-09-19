using UnityEngine;
using TMPro; // Necesario para la UI de texto moderno
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia; // Para acceder fácilmente desde el proyectil

    [Header("Interfaz (UI)")]
    public GameObject panelReporte;
    public TextMeshProUGUI textoReporte;

    void Awake()
    {
        Instancia = this;
    }

    // El proyectil llama a esta función cuando choca
    public void RegistrarImpacto(float tiempo, Vector3 punto, float vel, float impulso)
    {
        StartCoroutine(GenerarReporteFinal(tiempo, punto, vel, impulso));
    }

    IEnumerator GenerarReporteFinal(float tiempo, Vector3 punto, float vel, float impulso)
    {
        // 1. Esperamos 3 segundos para que los bloques terminen de caer al piso
        yield return new WaitForSeconds(3f);

        // 2. Contamos las piezas derribadas
        int piezasCaidas = 0;
        TargetPiece[] todasLasPiezas = FindObjectsOfType<TargetPiece>();

        foreach (TargetPiece pieza in todasLasPiezas)
        {
            if (pieza.fueDerribada) piezasCaidas++;
        }

        // 3. Calculamos puntuación (ej: 100 pts por pieza caída)
        int puntuacion = piezasCaidas * 100;

        // 4. Armamos el texto del reporte
        string reporte = "--- REPORTE DE TIRO ---\n\n";
        reporte += $"Tiempo de vuelo: {tiempo:F2} segundos\n";
        reporte += $"Punto de impacto: {punto}\n";
        reporte += $"Velocidad relativa: {vel:F2} m/s\n";
        reporte += $"Impulso de colisión: {impulso:F2} Ns\n\n";
        reporte += $"Piezas derribadas: {piezasCaidas} de {todasLasPiezas.Length}\n";
        reporte += $"PUNTUACIÓN TOTAL: {puntuacion} pts";

        // 5. Mostramos el panel en pantalla
        textoReporte.text = reporte;
        panelReporte.SetActive(true);
    }

    // Se llama desde un botón "Reintentar" en el panel
    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}