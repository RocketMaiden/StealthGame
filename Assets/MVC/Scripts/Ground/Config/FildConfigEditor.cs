using UnityEditor;
using UnityEngine;

namespace Assets.MVC.Scripts.Ground.Config
{
    [CustomEditor(typeof(FieldConfig))]
    public class FildConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            var fieldConfig = (FieldConfig)target;

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Width");
            fieldConfig._width = EditorGUILayout.IntField(fieldConfig._width);            
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Heght");
            fieldConfig._height = EditorGUILayout.IntField(fieldConfig._height);            
            GUILayout.EndHorizontal();            

            if (GUILayout.Button("Update"))
            {
                fieldConfig.UpdateField();
            }

            if(fieldConfig._field == null)
            {
                return;
            }

            int n = 0;
            for (var y = fieldConfig.Height-1; y >= 0; y--)
            {
                GUILayout.BeginHorizontal();
                for (var x = 0; x < fieldConfig.Width; x++)
                {
                    if (n >= fieldConfig._field.Count)
                    {
                        break;
                    }
                    var cell = fieldConfig._field[n];
                    cell.CellType = (FieldConfigEnum)EditorGUILayout.EnumPopup(cell.CellType, GUILayout.Width(30));
                    cell.X = x;
                    cell.Y = y;
                    fieldConfig._field[n] = cell;
                    
                    n++;
                }
                GUILayout.EndHorizontal();
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
                EditorUtility.SetDirty(fieldConfig);                
            }
            
        }
    }
}
