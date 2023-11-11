using UnityEngine;
using Photon.Pun;

public class CheckOwner : MonoBehaviourPun
{
    private Photon.Realtime.Player ownerPlayer;

    // private void Start()
    // {
    //     // Check if this GameObject has a PhotonView
    //     if (photonView != null)
    //     {
    //         // Get the owner of the PhotonView
    //         ownerPlayer = photonView.Owner;

    //         // Check if an owner is assigned
    //         if (ownerPlayer != null)
    //         {
    //             // Display owner's information in the Inspector
    //             Debug.Log("Owner UserID: " + ownerPlayer.UserId);
    //             Debug.Log("Owner Nickname: " + ownerPlayer.NickName);
    //         }
    //         else
    //         {
    //             Debug.LogError("No owner assigned to PhotonView.");
    //         }
    //     }
    //     else
    //     {
    //         Debug.LogError("No PhotonView component found on this GameObject.");
    //     }
    // }
}
