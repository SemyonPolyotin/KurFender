using System;
using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform = default;
        
        private Vector3 _offset;

        private void Start()
        {
            _offset = _targetTransform.position - transform.position;
        }

        private void Update()
        {
            transform.position = _targetTransform.position - _offset;
        }
    }
}
