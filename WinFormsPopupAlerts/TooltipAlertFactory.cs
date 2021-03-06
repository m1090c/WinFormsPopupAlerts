﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using WinFormsPopupAlerts.Properties;



namespace WinFormsPopupAlerts
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxBitmap(typeof(TooltipAlertFactory))]
    [ToolboxItem(true)]
    public class TooltipAlertFactory : AlertFactory
    {
        private TooltipAlertStyle alertStyle;
        private TooltipAlertRenderer customRenderer;

        public TooltipAlertFactory()
        {
            string[] sa = this.GetType().Assembly.GetManifestResourceNames();
            foreach (string s in sa)
                System.Diagnostics.Trace.WriteLine(s);
        }

        public TooltipAlertFactory(System.ComponentModel.IContainer container)
            : base(container)
        {
            string[] sa = this.GetType().Assembly.GetManifestResourceNames();
            foreach (string s in sa)
                System.Diagnostics.Trace.WriteLine(s);
        }

        protected override Alert CreateAlertImpl(object arg, AlertAlignment align)
        {
            TooltipAlert alert = new TooltipAlert((TooltipAlertArg)arg, align);
            switch (AlertStyle)
            {
                case TooltipAlertStyle.System:
                    alert.Renderer = new SystemTooltipAlertRenderer();
                    break;
                case TooltipAlertStyle.Custom:
                    alert.Renderer = CustomRenderer;
                    break;
            }
            return alert;
        }

        [DefaultValue(null)]
        public TooltipAlertRenderer CustomRenderer
        {
            get { return customRenderer; }
            set { customRenderer = value; }
        }

        [DefaultValue(TooltipAlertStyle.System)]
        public TooltipAlertStyle AlertStyle
        {
            get { return alertStyle; }
            set { alertStyle = value; }
        }
    }
}
