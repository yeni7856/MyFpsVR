using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

namespace MyFps
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;
        private Animator doorAnim;
        private Collider colliderDoor;
        public AudioSource audioSource;
        public AudioSource bgm01;

        //플레이씬
        [SerializeField] private string loadToScene = "MainScene02";

        #endregion
        // Start is called before the first frame update
        void Start()
        {
            doorAnim = GetComponent<Animator>();
            colliderDoor = GetComponent<Collider>();
        }

        //마우스를 가져가면 액션 UI를 보여주기
        protected override void DoAction()
        {
            doorAnim.SetBool("IsOpen", true);
            colliderDoor.enabled = false;
            audioSource.Play();
            ChangeScene();
        }
        void ChangeScene()
        {
            bgm01.Stop();

            fader.FadeTo(loadToScene);
        }
    }

}
