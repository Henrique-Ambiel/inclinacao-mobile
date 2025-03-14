using UnityEngine;

public class Control : MonoBehaviour
{
    // Referência ao componente AccelerationManager que gerencia a aceleração do dispositivo.
    public AccelerationManager myAccelerationManager;

    // Valor máximo do ângulo de rotação que pode ser aplicado, controlando o limite da rotação.
    public float maxAngle = 30;

    // Método chamado uma vez no início, você pode adicionar inicializações aqui se necessário.
    void Start()
    {
        
    }

    // Método chamado a cada frame. Aqui a rotação do objeto é atualizada com base na aceleração.
    void Update()
    {
        // Atualiza a rotação do objeto (transform) utilizando a aceleração gerenciada,
        // multiplicada pelo valor de maxAngle para controlar a magnitude da rotação.
        transform.eulerAngles = myAccelerationManager.acceleration * maxAngle;
    }
}
