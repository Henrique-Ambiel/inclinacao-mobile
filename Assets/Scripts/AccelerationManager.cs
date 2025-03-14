using UnityEngine;

public class AccelerationManager : MonoBehaviour
{
    // Variável para armazenar a aceleração atual.
    private Vector3 accel;

    // Variável para armazenar a aceleração anterior, usada para suavizar as leituras.
    private Vector3 prev;

    // Fator de filtro usado para suavizar a aceleração. Controla a "inércia" do filtro.
    private const float kFilterFactor = 0.05f;

    // Matriz de calibração usada para ajustar a direção da aceleração.
    private Matrix4x4 calibrationMatrix;

    // Captura a aceleração no momento da calibração para comparar com a entrada do dispositivo.
    private Vector3 accelerationSnapshot;

    // Aceleracão final que será exposta, possivelmente em 2D.
    public Vector2 acceleration;

    // Método chamado no início da execução, inicializa a calibração.
    public void Start()
    {
        Calibrate();  // Chama o método Calibrate para ajustar a calibração do dispositivo.
    }

    // Método chamado a cada frame. Aqui ocorre a atualização da aceleração com base na entrada do dispositivo.
    public void Update()
    {
        // Atualiza a aceleração, suavizando a leitura com um filtro (usando a aceleração anterior).
        accel = Input.acceleration.normalized * kFilterFactor + (1.0f - kFilterFactor) * prev;

        // Armazena a aceleração atual para o próximo cálculo de suavização.
        prev = accel;

        // Atualiza a aceleração em X com base no valor da aceleração filtrada.
        acceleration.x = accel.x;

        // Aplica a calibração (ajuste da direção) à aceleração no eixo Y.
        acceleration.y = calibrationMatrix.MultiplyVector(accel).y;
    }

    // Método de calibração, ajusta a direção da aceleração conforme o dispositivo.
    public void Calibrate()
    {
        // Aceleração inicial é capturada e normalizada.
        accel = Input.acceleration.normalized;

        // Armazena a aceleração no momento da calibração.
        accelerationSnapshot = accel;

        // Cria uma rotação (Quaternion) para alinhar a aceleração com um vetor desejado.
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);

        // Cria uma matriz de transformação que representa a rotação necessária para alinhar a aceleração.
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1.0f, 1.0f, 1.0f));

        // Armazena a inversa dessa matriz de calibração para aplicar em atualizações futuras.
        calibrationMatrix = matrix.inverse;
    }
}
