using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DrowAmmoUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI ammoUIText;
        #endregion
        /*        private void OnEnable()             //세팅 되는 UI OnEnable 사용
                {

                }*/
        // Update is called once per frame
        void Update()
        {
            ammoUIText.text = PlayerStats.Instance.AmmoCount.ToString();
        }
    }
}
