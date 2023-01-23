using System;
using UnityEditor.VersionControl;
using UnityEngine;
using Variables;
using UnityEngine.UIElements;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : MonoBehaviour
    {
        [SerializeField] private FloatVariable _throttlePower;
        [SerializeField] private FloatVariable _rotationPower;
        
        [Header("Speeds")]
        [SerializeField] private float _throttlePowerSimple;
        [SerializeField] private float _rotationPowerSimple;

        private Rigidbody2D _rigidbody;
        
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Throttle();
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SteerLeft();
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                SteerRight();
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_throttlePowerSimple != _throttlePower._value) _throttlePowerSimple = _throttlePower._value;
            if (_rotationPowerSimple != _rotationPower._value) _rotationPowerSimple = _rotationPower._value;
        }

        public void Throttle()
        {
            _rigidbody.AddForce(transform.up * _throttlePower.Value, ForceMode2D.Force);
        }

        public void SteerLeft()
        {
            _rigidbody.AddTorque(_rotationPower.Value, ForceMode2D.Force);
        }

        public void SteerRight()
        {
            _rigidbody.AddTorque(-_rotationPower.Value, ForceMode2D.Force);
        }

        public void SlowSpeed()
        {
            _throttlePowerSimple = 8;
            _rotationPowerSimple = 2;
        }
        public void MediumSpeed()
        {
            _throttlePowerSimple = 12;
            _rotationPowerSimple = 5;
        }
        public void FastSpeed()
        {
            _throttlePowerSimple = 16;
            _rotationPowerSimple = 8;
        }
        
    }
}
