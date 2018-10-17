using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System.Net;
using System.Configuration;
using System.ServiceModel.Description;
using System.Data;

namespace CRMCustomCalendar
{
    public partial class CustomEntityCalendar : System.Web.UI.Page
    {
        public string fullname;
        public Guid leadGuid;
        public string leadno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                string uniqueLeadId = Request.QueryString["id"];
                //string uniqueLeadId = "L-00291";
                CalendarMethod(uniqueLeadId);

                #region Old Code
                //string fetchXML = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                //                  <entity name='appointment'>
                //                    <attribute name='subject' />
                //                    <attribute name='activityid' />
                //                    <attribute name='scheduledstart' />
                //                    <attribute name='scheduledend' />
                //                    <order attribute='subject' descending='false' />
                //                  </entity>
                //                </fetch>";

                //FetchExpression Query = new FetchExpression(fetchXML);
                //EntityCollection listEntities = GetService().RetrieveMultiple(Query);

                //DataTable dt = new DataTable();
                //dt.Columns.Add("Id", Type.GetType("System.Int32"));
                //dt.Columns.Add("EventStartDate", Type.GetType("System.DateTime"));
                //dt.Columns.Add("EventEndDate", Type.GetType("System.DateTime"));
                //dt.Columns.Add("EventHeader", Type.GetType("System.String"));
                //dt.Columns.Add("EventDescription", Type.GetType("System.String"));
                //dt.Columns.Add("EventForeColor", Type.GetType("System.String"));
                //dt.Columns.Add("EventBackColor", Type.GetType("System.String"));

                //int idCount = 1;

                //foreach (Entity leave in listEntities.Entities)
                //{
                //    DataRow dr;
                //    dr = dt.NewRow();
                //    dr["Id"] = idCount++;
                //    dr["EventStartDate"] = Convert.ToDateTime(leave.Attributes["scheduledstart"].ToString());
                //    dr["EventEndDate"] = Convert.ToDateTime(leave.Attributes["scheduledend"].ToString());
                //    dr["EventHeader"] = leave.Attributes["subject"].ToString();
                //    dr["EventDescription"] = leave.Attributes["subject"].ToString();
                //    dr["EventForeColor"] = "Navy";
                //    dt.Rows.Add(dr);
                //}

