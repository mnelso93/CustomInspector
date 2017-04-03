using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetBase))]
public class PlanetBase_CustomInspector : Editor
{
    PlanetBase planetBase;

    private void OnEnable()
    {
        planetBase = (PlanetBase)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Basic Structure");
        EditorGUILayout.BeginVertical("Box");
        planetBase.mainColor = EditorGUILayout.ColorField("Planet Color", planetBase.mainColor);
        planetBase.planetSize = EditorGUILayout.IntField(new GUIContent("Planet Radius", "The radius of the earth is 3959 miles"), planetBase.planetSize);
        planetBase.revolutionTime = EditorGUILayout.FloatField("Revolution Time(hrs)", planetBase.revolutionTime);
        planetBase.orbitTime = EditorGUILayout.FloatField("Orbit Time(days)", planetBase.orbitTime);
        planetBase.moonAmount = EditorGUILayout.IntField("Moons", planetBase.moonAmount);
        planetBase.radiationAmount = EditorGUILayout.FloatField(new GUIContent("Radiation(MSV)", "Earth experience 3.01 on average"), planetBase.radiationAmount);
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Planetary Features");
        EditorGUILayout.BeginVertical("Box");
        planetBase.hasWater = EditorGUILayout.Toggle("Water Present", planetBase.hasWater);
        planetBase.lowTemp = EditorGUILayout.FloatField("Low temp(C)", planetBase.lowTemp);
        planetBase.highTemp = EditorGUILayout.FloatField("High temp(C)", planetBase.highTemp);
        EditorGUILayout.MinMaxSlider("Temperature Range (Celsius)", ref planetBase.lowTemp, ref planetBase.highTemp, -30.0F, 46.0F);
        planetBase.lowElevation = EditorGUILayout.FloatField("Low elevation(mi)", planetBase.lowElevation);
        planetBase.highElevation = EditorGUILayout.FloatField("High elevation(mi)", planetBase.highElevation);
        EditorGUILayout.MinMaxSlider("Elevation Range(mi)", ref planetBase.lowElevation, ref planetBase.highElevation, -7.0F, 5.5F);
        planetBase.isHabitable = EditorGUILayout.Toggle(new GUIContent("Is Habitable", "Can support life"), planetBase.isHabitable);
        if (planetBase.isHabitable == true)
        {
            planetBase.flora = EditorGUILayout.Toggle("Flora", planetBase.flora);
            if (planetBase.flora == true)
            {
                planetBase.fauna = EditorGUILayout.Toggle("Fauna", planetBase.fauna);
            }
        }
        SerializedProperty mainElems = serializedObject.FindProperty("mainElements");

        EditorGUILayout.PropertyField(mainElems, true);
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Intelligent Life");
        EditorGUILayout.BeginVertical("Box");
        planetBase.intelligentCreatures = EditorGUILayout.Toggle(new GUIContent("Sentient Life", "Native or otherwise"), planetBase.intelligentCreatures);
        if(planetBase.intelligentCreatures == true)
        {
            planetBase.icPopulation = EditorGUILayout.IntField("Population", planetBase.icPopulation);
        }
        EditorGUILayout.EndVertical();
        serializedObject.ApplyModifiedProperties();
        //base.OnInspectorGUI();
    }
}
