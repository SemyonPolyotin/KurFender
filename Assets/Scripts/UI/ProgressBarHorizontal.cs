using UnityEngine;

namespace UI
{
    public class ProgressBarHorizontal : MonoBehaviour
    {
        [SerializeField] private RectTransform _progressImage = default;

        public void SetProgress(float value)
        {
            _progressImage.anchorMax = new Vector2(value, _progressImage.anchorMax.y);
        }
    }
}
