using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Svchost_Viewer_Ver1
{
    class GetSvchostInfoHandler
    {
        private List<TreeNode_Collection> mylist = new List<TreeNode_Collection>();

        /// <summary>
        /// Will get all the running svchost processes, and the services there running.
        /// </summary>
        /// <returns></returns>
        public List<TreeNode_Collection> GetData()
        {
            WMIAccess myWMIAccess = new WMIAccess();

            List<Win32Process> myWin32Process = new List<Win32Process>();
            List<Win32Service> myWin32Services = new List<Win32Service>();
            List<TreeNode_Collection> myTreeNode_Collection = new List<TreeNode_Collection>();
            TreeNode_Collection newNode;
 
            //Get all svchost.exe processes and save the info in myWin32Process.
            myWin32Process = myWMIAccess.getSpecficProcesses("SELECT * FROM Win32_Process WHERE Caption=\"svchost.exe\"");

            foreach (Win32Process x in myWin32Process)
            {
                newNode = new TreeNode_Collection();
                myWin32Services = new List<Win32Service>();

                newNode.myWin32Process = x;

                myWin32Services = myWMIAccess.getSpecificServices("SELECT * FROM Win32_Service WHERE ProcessId=\"" + x.ProcessId.ToString() + "\"");
                newNode.myServiceList = myWin32Services;

                myTreeNode_Collection.Add(newNode);

                myWin32Services = null;
                newNode = null;
            }

            //Clean up:::::::::::::::::.........
            newNode = null;
            myWMIAccess = null;
            myWin32Process = null;
            myWin32Services = null;

            return myTreeNode_Collection;
        }

    }
}