                //CCGlobalCalendar.EventStartDateColumnName = "EventStartDate";
                //CCGlobalCalendar.EventEndDateColumnName = "EventEndDate";
                //CCGlobalCalendar.EventDescriptionColumnName = "EventDescription";
                //CCGlobalCalendar.EventHeaderColumnName = "EventHeader";
                //CCGlobalCalendar.EventBackColorName = "EventBackColor";
                //CCGlobalCalendar.EventForeColorName = "EventForeColor";
                //CCGlobalCalendar.EventSource = dt;
                #endregion

            }
        }

        private void CalendarMethod(string uniqueLeadId)
        {
            QueryExpression qe = new QueryExpression();
            qe.EntityName = "lead";
            qe.ColumnSet = new ColumnSet { AllColumns = true };
            FilterExpression fe = new FilterExpression();
            fe.AddCondition(new ConditionExpression("gt_uniqueleadid", ConditionOperator.Equal, uniqueLeadId));
            qe.Criteria = fe;
            EntityCollection ec = GetService().RetrieveMultiple(qe);
            if (ec.Entities.Count > 0)
            {
                foreach (Entity c in ec.Entities)
                {
                    leadGuid = new Guid(c["leadid"].ToString());
                    string subject = c["subject"].ToString();
                    Guid createdBy = ((EntityReference)c["createdby"]).Id;
                    HiddenField2.Value = c["fullname"].ToString();
                    HiddenField1.Value = c["gt_uniqueleadid"].ToString();

                    QueryExpression q2 = new QueryExpression();
                    q2.EntityName = "appointment";
                    q2.ColumnSet = new ColumnSet { AllColumns = true };
                    FilterExpression f2 = new FilterExpression(LogicalOperator.And);
                    f2.AddCondition(new ConditionExpression("ownerid", ConditionOperator.Equal, createdBy));
                    f2.AddCondition(new ConditionExpression("scheduledstart", ConditionOperator.OnOrAfter, DateTime.Now));
                    q2.Criteria = f2;
                    EntityCollection e2 = GetService().RetrieveMultiple(q2);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Id", Type.GetType("System.Int32"));
                    dt.Columns.Add("EventStartDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EventEndDate", Type.GetType("System.DateTime"));
                    dt.Columns.Add("EventHeader", Type.GetType("System.String"));
                    dt.Columns.Add("EventDescription", Type.GetType("System.String"));
                    dt.Columns.Add("EventForeColor", Type.GetType("System.String"));
                    dt.Columns.Add("EventBackColor", Type.GetType("System.String"));




                    if (e2.Entities.Count > 0)
                    {
                        int idCount = 1;
                        foreach (Entity leave in e2.Entities)
                        {
                            DataRow dr;
                            dr = dt.NewRow();
                            dr["Id"] = idCount++;
                            dr["EventStartDate"] = Convert.ToDateTime(leave.Attributes["scheduledstart"].ToString());
                            dr["EventEndDate"] = Convert.ToDateTime(leave.Attributes["scheduledend"].ToString());
                            dr["EventHeader"] = leave.Attributes["subject"].ToString();
                            dr["EventDescription"] = leave.Attributes["subject"].ToString();
                            dr["EventForeColor"] = "Navy";
                            dt.Rows.Add(dr);
                        }

                        CCGlobalCalendar.EventStartDateColumnName = "EventStartDate";
                        CCGlobalCalendar.EventEndDateColumnName = "EventEndDate";
                        CCGlobalCalendar.EventDescriptionColumnName = "EventDescription";
                        CCGlobalCalendar.EventHeaderColumnName = "EventHeader";
                        CCGlobalCalendar.EventBackColorName = "EventBackColor";
                        CCGlobalCalendar.EventForeColorName = "EventForeColor";
                        CCGlobalCalendar.EventSource = dt;
                    }
                }
            }
        }

        public IOrganizationService GetService()
        {
            try
            {
                //IServiceConfiguration<IOrganizationService> orgConfig =
                //    ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(new Uri(serverURL + "/XRMServices/2011/Organization.svc"));


                //IServiceConfiguration<IOrganizationService> orgConfig =
                //    ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(new Uri("http://192.168.11.187:5555/TRAINING/XRMServices/2011/Organization.svc"));


                //var creds = new ClientCredentials();
                //creds.Windows.ClientCredential = new NetworkCredential("administrator", "Passw0rd@123", "CRM2013ad");

                //var orgService = new OrganizationServiceProxy(orgConfig, creds);
                //orgService.ServiceConfiguration.CurrentServiceEndpoint.Behaviors.Add(new ProxyTypesBehavior());

                //return orgService;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

                ClientCredentials credentials = new ClientCredentials();
                credentials.UserName.UserName = "admin@gtuaed365.onmicrosoft.com";
                credentials.UserName.Password = "gtuae$2018";
                Uri OrganizationUri = new Uri("https://gtuat.api.crm4.dynamics.com/XRMServices/2011/Organization.svc");
                Uri HomeRealUri = null;
                IOrganizationService service = null;
                using (OrganizationServiceProxy serviceProxy = new OrganizationServiceProxy(OrganizationUri, HomeRealUri, credentials, null))
                {
                    service = (IOrganizationService)serviceProxy;

                }
                return service;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public String serverURL
        //{
        //    get { return ConfigurationManager.AppSettings["OrganizationURL"]; }
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dob = DateTime.Parse(Request.Form[TextBox1.UniqueID]);
            DateTime endTime=DateTime.Parse(Request.Form[TextBox2.UniqueID]);

            Entity Appointment = new Entity("appointment");
            Appointment["subject"] = "Appointment with " + HiddenField2.Value;
            Appointment["scheduledstart"] = dob;
            Appointment["scheduledend"] = endTime;
            Guid AppointmentId = GetService().Create(Appointment);

            CalendarMethod(HiddenField1.Value);
        }
    }
}