using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.ServiceProcess;
using System.IO;
using System.Management;

namespace Svchost_Viewer_Ver1
{
    public partial class Form1 : Form
    {
        String txt1 = "You need to run the application with administrator privileges\nto use these functions.\n\n Do you want to do this now ??";
        String txt2 = "Notice";
        String txt3 = "Are you sure, you want to close this service ??\n\nDoing so, may lead to your computer, not running\nas you intended it to.\n\nNOTE:\nThe service might only be closed, until your next reboot.\nIf you want to make sure is stays closed, please use the\nWindows service Manager.";
        String txt4 = "Something went wrong, look below to find out what:\n";
        String txt5 = "Error";
        String txt6 = "The selected service can't be stopped";
        String txt7 = "Getting Information :";
        //String txt8 = "Done in : ";
        String txt9 = "You have ";
        String txt10 = " svchost(s) running a total of ";
        String txt11 = " services.";

        int proCount = 0;
        int serCount = 0;

        private List<TreeNode_Collection> mylist = new List<TreeNode_Collection>();

        public Form1()
        {
            InitializeComponent();
                
                if (!VistaSecurity.IsAdmin())
                {
                    //Not runing as admin
                    serviceControlToolStripMenuItem.Image = Properties.Resources.user32_106.ToBitmap();
                    windowsServiceManagerToolStripMenuItem.Image = Properties.Resources.user32_106.ToBitmap();
                    DisableServiceControlles(true);
                }
                else
                {
                    //Runing as admin
                    this.Text += " (Administrator)";
                }
        }
                         
        //Main start method::::::::::.............
        private void Run()
        {
            refreshToolStripMenuItem.Enabled = false;
            toolStripTextLabel1.Text = ("Done in : " + FetchDataHandler().ToString());

            if (treeView1.Nodes.Count != 0)
            {
                treeView1.ExpandAll();

                treeView1.SelectedNode = treeView1.Nodes[0];
            }

            proCount = 0;
            serCount = 0;

            foreach (TreeNode x in treeView1.Nodes)
            {
                proCount++;

                foreach (TreeNode y in x.Nodes)
                {
                    serCount++;
                }
            }

            refreshToolStripMenuItem.Enabled = true;

            if (proCount != 0)
            {
                toolStripTextLabel1.Text = (txt9 + proCount + txt10 + serCount + txt11);
            }
            else
            {
                toolStripTextLabel1.Text = ("Svchost viewer could not find any running services.");
            }
        }


        //Data fetching::::::::::::::::....................
        private TimeSpan FetchDataHandler()
        {
            TimeSpan TotalTime;

            //Get the Start time.....
            System.Diagnostics.Stopwatch mySW = new System.Diagnostics.Stopwatch();
            mySW.Start();

            //Reset program for refresh.
            mylist.Clear();
            treeView1.Nodes.Clear();

            //Make background thread, to get svchost data.
            BackgroundWorker myBGW = new BackgroundWorker();
            myBGW.DoWork += new DoWorkEventHandler(this.FetchData);
            myBGW.RunWorkerAsync();

            try
            {
                toolStripProgressBar1.Visible = true;
                toolStripTextLabel1.Text = txt7;

                while (myBGW.IsBusy)
                {
                    Application.DoEvents();
                }

                toolStripTextLabel1.Text = "";
                toolStripProgressBar1.Visible = false;

                //Clean up::::::::::::::::::::::.............
                myBGW.Dispose();
                myBGW = null;

                FillTreeView(mylist);

                mySW.Stop(); //Stop the stopwatch....
            }
            catch (Exception)
            {
                //If you closes the application before thread is done, program
                //will crash at "toolStripProgressBar1.Visible = true;" this is to stop that.
                //Shit-ty way of doing this, but it works

            }
            finally
            {
                mySW.Stop();
            }

            return TotalTime = (mySW.Elapsed);
        }

        private void FetchData(object sender, EventArgs e)
        {
            mylist = GetSerivceData();
        }

        private List<TreeNode_Collection> GetSerivceData()
        {
            List<TreeNode_Collection> myServicesList = new List<TreeNode_Collection>();

            GetSvchostInfoHandler mySvchostHandler = new GetSvchostInfoHandler();
            myServicesList = mySvchostHandler.GetData();

            return myServicesList;
        }


