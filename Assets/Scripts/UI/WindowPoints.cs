using ButchersGames;
using UnityEngine;
using TMPro;

namespace Game
{
    public class WindowPoints : View
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _curentPoints;
        [SerializeField] private Player _player;

        private void Start()
        {
            _levelText.SetText($"Уровень {LevelManager.CurrentLevel}");
            _player.OnPointsCallback += UpdatePlayerPoints;
        }

        private void UpdatePlayerPoints(int points)
        {
            _curentPoints.SetText(points.ToString());
        }

        private void OnDestroy()
        {
            _player.OnPointsCallback -= UpdatePlayerPoints;
        }
    }
}