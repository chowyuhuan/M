﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AM_AssetToABPathMapper {
    Dictionary<string, string> _AssetNameMap;
    bool _Read = false;
    CsvDataFileWriter _FileWriter;
    public AM_AssetToABPathMapper()
    {
        _AssetNameMap = new Dictionary<string, string>();
    }

    public string GetMapperPath()
    {
        return "Assets/Resources/Configs/csv/c_csv/c_asset_to_ab_pathmap";
    }

    public string GetAssetPath()
    {
        return "Assets/Resources/Configs/csv/c_csv/c_asset_to_ab_pathmap.csv";
    }

    public void OpenNameMapWithWrite()
    {
        _Read = false;
        _FileWriter = new CsvDataFileWriter("c_csv/c_asset_to_ab_pathmap");
        _FileWriter.ParseCSVFor("c_csv/c_asset_to_ab_pathmap");
        _FileWriter.ClearData();
    }

    public bool AddNameMap(string assetPath, string assetBundlePath)
    {
        string configPath;
        bool addToConfig = GetConfigPath(assetPath, out configPath);
        if(addToConfig)
        {
            if (_AssetNameMap.ContainsKey(configPath))
            {
                Debug.LogError("An asset with name " + assetPath + " has already add!!");
                return false;
            }
            else
            {
                _AssetNameMap.Add(configPath, assetBundlePath);
                _FileWriter.AddSpace();
                _FileWriter.SetValue("AssetPath", configPath);
                _FileWriter.SetValue("ABName", assetBundlePath);
                return true;
            }
        }
        return addToConfig;
    }

    bool GetConfigPath(string sourcePath, out string configPath)
    {
        if(sourcePath.Contains("unity"))
        {
            Debug.LogError(sourcePath);
        }
        string relativePath;
        bool bConfig;
        if (AM_EditorTool.GetResourcesRelativePath(sourcePath, out relativePath))//位于Resources文件夹中资源
        {
            bConfig = true;
            configPath = AM_EditorTool.GetFilePathWithoutExtension(relativePath);
        }
        else if (AM_EditorTool.IsSceneFile(sourcePath))
        {
            bConfig = true;
            configPath = System.IO.Path.GetFileNameWithoutExtension(sourcePath);//场景文件
        }
        else//可从任意位置加载的bundle文件
        {
            configPath = null;
            bConfig = false;
        }
        return bConfig;
    }

    public void SaveNameMap()
    {
        Debug.Log("Asset Name Map saved .");
        /*FlushCacheToFile();*/
        _FileWriter.FlushCacheToFile();
    }

    public static void GenerateEmtpyMapper(bool log4track)
    {
        EditorLogTool.BeginLog4TrackBlock("清除Asset到AssetBundle的路径映射文件", log4track);
        AM_AssetToABPathMapper atabp = new AM_AssetToABPathMapper();
        atabp.OpenNameMapWithWrite();
        atabp.SaveNameMap();
        EditorLogTool.Log("【清除完成】", log4track);
        EditorLogTool.EndLog4TrackBlock(log4track);
    }
}
