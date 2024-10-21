using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class AnimatiorBlendTest : MonoBehaviour
    {
        #region Variables
        //이동
        [SerializeField] private float moveSpeed = 5f;

        //입력값
        private float moveX;
        private float moveY;

        private Animator playerAnimation;
        #endregion

        void Start()
        {
            playerAnimation = GetComponent<Animator>();
        }

        void Update()
        {
            //입력 처리
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            //이동, 방향, 속도
            Vector3 dir = new Vector3 (moveX, 0f, moveY);
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
            //animationMove();
            AniamtionBlendTest();
        }
        private void AniamtionBlendTest()
        {
            playerAnimation.SetFloat("MoveX", moveX);
            playerAnimation.SetFloat("MoveY", moveY);
        }
        /*   void animationMove()
           {
               if(moveX == 0f && moveY == 0f)
               {
                   playerAnimation.SetInteger("MoveState", 0);
               }
               else if(moveY > 0f)
               {
                   playerAnimation.SetInteger("MoveState", 1);
               }
               else if(moveY < 0f)
               {
                   playerAnimation.SetInteger("MoveState", 2);
               }
               else if (moveX > 0f)
               {
                   playerAnimation.SetInteger("MoveState", 3);
               }
               else if (moveX < 0f)
               {
                   playerAnimation.SetInteger("MoveState", 4);
               }
           }*/
    }
}
