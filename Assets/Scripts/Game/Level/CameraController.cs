using UnityEngine;

namespace Game.Level
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset = default;

        private Transform[] _targetTransforms;
        private Vector3 _targetPosition;
        private float _maxDistance;
        
        private const float _minDistance = 10f;
            
        public void Initialize(Transform[] targetTransforms)
        {
            _targetTransforms = targetTransforms;
        }

        private void Update()
        {
            if (_targetTransforms.Length == 0)
            {
                return;
            }

            _targetPosition = Vector3.zero;
            for (int i = 0; i < _targetTransforms.Length; i++)
            {
                _targetPosition += _targetTransforms[i].position;
            }

            _targetPosition = _targetPosition / _targetTransforms.Length;

            _maxDistance = 0f;
            for (int i = 0; i < _targetTransforms.Length - 1; i++)
            {
                for (int j = i + 1; j < _targetTransforms.Length; j++)
                {
                    var distance = Vector3.Distance(_targetTransforms[i].position, _targetTransforms[j].position);
                    if (distance > _maxDistance)
                    {
                        _maxDistance = distance;
                    }
                }
            }

            if (_maxDistance > _minDistance)
            {
                transform.position = _targetPosition - _offset.normalized * (_offset.magnitude * _maxDistance / _minDistance);
            }
            else
            {
                transform.position = _targetPosition - _offset;
            }
        }
    }
}