        //Display methods:::::::::::::::::::::::::........................
        /// <summary>
        /// Show the information for the process and the services it's running.  //Controller
        /// </summary>
        /// <param name="ParentIndex">Must by -1 if node has no parent</param>
        /// <param name="NodeIndex"></param>
        private void ShowInformation(int ParentIndex, int NodeIndex)
        {
            if (ParentIndex != -1)
            {
                ShowProcessInformation(mylist[ParentIndex].myWin32Process);
                ShowServiceInformation(mylist[ParentIndex].myServiceList[NodeIndex]);
            }
            else
            {
                //Reset textlabels:::::::::::::::::::::::::..............
                ServiceInformation_richTextBox1.Clear();
                service_name_txt.Text = "Name : ";
                Service_Type_txt.Text = "Service Type : ";
                Start_mode_txt.Text = "Start mode : ";
                Status_mode_txt.Text = "Status : ";
                service_pause_checkbox.Checked = false;
                service_stopped_checkbox.Checked = false;


                ShowProcessInformation(mylist[NodeIndex].myWin32Process);
            }
        }

        private void ShowServiceInformation(Win32Service service)
        {
            ServiceInformation_richTextBox1.Clear();
            ServiceInformation_richTextBox1.Text = (service.Name + " : \n" + service.Description);

            service_name_txt.Text = "Name : "           + service.Name;
            Service_Type_txt.Text = "Service Type : "   + service.ServiceType;
            Start_mode_txt.Text   = "Start mode : "     + service.StartMode;
            Status_mode_txt.Text  = "Status : "         + service.Status;

            //Service can be paused:::::::::::::::::::...........
            if (service.AcceptPause)
                service_pause_checkbox.Checked = true;
            else
                service_pause_checkbox.Checked = false;

            //Service can be Stop::::::::::.......................
            if (service.AcceptStop)
                service_stopped_checkbox.Checked = true;
            else
                service_stopped_checkbox.Checked = false;
        }

        private void ShowProcessInformation(Win32Process myWin32Process)
        {
            processInformation_richTextBox1.Clear();
            processInformation_richTextBox1.Text += ("svchost.exe with process ID : " + myWin32Process.Handle.ToString() + " is using " + GetRightbytetype(myWin32Process.PageFileUsage.ToString()) + "\n" +
                                                     "Amount of data written : " + GetRightbytetype(myWin32Process.WriteTransferCount.ToString()) + "\n" + 
                                                     "Amount of data read : " + GetRightbytetype(myWin32Process.ReadTransferCount.ToString()));
        }

        private void FillTreeView(List<TreeNode_Collection> Collection)
        {

            TreeNode newNode;
            TreeNode newServiceNode;

            foreach (TreeNode_Collection x in Collection)
            {
                newNode = new TreeNode(x.myWin32Process.Name + " PID: " + x.myWin32Process.ProcessId);
                newNode.ImageIndex = 1;
                newNode.SelectedImageIndex = 1;

                foreach (Win32Service Services in x.myServiceList)
                {
                    newServiceNode = new TreeNode(Services.Name);
                    newServiceNode.ImageIndex = 0;

                    newNode.Nodes.Add(newServiceNode);
                    newServiceNode = null;
                }

                treeView1.Nodes.Add(newNode);
                newNode = null;
            }
        }



        //Helper methods::::::::::::::::::::::::::::::::::::::...................
        private void RemoveServiceNode(int parent, int nodeIndex)
        {                       
            if (mylist[parent].myServiceList.Count == 1)
            {
                treeView1.Nodes[parent].Nodes[nodeIndex].Remove(); //Remove service from treeview.
                treeView1.Nodes[parent].Remove();                  //Remove parent node from tree.

                mylist[parent].myServiceList.RemoveAt(nodeIndex);  //Remove service from internal array.
                mylist.Remove(mylist[parent]);                     //Remove parent node from internal array, because there a no child nodes left. 

                proCount--;
                serCount--;
            }
            else
            {
                treeView1.Nodes[parent].Nodes[nodeIndex].Remove(); //Remove service from treeview.
                mylist[parent].myServiceList.RemoveAt(nodeIndex);  //Remove service from internal array.
                serCount--;
            }

            toolStripTextLabel1.Text = (txt9 + proCount + txt10 + serCount + txt11);
            
        }

