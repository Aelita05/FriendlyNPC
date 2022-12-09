using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public float PlayerLoseDistance = 5f;
    private GameObject player;
    private Quaternion OriginalRotation;

    public void Interact()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();

        player = FindObjectOfType<PlayerMovement>().gameObject;
        OriginalRotation = transform.rotation;

        CancelInvoke();
        LookAtPlayer();
    }

    private void LookAtPlayer() // Katsoo pelaajaa p�in kunnes h�n l�htee alueelta
    {
        if((player.transform.position - transform.position).magnitude < PlayerLoseDistance) // Player is in range
        {
            // Kattoo pelaajaa p�in, mutta ignooraa pelaajan korkeuden
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            Invoke("LookAtPlayer", 0.1f);
        }
        else
        {
            transform.rotation = OriginalRotation;
        }
    }

    [ExecuteInEditMode] // Pirt�� PlayerLoseDistancen kokoisen pallon
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, PlayerLoseDistance);
    }
}
