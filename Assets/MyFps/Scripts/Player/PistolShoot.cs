using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        private Animator m_Animator;
        public ParticleSystem muzzle;
        public AudioSource pistolShoot;

        //public Transform camera;
        public Transform firPoint;
        //공격
        [SerializeField] private float attackDmg = 5f;

        //연사 딜레이
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;

        //임팩트
        public GameObject hitImpactPrefab;
        [SerializeField] private float impactForce = 10f;  //히트지점에 
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            m_Animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //슟
            if (Input.GetButtonDown("Fire1") && !isFire)
            {
                if(PlayerStats.Instance.UseAmmo(1) == true)
                {
                    StartCoroutine(Shoot());
                }
            }
        }
        IEnumerator Shoot()
        {
            isFire = true;
            //Vector3 screenPoint = Camera.main.WorldToScreenPoint(firPoint.position);
            //Ray ray = Camera.main.ScreenPointToRay(screenPoint);

            //내앞에 100안에 적이 있으면 적에게 데미지를 준다
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firPoint.position, firPoint.TransformDirection(Vector3.forward), out hit, maxDistance);
            if (isHit)
            {
                //Gizmos.DrawLine(firPoint.position, firPoint.forward * hit.distance);
                //적에게 데미지를 준다
                Debug.Log($"{hit.transform.name}적에게 대미지를준다");

                //임팩트 효과
                GameObject effGo = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                //GameObject effGo = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(firPoint.TransformDirection(Vector3.forward)));
                Destroy(effGo, 2f);
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
                }

                //데미지
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(attackDmg);
                }
                /*  RobotController robot = hit.transform.GetComponent<RobotController>();
                if(robot != null)
                {
                    robot.TakeDamage(attackDmg);
                }*/
            }

            m_Animator.SetTrigger("Fire");

            pistolShoot.Play();

            muzzle.gameObject.SetActive(true);

            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

            isFire = false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firPoint.position, firPoint.TransformDirection(Vector3.forward), out hit);
            if (isHit)
            {
                Gizmos.DrawLine(firPoint.position, firPoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firPoint.position, firPoint.forward * maxDistance);
            }
        }
    }
}
