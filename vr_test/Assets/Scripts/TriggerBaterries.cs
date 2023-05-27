using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBaterries : MonoBehaviour
{
    public string batteryTag = "Energy"; // Tag da bateria
    public int batteryNumber = 0;
    public GameObject targetObject;
    public Color emissiveColor = Color.green; // Cor emissiva desejada

    public Animator animator; // Refer�ncia ao componente Animator
    public MonoBehaviour scriptToActivate; // Refer�ncia ao script a ser ativado

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
        if (other.CompareTag(batteryTag))
        {
            Debug.Log("O objeto saiu da �rea de trigger!");

            // Execute qualquer a��o adicional que voc� desejar quando o objeto sair da �rea de trigger
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryNumber == 3)
        {
            Debug.Log("N�mero de baterias atingido!");

            // Dispara a anima��o
            if (animator != null)
            {
                animator.SetTrigger("TriggerAnimation");
            }

            // Ativa o script
            if (scriptToActivate != null)
            {
                scriptToActivate.enabled = true;
            }
        }
    }
}

