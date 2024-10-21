using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        //플레이씬
        [SerializeField] private string loadToScene = "MainScene01";
        #endregion

        void Start ()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //페이드인 효과
            fader.FromFade();
        }
        public void Retry()
        {
           fader.FadeTo(loadToScene);
        }
        public void Menu()
        {
            Debug.Log("Goto Menu!!");
        }
    }

}
