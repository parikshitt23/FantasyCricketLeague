using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;


namespace FantasyCricketLeague
{

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void TeamDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection con = new OracleConnection(oracleConnectionString);


            string averageQuery = " intersect SELECT MATCH_NO ,DATE_MATCH ,SEASON ,TEAM_HOME ,TEAM_AWAY ,TOSS_WINNER ,TOSS_DECISION ,INN_NO ,BALL_NO ,FIRST_INN_TEAM ,B3.STRIKE_BAT ,NON_STRIKE_BAT ,BOWLER ,RUNS_SCORED ,EXTRA ,DISMISSAL ,OUT_BAT ,M_O_M ,WINNER ,WIN_MARGIN FROM (SELECT B.STRIKE_BAT, ROUND(RUNS / OUTS, 1) AS AVERAGE FROM(SELECT STRIKE_BAT, COUNT(DISMISSAL)AS OUTS FROM IPL_MASTER_DATA WHERE DISMISSAL != '*' GROUP BY STRIKE_BAT) B1,(SELECT STRIKE_BAT, SUM(RUNS_SCORED)AS RUNS FROM IPL_MASTER_DATA  group by STRIKE_BAT) B WHERE B1.STRIKE_BAT = B.STRIKE_BAT) B2, IPL_MASTER_DATA B3 WHERE B2.STRIKE_BAT = B3.STRIKE_BAT " + averageQueryBuilder(AverageDropDownList.Text);
            string teamQuery = "SELECT * FROM IPL_MASTER_DATA WHERE TEAM_AWAY = \'" + TeamDropDownList.Text +"\'";
            string strikeRateQuery = " intersect SELECT MATCH_NO ,DATE_MATCH ,SEASON ,TEAM_HOME ,TEAM_AWAY ,TOSS_WINNER ,TOSS_DECISION ,INN_NO ,BALL_NO ,FIRST_INN_TEAM ,B3.STRIKE_BAT ,NON_STRIKE_BAT ,BOWLER ,RUNS_SCORED ,EXTRA ,DISMISSAL ,OUT_BAT ,M_O_M ,WINNER ,WIN_MARGIN  FROM (SELECT B.STRIKE_BAT, CAST(RUNS/OUTS*100 AS INTEGER) AS SR FROM (SELECT STRIKE_BAT, COUNT(DISMISSAL)AS OUTS FROM IPL_MASTER_DATA WHERE DISMISSAL = '*' GROUP BY STRIKE_BAT) B1,(SELECT STRIKE_BAT, SUM(RUNS_SCORED)AS RUNS FROM IPL_MASTER_DATA  group by STRIKE_BAT) B WHERE B1.STRIKE_BAT = B.STRIKE_BAT) B2, IPL_MASTER_DATA B3 WHERE B2.STRIKE_BAT = B3.STRIKE_BAT "+ strikeRateQueryBuilder(StrikerRateDropDownList.Text);
            string halfCenturyQuery = "";
            string CenturyQuery = "";
            
            string oracleQuery =  teamQuery + averageQuery+ strikeRateQuery;

            if (!string.IsNullOrWhiteSpace(TextBox1.Text)) {
                oracleQuery = oracleQuery+" intersect SELECT * FROM IPL_MASTER_DATA WHERE STRIKE_BAT LIKE \'%" +TextBox1.Text+"%\'";
            }
            try
            {
                OracleCommand cmd = new OracleCommand(oracleQuery, con);
                con.Open();
                OracleDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
            catch(OracleException ex)
            {
                Response.Write("<br>/"+ "<br>/"+ "<br>/"+ "<br>/"+ "<br>/"+ex);
            }
            finally
            {
                con.Close();
            }
        }

        private string averageQueryBuilder(string dropDownText) {
            string[] str = dropDownText.Split(' ');
            string averageQuery;
            if (str.Length > 1)
            {
                 averageQuery = "AND AVERAGE " + str[0] + " AND AVERAGE " + str[1];
            }
            else {
                averageQuery = "AND AVERAGE " + str[0];
            }
            return averageQuery;
        }

        private string strikeRateQueryBuilder(string dropDownText) {
            string[] str = dropDownText.Split(' ');
            string strikeRateQueryBuilder;
            if (str.Length > 1)
            {
                strikeRateQueryBuilder = "AND SR " + str[0] + " AND SR " + str[1];
            }
            else {
                strikeRateQueryBuilder = "AND SR " + str[0];
            }
            return strikeRateQueryBuilder;
        }

        protected void RunsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}