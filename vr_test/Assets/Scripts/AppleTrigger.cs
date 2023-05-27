using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTrigger : MonoBehaviour
{
    public string appleTag = "AppleG"; // Tag do objeto AppleG
    public GameObject audioPlayer; // Objeto com componente AudioSource para tocar o áudio
    public Animator animator; // Referência ao componente Animator para reproduzir a animação
    public MonoBehaviour scriptToActivate; // Script a ser ativado no outro objeto

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger possui a tag "AppleG"
        if (other.CompareTag(appleTag))
        {
            Debug.Log("Objeto AppleG encontrado!");

            // Toca o áudio
            if (audioPlayer != null && audioPlayer.TryGetComponent<AudioSource>(out var audioSource))
            {
                audioSource.Play();
            }

            // Reproduz a animação
            if (animator != null)
            {
                // Desativa a animação
                animator.enabled = true;
                animator.SetTrigger("CreatureMove");
            }

            else
            {
                // Desativa a animação
                animator.enabled = false;
            }

            // Ativa o script no outro objeto
            if (scriptToActivate != null)
            {
                scriptToActivate.enabled = true;
            }

            // Destroi o objeto
            Destroy(other.gameObject);
        }
    }
}



