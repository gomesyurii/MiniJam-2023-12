using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProportion : MonoBehaviour
{
    public bool proportionCanChange = false;

    private Dictionary<GameObject, Vector3> originalSizes = new Dictionary<GameObject, Vector3>();
    private bool proportionsChanged = false;

    void Start()
    {
        // Obtenha todos os objetos na cena
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        // Percorra cada objeto
        foreach (GameObject obj in allObjects)
        {
            // Se o objeto não for o jogador
            if (!obj.CompareTag("Player"))
            {
                // Armazene o tamanho original do objeto
                originalSizes[obj] = obj.transform.localScale;
            }
        }
    }

    void Update()
    {
        if (proportionCanChange && !proportionsChanged)
        {
            Debug.Log("Being called proportion");

            // Obtenha todos os objetos na cena
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

            // Percorra cada objeto
            foreach (GameObject obj in allObjects)
            {
                // Se o objeto não for o jogador
                if (!obj.CompareTag("Player"))
                {
                    // Escolha aleatoriamente se o tamanho do objeto deve ser aumentado ou diminuído
                    float scaleChange = Random.Range(-1f, 1f);

                    // Altere o tamanho do objeto
                    obj.transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);
                }
            }

            // Depois de alterar a proporção, redefina proportionCanChange para false
            proportionsChanged = true;
        }
        else if (!proportionCanChange && proportionsChanged)
        {
            // Se proportionCanChange for false, restaure os tamanhos originais
            foreach (KeyValuePair<GameObject, Vector3> entry in originalSizes)
            {
                entry.Key.transform.localScale = entry.Value;
            }

            // Redefina proportionsChanged para false
            proportionsChanged = false;
        }
    }

    void OnMouseDown()
    {
        // Função chamada quando o objeto é clicado
        Debug.Log("Objeto clicado!");
        proportionCanChange = !proportionCanChange;
    }
}
