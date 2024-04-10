using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace ReceiveTracking
{
    public class Dal
    {

        private OracleConnection _connection;

        private OracleCommand cmd;

        private string sql;

        public Dal(OracleCommand cmd, OracleConnection _connection)
        {
            this.cmd = cmd;
            this._connection = _connection;
        }

        public string getLab_Name(string labName)
        {
            sql = string.Format("select lims.phrase_lookup (  'Lab Location' , '{0}' ) lab_name from dual", labName);
            cmd = new OracleCommand(sql, _connection);
            OracleDataReader reader = cmd.ExecuteReader();

            //Checks if it exists
            if (!reader.HasRows)
            {
                MessageBox.Show("The Lab " +
                     labName +
                    "  does not exist or does not meet the conditions!", "Nautilus",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //txtEditEntity.Focus();
                return null;
            }
            else
            {
                while (reader.Read())
                {
                    return reader["LAB_NAME"].ToString();
                }
                return null;
            }
        }

        public string getBox(string from_lab, string to_lab, string boxName, double user)
        {
            //where bu.u_status = 'B'
            sql = string.Format("select b.u_box_id,bu.U_STATUS from LIMS_SYS.u_box b " +
                "inner join LIMS_SYS.u_box_user bu on b.u_box_id = bu.u_box_id " +
                "where bu.u_from_lab = '{0}' and bu.u_to_lab = '{1}' and b.name = '{2}'", from_lab, to_lab, boxName);

            cmd = new OracleCommand(sql, _connection);
            OracleDataReader reader = cmd.ExecuteReader();

            //Checks if it exists
            if (!reader.HasRows)
            {
                MessageBox.Show("ארגז לא נמצא", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                while (reader.Read())
                {
                    string status = reader["U_STATUS"].ToString();
                    if (status != "C" && status != "D")
                    {
                        MessageBox.Show("ארגז לא בסטטוס המתאים", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        string boxId = reader["u_box_id"].ToString();

                        //update box
                        sql = string.Format("update LIMS_SYS.U_BOX_USER set U_STATUS = '{0}', U_ARRIVED_ON = {1},U_ARRIVED_BY = {2} where U_BOX_ID = '{3}'", "D", "SYSDATE", user != 0 ? user.ToString() : null, boxId);
                        cmd = new OracleCommand(sql, _connection);
                        cmd.ExecuteNonQuery();
                        return boxId;
                    }
                }
                return null;
            }
        }


        public bool updateEntityStatus(string boxId, string statusLabTrack, string name)
        {
            OracleTransaction transaction = null;

            try
            {
                string id = null;
                string entity = null;

                //get all entities
                //U_BOX =  '{0}' and 
                sql = string.Format("select U_TRACK_ITEM_ID,U_TRACK_TABLE_NAME,U_BOX from LIMS_SYS.U_LAB_TRACK_USER where U_TRACK_ITEM_NAME = '{1}'", boxId, name);

                cmd = new OracleCommand(sql, _connection);
                OracleDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("יישות לא נמצאה במעבדה", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    while (reader.Read())
                    {
                        if (reader["U_BOX"].ToString() == boxId)
                        {
                            id = reader["U_TRACK_ITEM_ID"].ToString();
                            entity = reader["U_TRACK_TABLE_NAME"].ToString();
                        }

                    }
                    if (id == null && entity == null)
                    {
                        MessageBox.Show("יישות לא מתאימה לארגז", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                transaction = _connection.BeginTransaction();
                cmd.Connection = _connection;
                cmd.Transaction = transaction;

                //update entity
                sql = string.Format("update " + "LIMS_SYS." + entity + "_USER set U_LAB_LOCATION = '{0}' where " + entity + "_ID = '{1}'", statusLabTrack, id);
                cmd = new OracleCommand(sql, _connection);
                cmd.ExecuteNonQuery();

                //update labTracking
                sql = string.Format("update LIMS_SYS.U_LAB_TRACK_USER set U_STATUS = '{0}', U_ARRIVED_ON = {1} where U_BOX = '{2}' and U_TRACK_ITEM_ID = '{3}'", statusLabTrack, "SYSDATE", boxId, id);
                cmd = new OracleCommand(sql, _connection);
                cmd.ExecuteNonQuery();
                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception en)
                {
                    MessageBox.Show(en.Message); ;
                }
                return false;
            }

        }
    }
}
