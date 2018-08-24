using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

    [SerializeField]
    int PlayerId;

	void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
            gameObject.SendMessageUpwards("PlayerScored", PlayerId);
        }
    }
}
