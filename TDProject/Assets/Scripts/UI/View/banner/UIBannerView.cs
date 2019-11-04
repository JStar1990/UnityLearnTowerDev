using UnityEngine;
using UnityEngine.UI;

namespace Dev.mvc
{
    public class UIBannerView : UIBase
    {
        public GameObject LaserToggle;
        public GameObject MissileToggle;
        public GameObject StandardToggle;
        protected override void _addGameListen()
        {
            base._addGameListen();
            BuilderManager mgr = GameObject.Find("GameManager").GetComponent<BuilderManager>();

            LaserToggle.GetComponent<Toggle>().onValueChanged.AddListener(mgr.OnLaserSelected);
            MissileToggle.GetComponent<Toggle>().onValueChanged.AddListener(mgr.OnMissileSelected);
            StandardToggle.GetComponent<Toggle>().onValueChanged.AddListener(mgr.OnStandardSelected);
        }
    }
}