﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WinFormsPopupAlerts
{
    public class TooltipAlertFactory : BasicPopupAlertFactory
    {
        public TooltipAlertFactory()
        {

        }

        public TooltipAlertFactory(System.ComponentModel.IContainer container)
            : base(container)
        {

        }

        protected override BasicPopupAlert CreateAlertImpl(object[] args)
        {
            TooltipAlert alert = new TooltipAlert(args);
            switch (AlertStyle)
            {
                case TooltipAlertStyle.Defualt:
                case TooltipAlertStyle.System:
                    alert.Renderer = new SystemTooltipAlertRenderer();
                    break;
                case TooltipAlertStyle.Custom:
                    alert.Renderer = CustomRenderer;
                    break;
            }
            
            return alert;
        }

        private TooltipAlertStyle alertStyle;
        private TooltipAlertRenderer customRenderer;

        [DefaultValue(null)]
        public TooltipAlertRenderer CustomRenderer
        {
            get { return customRenderer; }
            set { customRenderer = value; }
        }

        [DefaultValue(TooltipAlertStyle.Defualt)]
        public TooltipAlertStyle AlertStyle
        {
            get { return alertStyle; }
            set { alertStyle = value; }
        }


    }
}