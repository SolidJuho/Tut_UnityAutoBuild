using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class AutomateBuildProcess 
{
    private static string BuildsFolder = "D:/GDP/Jenkins/workspace/UnityAutomaticBuilds/Builds/";

    public static void StartBuild()
    {
        List<string> enabledScenesPathNames = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                enabledScenesPathNames.Add(scene.path);
            }
        }


        string _fileName = "unityautobuild.apk";

        BuildPlayerOptions newBuildPlayerOptions = new BuildPlayerOptions();
        newBuildPlayerOptions.scenes = enabledScenesPathNames.ToArray();
        newBuildPlayerOptions.locationPathName = BuildsFolder + _fileName;
        newBuildPlayerOptions.target = BuildTarget.Android;
        newBuildPlayerOptions.targetGroup = BuildTargetGroup.Android;
        newBuildPlayerOptions.options = BuildOptions.None;

        Debug.Log("Starting build pipeline");
        BuildPipeline.BuildPlayer(newBuildPlayerOptions);
    }
}
