using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class CollisionTest : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"OnCollisionEnter : {collision.gameObject.name}");
           MovePower movePower = collision.gameObject.GetComponent<MovePower>();
            if (movePower != null)
            {
                movePower.Moveleft(200f);
            }
        }
        private void OnCollisionStay(Collision collision)
        {
            Debug.Log($"OnCollisionStay : {collision.gameObject.name}");
        }
        private void OnCollisionExit(Collision collision)
        {
            Debug.Log($"OnCollisionExit : {collision.gameObject.name}");
            MovePower movePower = collision.gameObject.GetComponent<MovePower>();
            if (movePower != null)
            {
                movePower.Moveleft(200f);
            }
        }
    }

}
