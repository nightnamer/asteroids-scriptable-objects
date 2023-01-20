using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Variables
{
    [CreateAssetMenu(fileName = "new FloatVariable", menuName = "ScriptableObjects/Variables/FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] public float _value;

        public float Value => _value;
    }
}
