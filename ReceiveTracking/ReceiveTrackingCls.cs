using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LSExtensionWindowLib;
using LSSERVICEPROVIDERLib;
using System.Data.OracleClient;
//using Oracle.ManagedDataAccess.Client;
using System.Runtime.InteropServices;
using DalTracking;

namespace ReceiveTracking
{
    [ComVisible(true)]
    [ProgId("ReceiveTracking.ReceiveTrackingCls")]

    public partial class ReceiveTrackingCls : UserControl, IExtensionWindow
    {
        #region Private members

        private INautilusUser _ntlsUser;

        private IExtensionWindowSite2 _ntlsSite;

        private INautilusProcessXML _processXml;

        private INautilusServiceProvider _sp;

        private OracleConnection _connection;

        private OracleCommand cmd;

        private double sessionId;

        private string _connectionString;

        private INautilusRecordSet rs;

        public string _fromLab;

        public string _ToLab;

        public string _fromLabName;

        public string _ToLabName;

        public bool DEBUG;

        private DalTrackingCls dal;

        private string statusLabTrack;
        #endregion


        public ReceiveTrackingCls()
        {
            InitializeComponent();
            BackColor = Color.FromName("Control");
            txtBoxName.Focus();

        }


        string _currentBoxId = null;
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)//ארגז
        {
            lblBoxMsg.Text = "";
            if (e.KeyChar == (char)13 && txtBoxName.Text != "") //Enter
            {

                double user = 1;
                if (DEBUG == false)
                {
                    user = _ntlsUser.GetOperatorId();
                }
                string[] stausArr = { BoxStatus.SENT, BoxStatus.ARRIVED };
                //_currentBoxId = dal.getBox(_fromLab, _ToLab, txtBoxName.Text, user, stausArr);

                var curBox = dal.GetBoxByName(txtBoxName.Text.Trim());

                if (curBox != null)
                {
                    _currentBoxId = curBox.id;
                    if (curBox.from_lab != _fromLab || curBox.to_lab != _ToLab)
                    {
                        var msg = string.Format("הארגז אינו מיועד מ  {0} ל {1} ", _fromLabName, _ToLabName);

                        SetMsg(lblBoxMsg, msg, false);

                    }
                    else if (!stausArr.Contains(curBox.status))
                    {
                        SetMsg(lblBoxMsg, "הארגז אינו בסטטוס המתאים", false);

                    }
                    else
                    {
                        dal.UpdateBoxStatus(curBox.id, BoxStatus.ARRIVED, user, false);
                        SetMsg(lblBoxMsg, "הארגז התקבל במערכת", true);

                        txtBoxName.Enabled = false;
                        txtEntName.Enabled = true;
                        txtEntName.Focus();
                    }
                }
                else
                {


                    SetMsg(lblBoxMsg, "ארגז לא נמצא!", false);


                }
                txtBoxName.Text = "";
            }
        }

        private void SetMsg(Label lbl, string txt, bool valid)
        {
            lbl.Text = txt;
            lbl.ForeColor = valid ? Color.Blue : Color.Red;
        }

