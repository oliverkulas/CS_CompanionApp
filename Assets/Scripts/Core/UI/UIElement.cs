﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Wb.Companion.Core.WbAdministration;


namespace Wb.Companion.Core.UI
{

    public enum UIElementMembership
    {
        Map = 0,
        RemoteControl_Driving = 1,
        RemoteControl_Crane = 2
    }

    public class UIElement : MonoBehaviour
    {

        public UIElementMembership uiElementMember;


        // --------------------------------------------------------------------
        // Mono Behaviour
        // --------------------------------------------------------------------

        void Start()
        {
                
        }

        void Update()
        {

        }

        // --------------------------------------------------------------------

    }
}