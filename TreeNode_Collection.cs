using System.Collections.Generic;

namespace Svchost_Viewer_Ver1
{
    class TreeNode_Collection
    {
        public Win32Process myWin32Process = new Win32Process();
        public List<Win32Service> myServiceList = new List<Win32Service>();
    }
}
