using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerGUI : MonoBehaviour
    {
        [SerializeField] public Player player;
        [SerializeField] public TMP_Text hitPointsText;
        [SerializeField] public Image hitPointsImage;

        private void Update()
        {
            hitPointsText.text = player.HitPoints.ToString(CultureInfo.InvariantCulture);
            hitPointsImage.fillAmount = player.HitPoints / (player.MaxHp / 100) / 100;
        }
    }
}