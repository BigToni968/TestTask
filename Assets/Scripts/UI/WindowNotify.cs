using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

namespace Game
{
    public class WindowNotify : View
    {
        [SerializeField] private Canvas _self;
        [SerializeField] private TextMeshProUGUI _text;

        public void Message(string text)
        {
            _text.SetText(text);
            Show();
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public override void Show()
        {
            _self.enabled = true;
        }

        public override void Hide()
        {
            _self.enabled = false;
        }
    }
}