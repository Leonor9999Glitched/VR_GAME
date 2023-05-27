using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBaterries : MonoBehaviour
{
    public string batteryTag = "Energy"; // Tag da bateria
    public int batteryNumber = 0;
    public GameObject targetObject;
    public Color emissiveColor = Color.green; // Cor emissiva desejada

    private MaterialPropertyBlock propertyBlock;

    private void Start()
    {
        propertyBlock = new MaterialPropertyBlock();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger possui uma determinada tag
        if (other.CompareTag(batteryTag))
        {
            Debug.Log("O objeto entrou na �rea de trigger!");
            batteryNumber += 1;

            Renderer objectRenderer = targetObject.GetComponent<Renderer>();

            if (objectRenderer != null)
            {
                // Define a nova cor no MaterialPropertyBlock
                propertyBlock.SetColor("_EmissionColor", emissiveColor);
                // Aplica o MaterialPropertyBlock ao Renderer do objeto
                objectRenderer.SetPropertyBlock(propertyBlock);
            }

            Destroy(other.gameObject);

            // Execute qualquer a��o adicional que voc� desejar quando o objeto entrar na �rea de trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
            // Verifica se o objeto que saiu do trigger possui uma determinada tag
            if (other.CompareTag("Energy"))
            {
                Debug.Log("O objeto saiu da �rea de trigger!");

                // Execute qualquer a��o adicional que voc� desejar quando o objeto sair da �rea de trigger
            }

    }

    

}
