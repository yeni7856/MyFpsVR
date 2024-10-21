using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region
        public GameObject theDoor;      //문
        public AudioSource doorBang;    //문 열기 사운드

        public AudioSource bgm01;   //메인씬 1 배경음
        public AudioSource bgm02;   //적 등장 사운드

        public GameObject theRobot;     //적
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
            //Debug.Log("Triggered by: " + other.gameObject.name);
        }
        IEnumerator PlaySequence()
        {
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            //문 사운드
            bgm01.Stop();
            doorBang.Play();

            //Enemy 활성화
            theRobot.SetActive(true);
            yield return new WaitForSeconds(1f); //1초후에

            //Enemy 등장 사운드
            bgm02.Play();

            //Enemy 타겟을 향해 걷기
            RobotController robot = theRobot.GetComponent<RobotController>();
            if(robot != null )
            {
                robot.SetState(RobotState.R_Walk);
            }

           //트리거 킬
            Destroy(gameObject);
        }
    }
}
