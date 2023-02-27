using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agents2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            DataTable dtYears = new DataTable("DB");
            DataColumn nameColumn = new DataColumn("Name", typeof(string));
            DataColumn databaseColumn = new DataColumn("Database", typeof(string));
            
            dtYears.Columns.Add(nameColumn);
            dtYears.Columns.Add(databaseColumn);


            DataRow r = dtYears.NewRow();
            r["Name"] = "2021";
            r["Database"] = "ODBCloi2021";

            dtYears.Rows.Add(r);

            DataRow r2 = dtYears.NewRow();
            r2["Name"] = "2022";
            r2["Database"] = "ODBCloi2022";

            dtYears.Rows.Add(r2);
            
            DataSet myDataSet = new DataSet();
            
            myDataSet.Tables.Add(dtYears);

            yearComboBox.DataSource = myDataSet.Tables["DB"].DefaultView;

            yearComboBox.ValueMember = myDataSet.Tables["DB"].Columns[1].ToString();
            yearComboBox.DisplayMember = myDataSet.Tables["DB"].Columns[0].ToString();
            

        }


        private void goBtn_Click(object sender, EventArgs e)
        {
            string fromDate = fromDatePicker.Text;
            string toDate = toDatePicker.Text;
            string blid = branchesList.SelectedValue.ToString();

            if (cloiRB.Checked)
            {
                SqlConnection conn = new SqlConnection("Data Source=192.99.16.179,8765;Initial Catalog=" + yearComboBox.SelectedValue.ToString() + ";Persist Security Info=True;User ID=sa;Password=Techno$o");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                if (blid == "91")
                {
                    cmd.CommandText = "select qbld.blno, qbld.branchename, qbld.barcode, qbld.bldate, " +
                    "mti.computerno, isoutput, qty, finalprice as unitprice, finalprice* qty " +
"as totalprice, mti.EndUser as cardprice, 0 as isbag,  " +
" " +
"case when isoutput = 1 then " +
"(case when(((mti.enduser - finalprice) * 100) / mti.enduser) = 0 then((finalprice * qty) * 0.30) else " +
"                        ((finalprice * qty)* 0.25) end " +
") " +
"else " +
"                        ((case when(((mti.enduser - finalprice) * 100) / mti.enduser) = 0 then((finalprice * qty) * 0.30) else " +
"                        ((finalprice * qty) * 0.25) end " +
") *-1) " +
"end as Agent " +
" " +
"    from qbld inner join mti on mti.computerno = qbld.computerno " +
"     INNER JOIN BSR ON BSR.BLID = QBLD.BLID " +
"    where BSR.BSTID = 5 " +
"    AND BSR.BLID = 91 "+
"and BLDate between '" + fromDate + "' and '" + toDate + "'"+
                    " order by bldate, blno";

                }
                else
                {



                    cmd.CommandText =

"select qbld.blno, qbld.branchename, qbld.barcode, qbld.bldate, mti.computerno, isoutput, qty * (case when qbld.isOutput = 1 then 1 else -1 end) as qty, finalprice * (case when qbld.isOutput = 1 then 1 else -1 end) as unitprice, (finalprice * qty) * (case when qbld.isOutput = 1 then 1 else -1 end) as totalprice, mti.EndUser * (case when qbld.isOutput = 1 then 1 else -1 end) " +
"as cardprice,   " +
"  (case when qbld.ComputerNo like 'cc%' then finalprice *0.25 else " +
" case when(qbld.ComputerNo like 'zebag%' OR qbld.ComputerNo like 'zbag%') then finalprice *0.20 else " +
" case when(qbld.computerno like 'cwbag%' OR qbld.computerno like 'cg%' OR qbld.computerno like 'cb%') then " +
"   (case when(((mti.enduser - finalprice) * 100) / mti.enduser) <= 0 then finalprice * 0.25 else finalprice * 0.20 end)  else " +
" case when(qbld.computerno like 'cm%') then " +
"   (case when(((mti.enduser - finalprice) * 100) / mti.enduser) <= 0 then finalprice * 0.30 else finalprice * 0.20 end)  else " +
"                        (case when(((mti.enduser - finalprice) * 100) / mti.enduser) " +
"                         " +
"    between -100 and 5.59 then finalprice  *0.35 else " +
"                        (case when(((mti.enduser - finalprice) * 100) / mti.enduser) " +
"                         " +
"    between 5.6 and 39.59 then finalprice *0.25 else " +
"                        (case when(((mti.enduser - finalprice) * 100) / mti.enduser) " +
"                         " +
"    between 39.6 and 50.59 then finalprice *0.20 else " +
"                        (case when(((mti.enduser - finalprice) * 100) / mti.enduser) " +
"                         " +
"    between 50.6 and 100 then finalprice *0.15 else 0 end)          " +
"                         " +
"    end) end) end) end end end end) *(case when qbld.isOutput = 1 then 1 else -1 end) AS Agent, " +
"(case when qbld.ItemName like '%bag%' then 1 else 0 end) as isbag " +
"                         "+

        "from qbld inner join mti on mti.computerno = qbld.computerno " +
        "where blid = " + blid + " " +
        "and BLDate between '" + fromDate + "' and '" + toDate + "'"+
        " order by bldate, blno";



                }

                Debug.WriteLine(cmd.CommandText);

                SqlDataReader rd = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView1.DataSource = dt;
                dataGridView1.ReadOnly = true;

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.Text;

                if (blid == "91")
                {
                    cmd2.CommandText =
                    "                    select total, agenttotal, total-agenttotal as cloi from " +
                    "                    (select " +
"                    sum(case when isoutput = 1 then finalprice else (finalprice * -1) end) as total, " +
"sum( " +
"case when isoutput = 1 then " +
"(case when(((mti.enduser - finalprice) * 100) / mti.enduser) = 0 then((finalprice * qty)* 0.30) else " +
"                        ((finalprice * qty) * 0.25) end " +
") " +
"else " +
"                        ((case when(((mti.enduser - finalprice) * 100) / mti.enduser) = 0 then((finalprice * qty) * 0.30) else " +
"                        ((finalprice * qty) * 0.25) end " +
") *-1) " +
"end)     as agenttotal " +
" " +
"    from qbld inner join mti on mti.computerno = qbld.computerno " +
"     INNER JOIN BSR ON BSR.BLID = QBLD.BLID " +
"    where BSR.BSTID = 5 " +
" " +
"    AND BSR.BLID = 91" +
"and BLDate between '" + fromDate + "' and '" + toDate + "') as k";
                }
                else
                {
                    cmd2.CommandText =
"select *, total - agenttotal as cloi from "+
" (select sum((finalprice * qty) * (case when qbld.isOutput = 1 then 1 else -1 end)) as total, " +
" " +
"  sum((case when qbld.ComputerNo like 'cc%' then finalprice * 0.25 else " +
" case when(qbld.ComputerNo like 'zebag%' OR qbld.ComputerNo like 'zbag%') then finalprice *0.20 else " +
" case when(qbld.computerno like 'cwbag%' OR qbld.computerno like 'cg%' OR qbld.computerno like 'cb%') then " +
"   (case when(((mti.enduser - finalprice) * 100) / mti.enduser) <= 0 then finalprice * 0.25 else finalprice * 0.20 end)  else " +
" case when(qbld.computerno like 'cm%') then " +
"   (case when(((mti.enduser - finalprice) * 100) / mti.enduser) <= 0 then finalprice * 0.30 else finalprice * 0.20 end)  else " +
" (case when(((mti.enduser - finalprice) * 100) / mti.enduser) " +
"                         " +
"    between -100 and 5.59 then finalprice  *0.35 else " +
"                        (case when(((mti.enduser - finalprice) * 100) / mti.enduser) " +
"                         " +
"    between 5.6 and 39.59 then finalprice *0.25 else " +
"                        (case when(((mti.enduser - finalprice) * 100) / mti.enduser) " +
"                         " +
"    between 39.6 and 50.59 then finalprice *0.20 else " +
"                        (case when(((mti.enduser - finalprice) * 100) / mti.enduser) " +
"                         " +
"    between 50.6 and 100 then finalprice *0.15 else 0 end)          " +
"    end) end) end) end end end end) * (case when qbld.isOutput = 1 then 1 else -1 end)) as agenttotal " +
        "from qbld inner join mti on mti.computerno = qbld.computerno " +
        "where blid = " + blid + " " +
        "and BLDate between '" + fromDate + " 00:00:00.000' and '" + toDate + " 23:59:59.999' ) as k";
                }
                SqlDataReader rd2 = cmd2.ExecuteReader();

                DataTable dt2 = new DataTable();
                dt2.Load(rd2);
                dataGridView2.DataSource = dt2;
                dataGridView2.ReadOnly = true;


                conn.Close();
            }
            else
            {
                if (cloiTeenRB.Checked)
                {
                    SqlConnection conn = new SqlConnection("Data Source=192.99.16.179,8765;Initial Catalog=" + yearComboBox.SelectedValue.ToString() + ";Persist Security Info=True;User ID=sa;Password=Techno$o");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =


"select qbld.blno, qbld.branchename, qbld.barcode, qbld.bldate, "+
"mti.computerno, isoutput, qty, (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) as unitprice, (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty " +
"as totalprice, mti.EndUser as cardprice, 0 as isbag,  " +
" " +
"case when isoutput = 1 then " +
"(case when(((mti.enduser - (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)) * 100) / mti.enduser) = 0 then(((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.55) else " +
"case when(((mti.enduser - (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)) * 100) / mti.enduser) between 1 and 39.49 then(((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.65) else " +
"                        (((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.75) end " +
"                        end " +
") " +
"else " +
                        "((case when(((mti.enduser - (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)) * 100) / mti.enduser) = 0 then(((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.55) else " +
                        "case when(((mti.enduser - (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)) * 100) / mti.enduser) between 1 and 39.49 then(((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.65) else " +
"                        (((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.75) end " +
"                        end " +
") *-1) " +
"end as Agent " +
" " +
"    from qbld inner join mti on mti.computerno = qbld.computerno " +
"     INNER JOIN BSR ON BSR.BLID = QBLD.BLID " +
"    where BSR.BSTID = 5 " +
"    and mti.computerno like 'CT%' " +
"and BLDate between '" + fromDate + "' and '" + toDate + "'";

                    
                    SqlDataReader rd = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    dataGridView1.DataSource = dt;
                    dataGridView1.ReadOnly = true;

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText =

"select total, agenttotal, total - agentTotal as cloi from(select " +
"sum( " +
"case when isoutput = 1 then ((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) else ((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)  * qty) * -1 end) as total, " +
"sum( " +
"case when isoutput = 1 then " +
"(case when(((mti.enduser - (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)) * 100) / mti.enduser) = 0 then(((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.55) else " +
"case when(((mti.enduser - (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)) * 100) / mti.enduser) between 1 and 39.49 then(((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.65) else " +
"                        (((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.75) end " +
"                        end " +
") " +
"else " +
"                        ((case when(((mti.enduser - (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)) * 100) / mti.enduser) = 0 then(((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.55) else " +
"case when(((mti.enduser - (case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end)) * 100) / mti.enduser) between 1 and 39.49 then(((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.65) else " +
"                        (((case when qbld.blid = 51 then case when mti.sale > 0 then mti.sale else mti.enduser end else finalprice end) * qty) * 0.75) end " +
"                        end " +
") *-1) " +
"end)     as agenttotal " +
" " +
"    from qbld inner join mti on mti.computerno = qbld.computerno " +
"     INNER JOIN BSR ON BSR.BLID = QBLD.BLID " +
"    where BSR.BSTID = 5 " +
"    and mti.computerno like 'CT%' and BLDate between '" + fromDate + "' and '" + toDate + "') as x ";

                    SqlDataReader rd2 = cmd2.ExecuteReader();

                    DataTable dt2 = new DataTable();
                    dt2.Load(rd2);
                    dataGridView2.DataSource = dt2;
                    dataGridView2.ReadOnly = true;


                    conn.Close();
                }
                else
                {
                    if (ZirconRB.Checked)
                    {
                        SqlConnection conn = new SqlConnection("Data Source=192.99.16.179,8765;Initial Catalog="+ yearComboBox.SelectedValue.ToString() + ";Persist Security Info=True;User ID=sa;Password=Techno$o");
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText =


"select qbld.blno, qbld.branchename, qbld.barcode, qbld.bldate, " +
"mti.computerno, isoutput, qty, finalprice as unitprice, finalprice * qty " +
"as totalprice, mti.EndUser as cardprice, 0 as isbag,  " +
" " +
"case when isoutput = 1 then " +
    "(" +
    "                        (((finalprice) * 0.75) * qty)" +
    ") " +
    "else " +
    "                        (" +
    "                        (((finalprice) * 0.75)  * qty) " +
    " *-1) " +
"end as Agent " +
" " +
"    from qbld inner join mti on mti.computerno = qbld.computerno " +
"     INNER JOIN BSR ON BSR.BLID = QBLD.BLID " +
"    where BSR.BSTID = 5 " +
"    and (mti.computerno like 'ZEBAG%' OR mti.computerno like 'ZBAG%') " +
"and BLDate between '" + fromDate + "' and '" + toDate + "'";

                        SqlDataReader rd = cmd.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(rd);
                        dataGridView1.DataSource = dt;
                        dataGridView1.ReadOnly = true;

                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = conn;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText =

    "select total, agenttotal, total - agentTotal as cloi from(select " +
    "sum( " +
    "case when isoutput = 1 then (finalprice*qty) else (finalPrice*qty) * -1 end) as total, " +
    "sum( " +
    "case when isoutput = 1 then " +
    "(" +
    "                        ((finalprice * 0.75) * qty) " +
    ") " +
    "else " +
    "                        (" +
    "                        ((finalprice * 0.75) * qty) " +
    " *-1) " +
    "end)     as agenttotal " +
    " " +
    "    from qbld inner join mti on mti.computerno = qbld.computerno " +
    "     INNER JOIN BSR ON BSR.BLID = QBLD.BLID " +
    "    where BSR.BSTID = 5 " +
    "    and (mti.computerno like 'ZEBAG%' OR mti.computerno like 'ZBAG%') and BLDate between '" + fromDate + "' and '" + toDate + "') as x ";

                        SqlDataReader rd2 = cmd2.ExecuteReader();

                        DataTable dt2 = new DataTable();
                        dt2.Load(rd2);
                        dataGridView2.DataSource = dt2;
                        dataGridView2.ReadOnly = true;


                        conn.Close();
                    }
                    else
                    if (salariesRB.Checked)
                    {
                        SqlConnection conn = new SqlConnection("Data Source=192.99.16.179,8765;Initial Catalog=" + yearComboBox.SelectedValue.ToString() + ";Persist Security Info=True;User ID=sa;Password=Techno$o");
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText =
"select qbld.branchename, " +
"sum(case when(mti.enduser - qbld.finalprice) > 0 then case when isoutput = 1 then finalprice else finalprice * -1 end end *qty) as ondiscount, " +
"sum(case when(mti.enduser - qbld.finalprice) = 0 then case when isoutput = 1 then finalprice else finalprice * -1 end end *qty) as newcollection " +
"from qbld " +
"inner join mti on mti.computerno = qbld.computerno " +
"inner " +
"join bsr on bsr.blid = qbld.blid " +
"where bsr.bstid = 5 " +
"and qbld.bldate between '" + fromDate + "' and '" + toDate + "' " +
"group by qbld.branchename";

                        SqlDataReader rd = cmd.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(rd);
                        dataGridView1.DataSource = dt;
                        dataGridView1.ReadOnly = true;

                        conn.Close();
                    }
                }
            }
        }
   

        private void cloiRB_CheckedChanged(object sender, EventArgs e)
        {
            if (cloiRB.Checked)
                branchesList.Enabled = true;
            else
                branchesList.Enabled = false;
        }

        private void ZirconRB_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void yearComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string db = (yearComboBox.SelectedItem as DataRowView).Row["Database"] as string;
            SqlConnection conn = new SqlConnection("Data Source=192.99.16.179,8765;Initial Catalog=" + db + ";Persist Security Info=True;User ID=sa;Password=Techno$o;Encrypt=false;TrustServerCertificate=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =

                "SELECT * FROM QBSR WHERE BSTID = 5";

            SqlDataReader rd = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rd);
            branchesList.DataSource = dt;
            branchesList.DisplayMember = "ArName";
            branchesList.ValueMember = "BLID";

            conn.Close();
        }
    }
}
