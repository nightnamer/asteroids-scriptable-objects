using System;
using Ship;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Variables;

#if true

namespace Editor
{
    [CustomEditor(typeof(Engine)), CanEditMultipleObjects]
    public partial class EngineEditor : UnityEditor.Editor
    {

        public FloatVariable ThrottlePower;
        public FloatVariable RotationPower;
        
        public VisualTreeAsset m_UXML;

        private void OnEnable()
        {
            if (ThrottlePower == null) ThrottlePower = Resources.Load<FloatVariable>("ThrottlePower");
            if (RotationPower == null) RotationPower = Resources.Load<FloatVariable>("RotationPower");
        }

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            m_UXML.CloneTree(root);
            root.Q<Button>("Slow_button").clicked += SlowSpeed;
            root.Q<Button>("Medium_button").clicked += MediumSpeed;
            root.Q<Button>("Fast_button").clicked += FastSpeed;

            var foldout = new Foldout() { viewDataKey = "EngineFullFoldout", text = "Full Inspector"};
            InspectorElement.FillDefaultInspector(foldout,serializedObject,this);
            root.Add(foldout);
            return root;
        }
        
        private void SlowSpeed()
        {
            ThrottlePower._value = 8;
            RotationPower._value = 2;
        }
        private void MediumSpeed()
        {
            ThrottlePower._value = 16;
            RotationPower._value = 4;
        }
        private void FastSpeed()
        {
            ThrottlePower._value = 24;
            RotationPower._value = 6;
        }
    }
}

#endif