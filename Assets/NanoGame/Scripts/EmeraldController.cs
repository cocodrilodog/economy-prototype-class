using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldController : MonoBehaviour
{

    #region Public Fields

    public GameManager GameManager;

    #endregion


    #region Unity Methods

    // This is called whenever something collides with this object
    private void OnCollisionEnter(Collision collision)
    {
        // I need to check if the collision was casued by the player
        if (collision.gameObject.tag == "Player")
        {
            // If so, I dissappear
            gameObject.SetActive(false);

            // Add score
            GameManager.AddScore(10);
        }
    }

    #endregion

}
