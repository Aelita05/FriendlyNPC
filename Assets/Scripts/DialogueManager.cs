using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        DialogueBox.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Cursor.visible = false;
        DialogueBox.SetActive(false);
        Debug.Log("End of conversation.");
    }
}
