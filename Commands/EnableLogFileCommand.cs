
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

using System;
using System.IO;
using System.Linq;


namespace PSLogging.Commands
{
    using System.Management.Automation;

    [Cmdlet(VerbsLifecycle.Enable, "LogFile")]
    public class EnableLogFileCommand : PSCmdlet
    {
        private ScriptBlock errorCallback;
        private LogFile inputObject;
        private string path;
        private StreamType streams = StreamType.All;

        #region Parameters

        [Parameter(ParameterSetName = "AttachExisting",
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true)]
        public LogFile InputObject
        {
            get { return inputObject; }
            set { inputObject = value; }
        }

        [Parameter(ParameterSetName = "New")]
        public ScriptBlock OnError
        {
            get { return errorCallback; }
            set { errorCallback = value; }
        }

        [Parameter(Mandatory = false,
            Position = 0,
            ParameterSetName = "New")]
        public string Path
        {
            get { return path; }
            set
            {
                path = GetUnresolvedProviderPathFromPSPath(value);
            }
        }

        [Parameter(ParameterSetName = "New")]
        public StreamType StreamType
        {
            get { return streams; }
            set { streams = value; }
        }

        #endregion

        protected override void EndProcessing()
        {
            LogFile logFile;

            if (ParameterSetName == "New")
            {

                logFile = new LogFile(string.IsNullOrEmpty(path) ? GetDefaultLogFileName() : path, streams, errorCallback);
                WriteObject(logFile);
            }
            else
            {
                logFile = inputObject;
            }

            // Initiate a log file 
            logFile.CheckDirectory();
            if (!File.Exists(logFile.Path) && !string.IsNullOrEmpty(MyInvocation.ScriptName))
            {
                File.AppendAllText(logFile.Path, $"******************\r\nScript Location: {MyInvocation.ScriptName} \r\n******************\r\n");
            }
            HostIOInterceptor.Instance.AttachToHost(Host);
            HostIOInterceptor.Instance.AddSubscriber(logFile);
        }

        private string GetDefaultLogFileName()
        {
            var dateString = DateTime.Now.ToString(@"yyyy-MM-dd_HHmm");

            var scriptName = string.Empty;
            var directoryName = ".\\Log";

            if (!string.IsNullOrEmpty(this.MyInvocation.ScriptName))
            {
                var directoryInfo = new DirectoryInfo(MyInvocation.ScriptName);
                scriptName = directoryInfo.Name.Remove(directoryInfo.Name.IndexOf(".", StringComparison.Ordinal));
                directoryName = directoryInfo.Parent?.FullName;
            }
            directoryName = $@"{directoryName}\Log\{scriptName}_Log_{dateString}.txt";

            return directoryName;
        }
    } // End AddLogFileCommand class
}

// ReSharper restore MemberCanBePrivate.Global
// ReSharper restore UnusedAutoPropertyAccessor.Global
// ReSharper restore UnusedMember.Global