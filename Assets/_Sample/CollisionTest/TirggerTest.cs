using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MySample
{
    public class TirggerTest : MonoBehaviour
    {
       
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"OnTriggerEnter : {other.name}");
            MovePower movePower = other.GetComponent<MovePower>();
            if( movePower != null )
            {
                movePower.MoveRight(200f);
                movePower.ColorChage(Color.red);
            }
            
        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log($"OnTriggerStay : {other.name}");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"OnTriggerExit : {other.name}");
            MovePower movePower = other.GetComponent<MovePower>();
            if (movePower != null)
            {
                movePower.MoveRight(200f);
                movePower.ResetColor();
            }
        }
    }
}
