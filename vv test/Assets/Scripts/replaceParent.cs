using UnityEngine;
using UnityEditor;
using System.Collections;
// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

public class replaceParent : ScriptableWizard
{
    public bool copyValues = true;
    public GameObject newParent;
    public GameObject[] OldObjects;

    [MenuItem("Custom/Replace Parent")]


    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace Parent", typeof(replaceParent), "Replace");
    }

    void OnWizardCreate()
    {
        //Transform[] Replaces;
        //Replaces = Replace.GetComponentsInChildren<Transform>();

        foreach (GameObject go in OldObjects)
        {
            go.transform.parent = newParent.transform;

        }

    }
}