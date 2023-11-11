using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Died : MonoBehaviour
{
    public Camera losersCam;
    // This method is called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the collision involves a specific tag or object.
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("found player");
            // Call your function here.
            Transform otherTransform = collision.gameObject.transform;

            // Get a child by name
            Transform childByName = otherTransform.Find("MainCamera");
            Losed(childByName);
            PhotonNetwork.Destroy(collision.gameObject);
        }else{
            Debug.Log("not found player");
        }
    }

    // Your custom function to be called on collision.
    private void Losed(Transform childByName)
    {
        Debug.Log("Loser");
        //teleport his camera
        // childByName.position = new Vector3(0, 1, 0);
        losersCam.gameObject.SetActive(true);
    }
}
