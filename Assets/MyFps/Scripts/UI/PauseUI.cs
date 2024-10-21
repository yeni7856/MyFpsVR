using StarterAssets;
using UnityEngine;

namespace MyFps
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUI;
        private GameObject Player;
        #endregion

        private void Start()
        {
            Player = GameObject.Find("Player");
        }
        private void Update()
        {
            //
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Toggle();
            }
        }
        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);
            if (pauseUI.activeSelf)     //pause 창이 오픈 되었을때 , 사운드., Sequence 등등 의 문제 생각해야함
            {
                Player.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f;         
            }
            else
            {
                Player.GetComponent<FirstPersonController>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Time.timeScale = 1f;
            }
        }
        public void Menu()
        {
            Time.timeScale = 1f;
            Debug.Log("Goto Menu !!!!!");
        }
    }

}
