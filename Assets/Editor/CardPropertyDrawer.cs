using UnityEditor;
using UnityEngine;

using CardGame;
    [CustomPropertyDrawer(typeof(Card))]
    public class CardPropertyDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // __prefab__ override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            var faceRect = new Rect(position.x, position.y, 40, position.height);
            var suitField = new Rect(position.x + 42, position.y, 40, position.height);
            var nameRect = new Rect(position.x + 86, position.y, position.width - 90, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(suitField, property.FindPropertyRelative("suit"), GUIContent.none);
            EditorGUI.PropertyField(faceRect, property.FindPropertyRelative("face"), GUIContent.none);
            EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);
            // var spriteRect = new Rect(position.x, position.y, position.width, position.height);
            //  property.objectReferenceValue = EditorGUI.ObjectField(spriteRect, property.objectReferenceValue, typeof(Texture2D), false);
            // EditorGUI.PropertyField(spriteRect, property.FindPropertyRelative("cardPrefab"), GUIContent.none);
            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();


        }
    }

  

//[CustomEditor(typeof(Card))]
//[CanEditMultipleObjects]
//public class LookAtCard : Editor
//{
//    GameObject previewGameObject;
//    AnimationClip animationClip;
//    Editor myEditor;
//    float sampleTime = 0.5f;
//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//   
//        Editor.DestroyImmediate(myEditor);
//        myEditor = Editor.CreateEditor(previewGameObject);
// 
//        AnimationMode.StartAnimationMode();
//        AnimationMode.BeginSampling();
//        AnimationMode.SampleAnimationClip(previewGameObject, animationClip, sampleTime);
//        myEditor.DrawPreview(new Rect(0, 0, 300, 300));
//        AnimationMode.EndSampling();
//        AnimationMode.StopAnimationMode();
//    }
//}
//1

//2

    [CustomPropertyDrawer(typeof(Card))]
    public class WavePropertyDrawer : PropertyDrawer
    {

        private const int spriteHeight = 50;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label, true);
            // 1
            if (property.isExpanded)
            {
                // 2
                SerializedProperty enemyPrefabProperty = property.FindPropertyRelative("cardPrefab");
                GameObject enemyPrefab = (GameObject) enemyPrefabProperty.objectReferenceValue;
                // 3
                if (enemyPrefab != null)
                {
                    SpriteRenderer enemySprite = enemyPrefab.GetComponentInChildren<SpriteRenderer>();

                    // 4
                    int previousIndentLevel = EditorGUI.indentLevel;
                    EditorGUI.indentLevel = 2;
                    // 5
                    Rect indentedRect = EditorGUI.IndentedRect(position);
                    float fieldHeight = base.GetPropertyHeight(property, label) + 2;
                    Vector3 enemySize = Vector3.back; //enemySprite.transform.
                    Rect texturePosition = new Rect(indentedRect.x, indentedRect.y + fieldHeight * 4,
                        enemySize.x / enemySize.y * spriteHeight, spriteHeight);
                    // 6
                    EditorGUI.DropShadowLabel(texturePosition, new GUIContent(enemySprite.sprite.texture));
                    // Animator anim = enemyPrefab.GetComponent<Animator>();
                    // animationClip = anim.runtimeAnimatorController.animationClips[0];

                    //   var a = EditorGUILayout.ObjectField(animationClip, typeof(AnimationClip), false) as AnimationClip;
                    // 7
                    EditorGUI.indentLevel = previousIndentLevel;
                }
            }


        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property);
        }

    }
