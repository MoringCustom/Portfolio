using TMPro;
using UnityEngine;

namespace BS.UI.View
{
    public class RewardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rewardMoneyCount;

        public void Display(int money)
        {
            _rewardMoneyCount.text = $"+ {money}";
        }
    }
}