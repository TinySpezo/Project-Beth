using UnityEngine;
using TMPro;

public class ShowDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string dialogue;

    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("NPCinRange");
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            dialogueText.text = dialogue;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("NPCoutofRange");
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange)
            dialoguePanel.SetActive(true);
        else 
            dialoguePanel.SetActive(false);

    }
}
