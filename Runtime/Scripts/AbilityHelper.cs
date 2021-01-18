﻿
using System;
using System.Text;

using Unity.Entities;

using UnityEngine;

using WaynGroup.Mgm.Ability;

public static class AbilityHelper
{
    public const string ADDRESSABLE_ABILITY_LABEL = "Ability";

    public static void AddAbility(ScriptableAbility ability, ref DynamicBuffer<AbilityBufferElement> buffer, float initalCoolDown = -1)
    {
        Debug.Log($"Adding {ability.Name} / {ability.Timings.CoolDown} ");
        AddAbility(ability.Id, initalCoolDown > 0 ? initalCoolDown : ability.Timings.CoolDown, ref buffer);
    }

    public static void AddAbility(uint abilityGuid, float initalCoolDown, ref DynamicBuffer<AbilityBufferElement> buffer)
    {

        buffer.Add(new AbilityBufferElement()
        {
            Guid = abilityGuid,
            CurrentTimming = initalCoolDown,
            AbilityState = AbilityState.CoolingDown
        });
    }

    public static uint ComputeAbilityIdFromGuid(string Guid)
    {
        return BitConverter.ToUInt32(Encoding.ASCII.GetBytes(Guid), 0);
    }
}