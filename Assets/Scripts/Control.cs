using UnityEngine;

public class Control : MonoBehaviour
{
    // Refer�ncia ao componente AccelerationManager que gerencia a acelera��o do dispositivo.
    public AccelerationManager myAccelerationManager;

    // Valor m�ximo do �ngulo de rota��o que pode ser aplicado, controlando o limite da rota��o.
    public float maxAngle = 30;

    // M�todo chamado uma vez no in�cio, voc� pode adicionar inicializa��es aqui se necess�rio.
    void Start()
    {
        
    }

    // M�todo chamado a cada frame. Aqui a rota��o do objeto � atualizada com base na acelera��o.
    void Update()
    {
        // Atualiza a rota��o do objeto (transform) utilizando a acelera��o gerenciada,
        // multiplicada pelo valor de maxAngle para controlar a magnitude da rota��o.
        transform.eulerAngles = myAccelerationManager.acceleration * maxAngle;
    }
}
