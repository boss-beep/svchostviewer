/* Class used to access service information in the windows WMI
/* "database", made by boss-beep
 * 19-06-2009
*/

using System;
using System.Collections.Generic;
//using System.Linq;
using System.Management;

namespace Svchost_Viewer_Ver1
{

    public class WMIAccess
    {
        //Got it from http://www.csharphelp.com/board2/read.html?f=1&i=11982&t=11982
        private static DateTime ToDateTime(string dmtfDate)
        {
            //There is a utility called mgmtclassgen that ships with the .NET SDK that
            //will generate managed code for existing WMI classes. It also generates
            // datetime conversion routines like this one.
            //Thanks to Chetan Parmar and dotnet247.com for the help.
            int year = System.DateTime.Now.Year;
            int month = 1;
            int day = 1;
            int hour = 0;
            int minute = 0;
            int second = 0;
            int millisec = 0;
            string dmtf = dmtfDate;
            string tempString = System.String.Empty;

            if (((System.String.Empty == dmtf) || (dmtf == null)))
            {
                return System.DateTime.MinValue;
            }

            if ((dmtf.Length != 25))
            {
                return System.DateTime.MinValue;
            }

            tempString = dmtf.Substring(0, 4);
            if (("****" != tempString))
            {
                year = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(4, 2);

            if (("**" != tempString))
            {
                month = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(6, 2);

            if (("**" != tempString))
            {
                day = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(8, 2);

            if (("**" != tempString))
            {
                hour = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(10, 2);

            if (("**" != tempString))
            {
                minute = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(12, 2);

            if (("**" != tempString))
            {
                second = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(15, 3);

            if (("***" != tempString))
            {
                millisec = System.Int32.Parse(tempString);
            }

            System.DateTime dateRet = new System.DateTime(year, month, day, hour, minute, second, millisec);

            return dateRet;
        }


        //Services___________________________________________________________________________

        /// <summary>
        /// Returns a list with all the services on the system, in the Win32Services form.
        /// </summary>
        /// <returns>List<Win32Services></returns>
        public List<Win32Service> getAllServices()
        {
            List<Win32Service> mylist = new List<Win32Service>();
            Win32Service MyWin32Services;

            //Setup to get data out of the Windows WMI:::...
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2",
                        string.Format("SELECT * FROM Win32_Service"));

            //Looping through the WMI results::::::.....
            foreach (ManagementObject result in mos.Get())
            {
                MyWin32Services = new Win32Service();

                MyWin32Services = getServiceData(result);

                mylist.Add(MyWin32Services);
                MyWin32Services = null;
            }
            return mylist;
        }

        public List<Win32Service> getSpecificServices(String WMI_Search)
        {
            List<Win32Service> mylist = new List<Win32Service>();
            Win32Service MyWin32Services;

            try
            {
                //Setup to get data out of the Windows WMI:::...
                ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2",
                            string.Format(WMI_Search));

                //Looping through the WMI results::::::.....
                foreach (ManagementObject result in mos.Get())
                {
                    MyWin32Services = new Win32Service();
                    MyWin32Services = getServiceData(result);
                    mylist.Add(MyWin32Services);
                    MyWin32Services = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong !!!\nError message:\n" + e.Message);
            }

            return mylist;
        }

        public Win32Service getServiceData(ManagementObject result)
        {
            Win32Service MyWin32Services = new Win32Service();

            #region MyWin32Services.AcceptPause
            try
            {
                MyWin32Services.AcceptPause = (bool)result["AcceptPause"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.AcceptPause = false;
            }
            #endregion

            #region MyWin32Services.AcceptStop
            try
            {
                MyWin32Services.AcceptStop = (bool)result["AcceptStop"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.AcceptStop = false;
            }
            #endregion

            #region MyWin32Services.Caption
            try
            {
                MyWin32Services.Caption = (String)result["Caption"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.Caption = "No Caption Found.";
            }
            #endregion

            #region MyWin32Services.CheckPoint
            try
            {
                MyWin32Services.CheckPoint = (UInt32)result["CheckPoint"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.CheckPoint = 0;
            }
            #endregion

            #region MyWin32Services.CreationClassName
            try
            {
                MyWin32Services.CreationClassName = (String)result["CreationClassName"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.CreationClassName = "";
            }
            #endregion

            #region MyWin32Services.Description
            try
            {
                MyWin32Services.Description = (String)result["Description"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.Description = "";
            }
            #endregion

            #region MyWin32Services.DesktopInterac
            try
            {
                MyWin32Services.DesktopInteract = (bool)result["DesktopInteract"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.DesktopInteract = false;
            }
            #endregion

            #region MyWin32Services.DisplayName
            try
            {
                MyWin32Services.DisplayName = (String)result["DisplayName"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.DisplayName = "";
            }
            #endregion

            #region  MyWin32Services.ErrorControl
            try
            {
                MyWin32Services.ErrorControl = (String)result["ErrorControl"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.ErrorControl = "";
            }
            #endregion

            #region MyWin32Services.ExitCode
            try
            {
                MyWin32Services.ExitCode = (UInt32)result["ExitCode"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.ExitCode = 0;
            }
            #endregion

            #region MyWin32Services.InstallDate
            try
            {
                MyWin32Services.InstallDate = (DateTime)result["InstallDate"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.InstallDate = DateTime.MinValue;
            }
            #endregion

            #region MyWin32Services.Name
            try
            {
                MyWin32Services.Name = (String)result["Name"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.Name = "";
            }
            #endregion

            #region MyWin32Services.PathName
            try
            {
                MyWin32Services.PathName = (String)result["PathName"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.PathName = "";
            }
            #endregion

            #region MyWin32Services.ProcessId   NOTE: Maybe problem with Null result....
            try
            {
                MyWin32Services.ProcessId = (UInt32)result["ProcessId"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.ProcessId = 0;
            }
            #endregion

            #region MyWin32Services.ServiceSpecificExitCode
            try
            {
                MyWin32Services.ServiceSpecificExitCode = (UInt32)result["ServiceSpecificExitCode"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.ServiceSpecificExitCode = 0;
            }
            #endregion

            #region MyWin32Services.ServiceType
            try
            {
                MyWin32Services.ServiceType = (String)result["ServiceType"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.ServiceType = "";
            }

            #endregion

            #region MyWin32Services.Started
            try
            {
                MyWin32Services.Started = (bool)result["Started"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.Started = false;
            }
            #endregion

            #region MyWin32Services.StartMode
            try
            {
                MyWin32Services.StartMode = (String)result["StartMode"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.StartMode = "";
            }
            #endregion

            #region MyWin32Services.StartName
            try
            {
                MyWin32Services.StartName = (String)result["StartName"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.StartName = "";
            }
            #endregion

            #region MyWin32Services.State
            try
            {
                MyWin32Services.State = (String)result["State"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.State = "";
            }
            #endregion

            #region MyWin32Services.Status
            try
            {
                MyWin32Services.Status = (String)result["Status"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.Status = "";
            }
            #endregion

            #region MyWin32Services.SystemCreationClassName
            try
            {
                MyWin32Services.SystemCreationClassName = (String)result["SystemCreationClassName"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.SystemCreationClassName = "";
            }
            #endregion

            #region MyWin32Services.SystemName
            try
            {
                MyWin32Services.SystemName = (String)result["SystemName"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.SystemName = "";
            }
            #endregion

            #region MyWin32Services.TagId
            try
            {
                MyWin32Services.TagId = (UInt32)result["TagId"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.TagId = 0;
            }
            #endregion

            #region MyWin32Services.WaitHint
            try
            {
                MyWin32Services.WaitHint = (UInt32)result["WaitHint"];
            }
            catch (NullReferenceException)
            {
                MyWin32Services.WaitHint = 0;
            }
            #endregion

            return MyWin32Services;
        }

        //Processes__________________________________________________________________________

        public List<Win32Process> getSpecficProcesses(String WMI_Search)
        {
            List<Win32Process> mylist = new List<Win32Process>();
            Win32Process MyWin32Process;

            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2",
            string.Format(WMI_Search));

            foreach (ManagementObject result in mos.Get())
            {
                MyWin32Process = new Win32Process();
                MyWin32Process = getAllProcessData(result);
                mylist.Add(MyWin32Process);
                MyWin32Process = null;
            }


            return mylist;
        }

        public Win32Process getAllProcessData(ManagementObject result)
        {
            Win32Process MyWin32process = new Win32Process();

            #region MyWin32process.Caption
            try
            {
                MyWin32process.Caption = (String)result["Caption"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.Caption = "";
            }
            #endregion

            #region MyWin32process.CommandLine
            try
            {
                MyWin32process.CommandLine = (String)result["CommandLine"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.CommandLine = "";
            }
            #endregion

            #region MyWin32process.CreationClassName
            try
            {
                MyWin32process.CreationClassName = (String)result["CreationClassName"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.CreationClassName = "";
            }
            #endregion

            #region MyWin32process.CreationDate
            try
            {
                MyWin32process.CreationDate = ToDateTime((String)result["CreationDate"]).ToString();
            }
            catch (NullReferenceException)
            {
                MyWin32process.CreationDate = "";
            }
            #endregion

            #region MyWin32process.CSCreationClassName
            try
            {
                MyWin32process.CSCreationClassName = (String)result["CSCreationClassName"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.CSCreationClassName = "";
            }
            #endregion

            #region MyWin32process.CSName
            try
            {
                MyWin32process.CSName = (String)result["CSName"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.CSName = "";
            }
            #endregion

            #region MyWin32process.Description
            try
            {
                MyWin32process.Description = (String)result["Description"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.Description = "";
            }
            #endregion

            #region MyWin32process.ExecutablePath
            try
            {
                MyWin32process.ExecutablePath = (String)result["ExecutablePath"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.ExecutablePath = "";
            }
            #endregion

            #region MyWin32process.ExecutionState
            try
            {
                MyWin32process.ExecutionState = (UInt16)result["ExecutionState"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.ExecutionState = 0;
            }
            #endregion

            #region MyWin32process.Handle
            try
            {
                MyWin32process.Handle = (String)result["Handle"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.Handle = "";
            }
            #endregion

            #region MyWin32process.HandleCount
            try
            {
                MyWin32process.HandleCount = (UInt32)result["HandleCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.HandleCount = 0;
            }
            #endregion

            #region MyWin32process.InstallDate
            try
            {
                MyWin32process.InstallDate = (DateTime)result["InstallDate"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.InstallDate = DateTime.Parse("01-01-0001");
            }
            #endregion

            #region MyWin32process.KernelModeTime
            try
            {
                MyWin32process.KernelModeTime = (UInt64)result["KernelModeTime"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.KernelModeTime = 0;
            }
            #endregion

            #region MyWin32process.MaximumWorkingSetSize
            try
            {
                MyWin32process.MaximumWorkingSetSize = (UInt32)result["MaximumWorkingSetSize"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.MaximumWorkingSetSize = 0;
            }
            #endregion

            #region MyWin32process.MinimumWorkingSetSize
            try
            {
                MyWin32process.MinimumWorkingSetSize = (UInt32)result["MinimumWorkingSetSize"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.MinimumWorkingSetSize = 0;
            }
            #endregion

            #region  MyWin32process.Name
            try
            {
                MyWin32process.Name = (String)result["Name"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.Name = "";
            }
            #endregion

            #region MyWin32process.OSCreationClassName
            try
            {
                MyWin32process.OSCreationClassName = (String)result["OSCreationClassName"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.OSCreationClassName = "";
            }
            #endregion

            #region MyWin32process.OSName
            try
            {
                MyWin32process.OSName = (String)result["OSName"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.OSName = "";
            }
            #endregion

            #region MyWin32process.OtherOperationCount
            try
            {
                MyWin32process.OtherOperationCount = (UInt64)result["OtherOperationCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.OtherOperationCount = 0;
            }
            #endregion

            #region MyWin32process.OtherTransferCount
            try
            {
                MyWin32process.OtherTransferCount = (UInt64)result["OtherTransferCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.OtherTransferCount = 0;
            }
            #endregion

            #region MyWin32process.PageFaults
            try
            {
                MyWin32process.PageFaults = (UInt32)result["PageFaults"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.PageFaults = 0;
            }
            #endregion

            #region MyWin32process.PageFileUsage
            try
            {
                MyWin32process.PageFileUsage = (UInt32)result["PageFileUsage"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.PageFileUsage = 0;
            }
            #endregion

            #region MyWin32process.ParentProcessId   Maybe problems with Null default value !!
            try
            {
                MyWin32process.ParentProcessId = (UInt32)result["ParentProcessId"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.ParentProcessId = 0;
            }
            #endregion

            #region MyWin32process.PeakPageFileUsage
            try
            {
                MyWin32process.PeakPageFileUsage = (UInt32)result["PeakPageFileUsage"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.PeakPageFileUsage = 0;
            }
            #endregion

            #region MyWin32process.PeakVirtualSize
            try
            {
                MyWin32process.PeakVirtualSize = (UInt64)result["PeakVirtualSize"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.PeakVirtualSize = 0;
            }
            #endregion

            #region MyWin32process.PeakWorkingSetSize
            try
            {
                MyWin32process.PeakWorkingSetSize = (UInt32)result["PeakWorkingSetSize"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.PeakWorkingSetSize = 0;
            }
            #endregion

            #region MyWin32process.Priority  Maybe problems with Null default value !!
            try
            {
                MyWin32process.Priority = (UInt32)result["Priority"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.Priority = 0;
            }
            #endregion

            #region MyWin32process.PrivatePageCount
            try
            {
                MyWin32process.PrivatePageCount = (UInt64)result["PrivatePageCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.PrivatePageCount = 0;
            }
            #endregion

            #region MyWin32process.ProcessId Maybe problems with Null default value !!
            try
            {
                MyWin32process.ProcessId = (UInt32)result["ProcessId"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.ProcessId = 0;
            }
            #endregion

            #region MyWin32process.QuotaNonPagedPoolUsage
            try
            {
                MyWin32process.QuotaNonPagedPoolUsage = (UInt32)result["QuotaNonPagedPoolUsage"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.QuotaNonPagedPoolUsage = 0;
            }
            #endregion

            #region MyWin32process.QuotaPagedPoolUsage
            try
            {
                MyWin32process.QuotaPagedPoolUsage = (UInt32)result["QuotaPagedPoolUsage"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.QuotaPagedPoolUsage = 0;
            }
            #endregion

            #region MyWin32process.QuotaPeakNonPagedPoolUsage
            try
            {
                MyWin32process.QuotaPeakNonPagedPoolUsage = (UInt32)result["QuotaPeakNonPagedPoolUsage"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.QuotaPeakNonPagedPoolUsage = 0;
            }
            #endregion

            #region  MyWin32process.QuotaPeakPagedPoolUsage
            try
            {
                MyWin32process.QuotaPeakPagedPoolUsage = (UInt32)result["QuotaPeakPagedPoolUsage"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.QuotaPeakPagedPoolUsage = 0;
            }
            #endregion

            #region MyWin32process.ReadOperationCount
            try
            {
                MyWin32process.ReadOperationCount = (UInt64)result["ReadOperationCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.ReadOperationCount = 0;
            }
            #endregion

            #region MyWin32process.ReadTransferCount
            try
            {
                MyWin32process.ReadTransferCount = (UInt64)result["ReadTransferCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.ReadTransferCount = 0;
            }
            #endregion

            #region MyWin32process.SessionId
            try
            {
                MyWin32process.SessionId = (UInt32)result["SessionId"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.SessionId = 0;
            }
            #endregion

            #region MyWin32process.Status
            try
            {
                MyWin32process.Status = (String)result["Status"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.Status = "";
            }
            #endregion

            #region MyWin32process.TerminationDate
            try
            {
                MyWin32process.TerminationDate = (DateTime)result["TerminationDate"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.TerminationDate = DateTime.Parse("01-01-0001");
            }
            #endregion

            #region  MyWin32process.ThreadCount
            try
            {
                MyWin32process.ThreadCount = (UInt32)result["ThreadCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.ThreadCount = 0;
            }
            #endregion

            #region MyWin32process.UserModeTime
            try
            {
                MyWin32process.UserModeTime = (UInt64)result["UserModeTime"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.UserModeTime = 0;
            }
            #endregion

            #region MyWin32process.VirtualSize
            try
            {
                MyWin32process.VirtualSize = (UInt64)result["VirtualSize"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.VirtualSize = 0;
            }
            #endregion

            #region  MyWin32process.WindowsVersion
            try
            {
                MyWin32process.WindowsVersion = (String)result["WindowsVersion"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.WindowsVersion = "";
            }
            #endregion

            #region MyWin32process.WorkingSetSize
            try
            {
                MyWin32process.WorkingSetSize = (UInt64)result["WorkingSetSize"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.WorkingSetSize = 0;
            }
            #endregion

            #region MyWin32process.WriteOperationCount
            try
            {
                MyWin32process.WriteOperationCount = (UInt64)result["WriteOperationCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.WriteOperationCount = 0;
            }
            #endregion

            #region MyWin32process.WriteTransferCount
            try
            {
                MyWin32process.WriteTransferCount = (UInt64)result["WriteTransferCount"];
            }
            catch (NullReferenceException)
            {
                MyWin32process.WriteTransferCount = 0;
            }
            #endregion

            return MyWin32process;
        }
    }

    public class Win32Service
    {
        public bool AcceptPause { get; set; }
        public bool AcceptStop { get; set; }
        public String Caption { get; set; }
        public UInt32 CheckPoint { get; set; }
        public String CreationClassName { get; set; }
        public String Description { get; set; }
        public bool DesktopInteract { get; set; }
        public String DisplayName { get; set; }
        public String ErrorControl { get; set; }
        public UInt32 ExitCode { get; set; }
        public DateTime InstallDate { get; set; }
        public String Name { get; set; }
        public String PathName { get; set; }
        public UInt32 ProcessId { get; set; }
        public UInt32 ServiceSpecificExitCode { get; set; }
        public String ServiceType { get; set; }
        public bool Started { get; set; }
        public String StartMode { get; set; }
        public String StartName { get; set; }
        public String State { get; set; }
        public String Status { get; set; }
        public String SystemCreationClassName { get; set; }
        public String SystemName { get; set; }
        public UInt32 TagId { get; set; }
        public UInt32 WaitHint { get; set; }

    }

    public class Win32Process
    {
        /// <summary>
        /// <para>Data type: string</para>
        /// <para>Short description of an object—a one-line string.</para>
        /// </summary>
        public String Caption { get; set; }

        /// <summary>
        /// <para>Data type: string</para>
        /// <para>Command line used to start a specific process, if applicable. This property is new for Windows XP.</para>
        /// </summary>
        public String CommandLine { get; set; }

        /// <summary>
        /// <para >Data type: string</para>
        /// <para>Qualifiers: Key, MaxLen(256)</para>
        /// <para>Name of the first concrete class in the inheritance chain that is used to create an instance. You can use this property with other key properties of the class to uniquely identify all of the instances of the class and its subclasses. This property is inherited from CIM_System.</para>
        /// </summary>
        public String CreationClassName { get; set; }

        /// <summary>
        /// <para>Data type: datetime</para>
        /// <para>Date the process begins executing.</para>
        /// </summary>
        public String CreationDate { get; set; }

        /// <summary>
        /// <para>Data type: string</para>
        /// <para>Creation class name of the scoping computer system.</para>
        /// </summary>
        public String CSCreationClassName { get; set; }

        public String CSName { get; set; }
        public String Description { get; set; }
        public String ExecutablePath { get; set; }
        public UInt16 ExecutionState { get; set; }
        public String Handle { get; set; }
        public UInt32 HandleCount { get; set; }
        public DateTime InstallDate { get; set; }
        public UInt64 KernelModeTime { get; set; }
        public UInt32 MaximumWorkingSetSize { get; set; }
        public UInt32 MinimumWorkingSetSize { get; set; }
        public String Name { get; set; }
        public String OSCreationClassName { get; set; }
        public String OSName { get; set; }
        public UInt64 OtherOperationCount { get; set; }
        public UInt64 OtherTransferCount { get; set; }
        public UInt32 PageFaults { get; set; }
        public UInt32 PageFileUsage { get; set; }
        public UInt32 ParentProcessId { get; set; }
        public UInt32 PeakPageFileUsage { get; set; }
        public UInt64 PeakVirtualSize { get; set; }
        public UInt32 PeakWorkingSetSize { get; set; }
        public UInt32 Priority { get; set; }
        public UInt64 PrivatePageCount { get; set; }
        public UInt32 ProcessId { get; set; }
        public UInt32 QuotaNonPagedPoolUsage { get; set; }
        public UInt32 QuotaPagedPoolUsage { get; set; }
        public UInt32 QuotaPeakNonPagedPoolUsage { get; set; }
        public UInt32 QuotaPeakPagedPoolUsage { get; set; }
        public UInt64 ReadOperationCount { get; set; }
        public UInt64 ReadTransferCount { get; set; }
        public UInt32 SessionId { get; set; }
        public String Status { get; set; }
        public DateTime TerminationDate { get; set; }
        public UInt32 ThreadCount { get; set; }
        public UInt64 UserModeTime { get; set; }
        public UInt64 VirtualSize { get; set; }
        public String WindowsVersion { get; set; }
        public UInt64 WorkingSetSize { get; set; }
        public UInt64 WriteOperationCount { get; set; }
        public UInt64 WriteTransferCount { get; set; }


    }
}