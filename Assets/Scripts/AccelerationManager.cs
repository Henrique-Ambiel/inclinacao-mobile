using UnityEngine;

public class AccelerationManager : MonoBehaviour
{
    // Vari�vel para armazenar a acelera��o atual.
    private Vector3 accel;

    // Vari�vel para armazenar a acelera��o anterior, usada para suavizar as leituras.
    private Vector3 prev;

    // Fator de filtro usado para suavizar a acelera��o. Controla a "in�rcia" do filtro.
    private const float kFilterFactor = 0.05f;

    // Matriz de calibra��o usada para ajustar a dire��o da acelera��o.
    private Matrix4x4 calibrationMatrix;

    // Captura a acelera��o no momento da calibra��o para comparar com a entrada do dispositivo.
    private Vector3 accelerationSnapshot;

    // Acelerac�o final que ser� exposta, possivelmente em 2D.
    public Vector2 acceleration;

    // M�todo chamado no in�cio da execu��o, inicializa a calibra��o.
    public void Start()
    {
        Calibrate();  // Chama o m�todo Calibrate para ajustar a calibra��o do dispositivo.
    }

    // M�todo chamado a cada frame. Aqui ocorre a atualiza��o da acelera��o com base na entrada do dispositivo.
    public void Update()
    {
        // Atualiza a acelera��o, suavizando a leitura com um filtro (usando a acelera��o anterior).
        accel = Input.acceleration.normalized * kFilterFactor + (1.0f - kFilterFactor) * prev;

        // Armazena a acelera��o atual para o pr�ximo c�lculo de suaviza��o.
        prev = accel;

        // Atualiza a acelera��o em X com base no valor da acelera��o filtrada.
        acceleration.x = accel.x;

        // Aplica a calibra��o (ajuste da dire��o) � acelera��o no eixo Y.
        acceleration.y = calibrationMatrix.MultiplyVector(accel).y;
    }

    // M�todo de calibra��o, ajusta a dire��o da acelera��o conforme o dispositivo.
    public void Calibrate()
    {
        // Acelera��o inicial � capturada e normalizada.
        accel = Input.acceleration.normalized;

        // Armazena a acelera��o no momento da calibra��o.
        accelerationSnapshot = accel;

        // Cria uma rota��o (Quaternion) para alinhar a acelera��o com um vetor desejado.
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);

        // Cria uma matriz de transforma��o que representa a rota��o necess�ria para alinhar a acelera��o.
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1.0f, 1.0f, 1.0f));

        // Armazena a inversa dessa matriz de calibra��o para aplicar em atualiza��es futuras.
        calibrationMatrix = matrix.inverse;
    }
}
