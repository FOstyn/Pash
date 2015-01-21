﻿// Copyright (C) Pash Contributors. License: GPL/BSD. See https://github.com/Pash-Project/Pash/
using System;
using System.Collections.Generic;
using System.Text;
using System.Management.Automation.Host;
using System.Collections.ObjectModel;
using System.Security.AccessControl;
using Pash.Implementation;

namespace System.Management.Automation.Provider
{
    public abstract class CmdletProvider : IResourceSupplier
    {
        internal ProviderRuntime ProviderRuntime { get; set; }

        // TODO: use CmdletProviderManagementIntrinsics

        protected CmdletProvider()
        {
        }

        public PSCredential Credential { get; private set; }
        protected object DynamicParameters { get; private set; }
        public Collection<string> Exclude
        {
            get
            {
                return ProviderRuntime.Exclude;
            }
        }

        public string Filter
        {
            get
            {
                return ProviderRuntime.Filter;
            }
        }

        public SwitchParameter Force
        {
            get
            {
                return ProviderRuntime.Force;
            }
        }

        protected PSDriveInfo PSDriveInfo
        {
            get
            {
                return ProviderRuntime.PSDriveInfo;
            }
        }

        public PSHost Host { get; private set; }
        public Collection<string> Include
        {
            get
            {
                return ProviderRuntime.Include;
            }
        }

        public CommandInvocationIntrinsics InvokeCommand { get; private set; }
        public ProviderIntrinsics InvokeProvider { get; private set; }
        protected ProviderInfo ProviderInfo { get; private set; }
        public bool Stopping { get; private set; }

        public SessionState SessionState
        {
            get
            {
                return this.ProviderRuntime.ExecutionContext.SessionState;
            }
        }

        public bool ShouldContinue(string query, string caption) { throw new NotImplementedException(); }
        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll) { throw new NotImplementedException(); }
        public bool ShouldProcess(string target)
        { 
            // TODO: implement behavior
            return true;
        }
        public bool ShouldProcess(string target, string action) { throw new NotImplementedException(); }
        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption) { throw new NotImplementedException(); }
        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason) { throw new NotImplementedException(); }

        protected virtual ProviderInfo Start(ProviderInfo providerInfo)
        {
            return providerInfo;
        }

        internal ProviderInfo Start(ProviderInfo providerInfo, ProviderRuntime providerRuntime)
        {
            ProviderRuntime = providerRuntime;
            return Start(providerInfo);
        }

        protected virtual object StartDynamicParameters() { throw new NotImplementedException(); }


        protected virtual void Stop()
        {
            //TODO: useful default implementation?
        }

        internal void Stop(ProviderRuntime providerRuntime)
        {
            ProviderRuntime = providerRuntime;
            Stop();
        }


        protected internal virtual void StopProcessing() { throw new NotImplementedException(); }
        public void ThrowTerminatingError(ErrorRecord errorRecord) { throw new NotImplementedException(); }
        public void WriteDebug(string text) { throw new NotImplementedException(); }
        public void WriteError(ErrorRecord errorRecord)
        {
            ProviderRuntime.WriteError(errorRecord);
        }

        public void WriteItemObject(object item, string path, bool isContainer)
        {
            PSObject psObject = GetItemAsPSObject(item, path);
            PSNoteProperty member = new PSNoteProperty("PSIsContainer", isContainer);
            psObject.Properties.Add(member);
            ProviderRuntime.WriteObject(psObject);
        }

        public void WriteProgress(ProgressRecord progressRecord) { throw new NotImplementedException(); }
        public void WritePropertyObject(object propertyValue, string path) { throw new NotImplementedException(); }
        public void WriteSecurityDescriptorObject(ObjectSecurity securityDescriptor, string path) { throw new NotImplementedException(); }
        public void WriteVerbose(string text) { throw new NotImplementedException(); }
        public void WriteWarning(string text) { throw new NotImplementedException(); }

        #region IResourceSupplier Members

        public string GetResourceString(string baseName, string resourceId)
        {
            throw new NotImplementedException();
        }

        #endregion

        internal void SetProviderInfo(ProviderInfo providerInfo)
        {
            ProviderInfo = providerInfo;
        }

        internal static T As<T>(CmdletProvider provider) where T : CmdletProvider
        {
            var casted = provider as T;
            if (casted == null)
            {
                throw new NotSupportedException("The provider is not a valid provider of type '" + typeof(T).Name + "'");
            }
            return casted;
        }

        private PSObject GetItemAsPSObject(object item, Path path)
        {
            if (item == null)
            {
                throw new Exception("Item can't be null");
            }

            PSObject psObject = PSObject.AsPSObject(item);

            PSObject obj3 = item as PSObject;
            if (obj3 != null)
            {
                psObject.TypeNames.Clear();
                foreach (string str in obj3.TypeNames)
                {
                    psObject.TypeNames.Add(str);
                }
            }

            // Add full path as a property
            string providerFullPath = PathIntrinsics.GetFullProviderPath(ProviderInfo, path);
            psObject.Properties.Add(new PSNoteProperty("PSPath", providerFullPath));

            NavigationCmdletProvider provider = this as NavigationCmdletProvider;
            if ((provider != null) && (path != null))
            {
                string parentPath = null;
                if (PSDriveInfo == null)
                {
                    parentPath = provider.GetParentPath(path, string.Empty, ProviderRuntime);
                }
                else
                {
                    parentPath = provider.GetParentPath(path, PSDriveInfo.Root, ProviderRuntime);
                }

                if (!string.IsNullOrEmpty(parentPath))
                {
                    parentPath = PathIntrinsics.GetFullProviderPath(ProviderInfo, parentPath);
                }
                else
                {
                    parentPath = string.Empty;
                }
                psObject.Properties.Add(new PSNoteProperty("PSParentPath", parentPath));

                string childName = provider.GetChildName(path, ProviderRuntime);
                psObject.Properties.Add(new PSNoteProperty("PSChildName", childName));
            }

            if (PSDriveInfo != null)
            {
                psObject.Properties.Add(new PSNoteProperty("PSDrive", PSDriveInfo));
            }

            psObject.Properties.Add(new PSNoteProperty("PSProvider", ProviderInfo));
            return psObject;
        }
    }
}
