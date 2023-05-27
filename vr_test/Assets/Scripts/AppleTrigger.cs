using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTrigger : MonoBehaviour
{
    public string appleTag = "AppleG"; // Tag do objeto AppleG
    public GameObject audioPlayer; // Objeto com componente AudioSource para tocar o áudio
    public Animator animator; // Referência ao componente Animator para reproduzir a animação

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
                animator.SetTrigger("PlayAnimation");
            }

            // Destroi o objeto
            Destroy(other.gameObject);
        }
    }
}


