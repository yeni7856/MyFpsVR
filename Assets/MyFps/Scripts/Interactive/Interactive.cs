using TMPro;
using UnityEngine;

namespace MyFps
{
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        private  float theDistance;

        public GameObject ActionUI;
        public TextMeshProUGUI actionTextUI;
        [SerializeField] private string actionText = "Action Text";
        public GameObject extraCross;
        #endregion

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        private void OnMouseOver()
        {
            if (theDistance <= 2f)
            {
                //PlayerCasting.distanceFromTarget
                ShowActionUI();

                if (Input.GetButton("Action"))
                {
                    HideActionUI();

                    //Action
                    DoAction();
                }
            }
            else
            {
                HideActionUI();
            }
        }
        void OnMouseExit()
        {
            HideActionUI();
        }
         void ShowActionUI()
        {
            ActionUI.SetActive(true);
            actionTextUI.text = actionText;
            extraCross.SetActive(true);
        }
       void HideActionUI()
        {
            ActionUI.SetActive(false);
            actionTextUI.text = "";
            extraCross.SetActive(false);
        }
    }
}
