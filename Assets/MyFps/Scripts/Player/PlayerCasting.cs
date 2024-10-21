using UnityEngine;

namespace MyFps
{
    //정면에 있는 충돌체와의 거리 구하기
    public class PlayerCasting : MonoBehaviour
    {
        #region Variables
        public static float distanceFromTarget;
        [SerializeField] private float toTarget;        //거리 숫자 보기
        #endregion

        private void Start()
        {
            //초기화
            //distanceFromTarget = Mathf.Infinity;
        }
        void Update()
        {
            toTarget = distanceFromTarget;
            RaycastHit hit;
            //레이케스트 레이저 정면으로 쏨 
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distanceFromTarget = hit.distance;
            }
        }

        //Gizmo 그리기 : 카메라 위치에서 앞에 있는 충돌체까지 레이저 쏘는 선 그리기
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
            if (isHit)
            {
                Gizmos.DrawLine(transform.position, transform.position + transform.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
            }
        }
    }
}
