using UnityEngine;

    /// <summary>
    /// Sample test interaction: changes colour when interacted with.
    /// </summary>
public class Interactable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Player interacted with: " + gameObject.name);
        GetComponent<SpriteRenderer>().color = Color.green; // example action
    }
}
