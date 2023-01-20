using Ship;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

#if true

namespace Editor
{
    [CustomEditor(typeof(Engine)), CanEditMultipleObjects]
    public class EngineEditor : UnityEditor.Editor
    {
        public VisualTreeAsset m_UXML;

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            m_UXML.CloneTree(root);

            var foldout = new Foldout() { viewDataKey = "EngineFullFoldout", text = "Full Inspector"};
            InspectorElement.FillDefaultInspector(foldout,serializedObject,this);
            root.Add(foldout);
            return root;
        }
    }
}

#endif