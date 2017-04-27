﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 场景层级定义，对应unity layer
/// @author hannibal
/// @time 2016-12-19
/// </summary>
public class SceneLayerID
{
    public const string Layer_Default       = "Default";
    public const string Layer_UI            = "UI";
    public const string Layer_Scene         = "Scene";
    public const string Layer_Effect        = "Effect";
    public const string Layer_Role          = "Role";
    public const string Layer_Bullet        = "Bullet";
    public const string Layer_Item          = "Item";
    public const string Layer_Collider      = "Collider";

    static public int GetSceneMask()
    {
        return (1 << LayerMask.NameToLayer(SceneLayerID.Layer_Scene));
    }
    static public int GetSceneRoleMask()
    {
        return (1 << LayerMask.NameToLayer(SceneLayerID.Layer_Scene) | 1 << LayerMask.NameToLayer(SceneLayerID.Layer_Role));
    }
}
