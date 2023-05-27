using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public string keyItemTag = "KeyItem"; // Tag do objeto chave
    public AudioClip soundClip; // Som a ser reproduzido

    private AudioSource audioSource;

    private void Start()
    {
        // Obtém o componente AudioSource do objeto atual
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger possui a tag "KeyItem"
        if (other.CompareTag(keyItemTag))
        {
            Debug.Log("Objeto chave detectado!");
            

            // Reproduz o som
            if (audioSource != null && soundClip != null)
            {
                audioSource.PlayOneShot(soundClip);
            }

            // Desativa o objeto para que ele desapareça
            other.gameObject.SetActive(false);
        }
    }
}