        private void StopService()
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Parent == null)
            {
                //Selection of a Parent node, or nothing.
                //do nothing....
            }
            else
            {
                ServiceController myController = new ServiceController(treeView1.SelectedNode.Text);

                if (myController.CanStop) //Check if service can be stopped
                {
                    if (MessageBox.Show(txt3, txt2, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            myController.Stop();
                            RemoveServiceNode(treeView1.SelectedNode.Parent.Index, treeView1.SelectedNode.Index);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(txt4 + e.Message, txt5, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show(txt6, txt2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                myController = null;
                //MessageBox.Show("Done....");
            }
        }

        private void DisableServiceControlles(bool yes)
        {
            if (yes)
            {
                stopSelectServiceToolStripMenuItem.Enabled = false;
            }
            else
            {
                stopSelectServiceToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// When given a number of bytes in a string format it returns the rigth type
        /// f.x. the string "4569563136" would return as 4,25 GB.
        /// </summary>
        /// <param name="S">Bytes in String format i.e "4569563136"</param>
        /// <returns>returns as 4,25 GB</returns>
        private string GetRightbytetype(string S)
        {
            double x = 0;

            try
            {
                x = Convert.ToDouble(S);
            }
            catch (Exception)
            {
                x = 0;
            }

            if (x < 1024)
            {
                return (x + " B");
            }
            else if ((x / 1024) < 1024)
            {
                x = Math.Round((x / 1024), 2);
                return (x + " KB");
            }
            else if ((x / 1024) / 1024 < 1024)
            {
                x = Math.Round(((x / 1024) / 1024), 2);
                return x + " MB";
            }
            else if ((((x / 1024) / 1024) / 1024) < 1024)
            {
                x = Math.Round((((x / 1024) / 1024) / 1024), 2);
                return x + " GB";
            }
            else if (((((x / 1024) / 1024) / 1024) / 1024) < 1024)
            {
                x = Math.Round(((((x / 1024) / 1024) / 1024) / 1024), 2);
                return x + " TB";
            }
            else if ((((((x / 1024) / 1024) / 1024) / 1024) / 1024) < 1024)
            {
                x = Math.Round((((((x / 1024) / 1024) / 1024) / 1024) / 1024), 2);
                return x + " PB";
            }

            return " ";
        }

        private void GenerateReport()
        {
            if (mylist.Count != 0)
            {
                SaveFileDialog mySave = new SaveFileDialog();
                mySave.Filter = "Text file|*.txt";
                mySave.FilterIndex = 0;
                mySave.AddExtension = true;
                mySave.Title = "Save report as";

                if (mySave.ShowDialog() == DialogResult.OK)
                {
                    String WindowsVersion = ""; ;
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                    foreach (ManagementObject wmi_Windows in searcher.Get())
                    {
                      WindowsVersion = wmi_Windows["Caption"].ToString();
                    }

                    StreamWriter mySW = new StreamWriter(mySave.FileName);
                    
                    mySW.WriteLine("Report generated on : " + DateTime.Now);
                    mySW.WriteLine("OS : " + WindowsVersion);
                    mySW.WriteLine("Services running on " + Environment.MachineName + " : ");
                    mySW.WriteLine("-----------------------------------------------------");

                    int processes = 0;
                    int services = 0;

                    foreach (TreeNode_Collection x in mylist)
                    {
                        foreach (Win32Service y in x.myServiceList)
                        {
                            mySW.WriteLine(y.Caption);
                            services++;
                        }

                        processes++;
                    }

                    mySW.WriteLine("-----------------------------------------------------");
                    mySW.WriteLine("System is running : " + services.ToString() + " service(s)" + "\n" +
                                   " in a total of : " + processes.ToString() + " svchost.exe process(es)");

                    mySW.Close();
                    mySW = null;
                    mySave = null;

                    searcher = null;
                }

            }
            else
            {
                MessageBox.Show("No services found!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



       
        //GUI Events::::::::::::::::::::::::::::::::::::::::::::::::::...........................................

        /// <summary>
        /// Call a Metode to show the information about the service or svchost program user selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                //Selected Node is a root node.
                ShowInformation(-1, e.Node.Index);                               
            }
            else
            {
                ShowInformation(e.Node.Parent.Index, e.Node.Index);
            }
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true; //Stops nodes from collapsing.
        }       

        private void toolStripButton1_Refresh_btn_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Easy way to start background thread, and still get Form1 to load completely.
            timer1.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            Run();            
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void stopSelectServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopService();
        }

        private void serviceControlToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (!VistaSecurity.IsAdmin())
            {
                serviceControlToolStripMenuItem.HideDropDown();
                DisableServiceControlles(true);
                if (MessageBox.Show(txt1, txt2, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    VistaSecurity.RestartElevated();
                }
            }
            else
            {

                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.SelectedNode.Parent == null)
                    {
                        DisableServiceControlles(true);
                    }
                    else
                    {
                        DisableServiceControlles(false);
                    }
                }
                else
                {
                    DisableServiceControlles(true);
                }
            }
        }

        private void windowsServiceManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("services.msc", "runas");
            }
            catch (Exception e1)
            {
                MessageBox.Show("Something want wrong :\n" + e1.Message,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About myAbout = new About();
            myAbout.ShowDialog();
        }

       
    }
}
