using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps
{
    public class BFristTrigger : MonoBehaviour
    {

        public GameObject Player;
        public GameObject arrow;

        private float delayTime = 1f;

        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "Looks like a weapon on that table.";

        public AudioSource line03;

        
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(ArrowDelay());
        }
        IEnumerator ArrowDelay()
        {
            Player.GetComponent<FirstPersonController>().enabled = false;

            textBox.gameObject.SetActive(true);
            textBox.text = sequence;
            line03.Play();

            yield return new WaitForSeconds(2f);

            arrow.SetActive(true);

            yield return new WaitForSeconds(delayTime);

            textBox.text = "";
            textBox.gameObject.SetActive(false);
           
            Player.GetComponent<FirstPersonController>().enabled = true;
            //transform.GetComponent<BoxCollider>().enabled = false;

            //트리거킬
            Destroy(gameObject);
        }
    }

}