        private void textBoxEntity_KeyPress(object sender, KeyPressEventArgs e)//יישות
        {

            lblBoxMsg.Text = "";
            lblEntMsg.Text = "";
            if (e.KeyChar == (char)13 && txtEntName.Text != "") //Enter
            {

                var theText = txtEntName.Text.Trim();
                Department d = Department.None;
                if (cbx_pap.Checked)
                {
                    d = Department.Pap;
                }
                else if (cbx_cyt.Checked)
                {
                    d = Department.Cyto;
                }
                if (d != Department.None)
                {
                    theText = dal.HandleLongNumber(theText, d);
                }
                cbx_pap.Checked = false;
                cbx_cyt.Checked = false;
                var titem = dal.GetTrackItemByBox(_currentBoxId, theText);
                if (titem == null)  
                {
                    SetMsg(lblEntMsg, "היישות לא נמצאת בארגז!", false);

                }
                else if (titem.U_STATUS != "SZ" && titem.U_STATUS != "SD")//נשלח לדרום או לצפון
                {
                    SetMsg(lblEntMsg, "היישות צריכה להיות בסטטוס נשלח !", false);


                }
                else
                {

                    bool res = dal.UpdateEntityStatus(titem, _ToLab);

                    if (res)
                    {

                        SetMsg(lblEntMsg, "יישות התקבלה במערכת!", true);

                    }

                    else
                    {

                    }
                }
                txtEntName.Text = null;
                txtEntName.Focus();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _currentBoxId = null;
            lblBoxMsg.Text = "";
            lblEntMsg.Text = "";
            txtBoxName.Text = null;
            txtEntName.Text = null;
            txtBoxName.Enabled = true;
            txtEntName.Enabled = false;
            txtBoxName.Focus();
        }

        #region Implementing IExtensionWindow

        public void PreDisplay()
        {
            INautilusDBConnection dbConnection;
            dal = new DalTrackingCls();

            if (!DEBUG)
            {
                dbConnection = _sp.QueryServiceProvider("DBConnection") as NautilusDBConnection;
                rs = _sp.QueryServiceProvider("RecordSet") as NautilusRecordSet;
                _connection = dal.GetConnection(dbConnection, _ntlsUser, _ntlsSite, _connectionString, sessionId, cmd, _connection);
            }
            else
            {
                _processXml = null;
                _connection = new OracleConnection("Data Source=samba;user id=lims_sys;password=lims_sys;");
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                dal._connection = _connection;
                _fromLab = "98";
                _ToLab = "991";
                statusLabTrack = _ToLab;


            }

            _fromLabName = dal.GetLabLocation(_fromLab);
            _ToLabName = dal.GetLabLocation(_ToLab);

            label1.Text = "קבלת ארגז ב" + _ToLabName;
            txtBoxName.Focus();
        }
        public void SetParameters(string parameters)
        {
            try
            {
                int index = 0;
                var splitedParameters = parameters.Split(';');
                _fromLab = splitedParameters[index++];
                _ToLab = splitedParameters[index++];
                statusLabTrack = splitedParameters[index++];
            }
            catch (Exception e)
            {
                MessageBox.Show("לא הוגדרו פרמטרים כראוי,לא ניתן להשתמש בתוכנית");
            }
        }
        public bool CloseQuery()
        {
            try
            {
                if (cmd != null) cmd.Dispose();
                if (_connection != null) _connection.Close();

                return true;
            }
            catch (Exception ex)
            {

                return true;
            }
        }
        public void Internationalise()
        {
        }
        public void SetSite(object site)
        {
            _ntlsSite = (IExtensionWindowSite2)site;
            _ntlsSite.SetWindowInternalName("Receive Tracking");
            _ntlsSite.SetWindowRegistryName("Receive Tracking");
            _ntlsSite.SetWindowTitle("Receive Tracking");
        }
        public WindowButtonsType GetButtons()
        {
            return LSExtensionWindowLib.WindowButtonsType.windowButtonsNone;
        }
        public bool SaveData()
        {
            return false;
        }
        public void SaveSettings(int hKey)
        {
        }
        public void Setup()
        {
        }
        public void refresh()
        {

        }
        public WindowRefreshType DataChange()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }
        public WindowRefreshType ViewRefresh()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }
        public void SetServiceProvider(object serviceProvider)
        {
            _sp = serviceProvider as NautilusServiceProvider;

            if (_sp != null)
            {
                _processXml = _sp.QueryServiceProvider("ProcessXML") as NautilusProcessXML;
                _ntlsUser = _sp.QueryServiceProvider("User") as NautilusUser;

            }
            else
            {
                _processXml = null;
            }


        }
        public void RestoreSettings(int hKey)
        {

        }
        #endregion
        private void ReceiveTrackingCls_Resize(object sender, EventArgs e)
        {


            panel1.Location = new Point(Width / 2 - panel1.Width / 2, panel1.Location.Y);
            label1.Location = new Point(panel1.Width / 2 - label1.Width / 2, label1.Location.Y);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_ntlsSite != null)
            {
                _ntlsSite.CloseWindow();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void txtEntName_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void cbx_cyt_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (!cb.Checked) return;


            if (cb.Name == "cbx_pap")
            {
                cbx_cyt.Checked = !cbx_pap.Checked;
            }
            else if (cb.Name == "cbx_cyt")
            {

                cbx_pap.Checked = !cbx_cyt.Checked;
            }
        }


    }
}
