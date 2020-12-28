﻿using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;

using WaynGroup.Mgm.Ability;

[CreateAssetMenu(fileName = "NewAbility", menuName = "MGM/Ability", order = 1)]
public class ScriptableAbility : ScriptableObject
{
    /// <summary>
    /// A unique Id generated when creating the ability in the editor.
    /// </summary>
    public string Id;
    /// <summary>
    /// The name of the ability.
    /// </summary>
    public string Name;

    /// <summary>
    /// The skill Icon.
    /// </summary>
    public Texture2D Icon;

    /// <summary>
    /// The distance constraints that need to be met in order to cast the ability.
    /// </summary>
    public Range Range;
    /// <summary>
    /// The time necessary for the ability to recahrge before it can be reused.
    /// </summary>
    public float CoolDown;
    /// <summary>
    /// The time needed by the ability between the user input and the trigerring of the ability effect.
    /// </summary>
    public float CastTime;
    /// <summary>
    /// The list of costs that are check to cast the ability.
    /// A corresponding effect is automatically added to the list of effect at runtime to consume the associated ressource.
    /// </summary>
    [SerializeReference]
    public List<IAbilityCost> Costs;
    /// <summary>
    /// The list of effect that are applied after the CastTime has elapsed.
    /// </summary>
    [SerializeReference]
    public List<IEffect> Effects;
    /// <summary>
    /// The list of spawnable gameobjects.
    /// These games object are converted to entities to be spanwed at runtime so any non convertible component will be ignored.
    /// </summary>

    public List<SpawnableData> Spawnables;



}


[Serializable]
public struct SpawnableData
{
    public AssetReferenceGameObject PrefabRef;
    [HideInInspector]
    public GameObject PrefabGO;
    public int count;
}

[Serializable]
public struct Range
{
    public float Min;
    public float Max;
}
