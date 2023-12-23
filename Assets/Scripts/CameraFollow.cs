using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador

    public Vector3 offset; // Ajuste de posição da câmera em relação ao jogador (pode ser ajustado no Editor)

    void LateUpdate()
    {
        if (player != null)
        {
            // Obtém a posição desejada da câmera em relação ao jogador
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            // Move suavemente a câmera em direção à posição desejada usando o método Lerp
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
        }
    }
}
