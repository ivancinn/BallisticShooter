# Simulador Balístico

## Controles e Interfaz
- **Ángulo de disparo**: Ajustable mediante el slider superior (0° a 90°).
- **Fuerza (Impulso)**: Ajustable mediante el slider central.
- **Masa del proyectil**: Ajustable mediante el slider inferior.
- **Botón "disparar"**: Dispara el proyectil basado en los parámetros actuales.

## Criterios de Evaluación Cubiertos
1. **Físicas Nativas**: Movimiento y colisión gobernados 100% por el motor de Unity (`AddForce`, `ForceMode.Impulse`).
2. **Estructuras Destructibles**: Objetivos construidos con `FixedJoint` y `HingeJoint`. Configurados con `Break Force` para mantener estabilidad en reposo y ceder ante impactos contundentes.
3. **Registro y Telemetría**: El sistema captura en consola y UI el tiempo de vuelo, punto de impacto exacto, velocidad relativa en el choque y magnitud del impulso.

## Requisitos de Sistema
- **Motor**: Unity Unity 6.4 (6000.4.5f1)
- **Plataforma**: PC Standalone / WebGL

## Video
- **Link**: https://youtu.be/_fckBQ1WuiY
