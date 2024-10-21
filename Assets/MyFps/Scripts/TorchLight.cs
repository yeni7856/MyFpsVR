using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class TorchLight : MonoBehaviour
    {
        #region Variables
        public Transform torchLight;
        private Animator animator;

        //1초타이머
        private int lightMode;
        #endregion
        
        void Start()
        {
            animator = torchLight.GetComponent<Animator>();
            lightMode = 0;

            InvokeRepeating("LightAnimation", 0f, 1f);
        }

        
        void Update()
        {
            //1초마다 1번씩 랜덤한 라이트 애니메이션을 플레이
            /*if(lightMode == 0)
            {
                StartCoroutine(LightAnim());
            }*/
        }

        IEnumerator LightAnim()
        {
            lightMode = Random.Range(1,4);
            animator.SetInteger("LightMode", lightMode);

            /*switch (lightMode)
            {
                case 1:
                    animator.SetInteger("LightMode", 1);
                    break;
                case 2:
                    animator.SetInteger("LightMode", 2);
                    break;
                case 3:
                    animator.SetInteger("LightMode", 3);
                    break;
            }*/
            yield return new WaitForSeconds(1.0f);
            lightMode = 0;
        }
        //반복 함수
        private void LightAnimation()
        {
            lightMode = Random.Range(1, 4);
            animator.SetInteger("LightMode", lightMode);
        }
    }

}
