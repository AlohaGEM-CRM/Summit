using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using SummitShopApp.BL;
using System.Configuration;
using System.Timers;
using System.Data;
using System.Data.SqlTypes;

namespace AIManageRecurringActivity
{
    public partial class AIManageRecurring : ServiceBase
    {
        private Boolean isRunning = false;
        private Timer timer = new Timer();
        private DateTime startTime = DateTime.Today.AddHours(21);
        private DateTime endTime = DateTime.Today.AddHours(6);

        public AIManageRecurring()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            CreateReoccuringScheduledUser();

            // handle Elapsed event
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            // This statement is used to set interval to 1 minute (= 60,000 milliseconds)
            timer.Interval = 60000;

            //enabling the timer
            timer.Enabled = true;
        }

        ////////////////////////////////Schduler Start///////////////////////////////////////////
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            CreateReoccuringScheduledUser();
        }

        protected override void OnStop()
        {
        }

        // Method which calls OnStart.  Used when we run in console mode.
        public void ForceStart()
        {
            OnStart(null);
        }

        // Method which calls OnStop.  Used when we run in console mode.		
        public void ForceStop()
        {
            OnStop();
        }

        /// <summary>
        /// Method to add reoccuring and scheuduled campaign for delivered vehicle status
        /// </summary>
        /// <param name="iShopId">Shop Id</param>
        /// <param name="iUserId">User Id</param>
        /// <param name="dtDeliveryDate">Delivery Date</param>
        private void CreateReoccuringScheduledUser()
        {
            if (isRunning)
            {
                //MessageLogs.WriteLog("Service is still processing old thread.");
                return;
            }
            try
            {
                if (DateTime.Now.Hour >= startTime.Hour || DateTime.Now.Hour < endTime.Hour)
                {
                    isRunning = true;

                    List<AIManageRecurringActivityBL> lstAIManageRecurringActivityBL = AIManageRecurringActivityBL.GetUnprocessedDataForAddingRecurringInfo();
                    if (lstAIManageRecurringActivityBL != null)
                    {
                        foreach (AIManageRecurringActivityBL objAIManageRecurringActivityBL in lstAIManageRecurringActivityBL)
                        {
                            Int32 iShopId = objAIManageRecurringActivityBL.iShopId;
                            Int32 iUserId = objAIManageRecurringActivityBL.iUserId;
                            DateTime dtDeliveryDate = objAIManageRecurringActivityBL.dtDeliveryDate;

                            System.Collections.Generic.List<SummitShopApp.BL.FrequencyBL> lstFrequency = SummitShopApp.BL.FrequencyBL.getFrequencyList();
                            if (lstFrequency != null && lstFrequency.Count > 0)
                            {
                                //code to delete null entries from ReocurringCampaignUsers Table to remove duplicates
                                SummitShopApp.BL.ReocurringCampaignUsersBL.deleteRecordsForNull(iUserId, iShopId);
                                foreach (SummitShopApp.BL.FrequencyBL objFrequency in lstFrequency)
                                {
                                    try
                                    {
                                        /*
                                         * Dev 1 : 16 Aug 2016
                                         * Added code for connect api shop as we are fetching data on next day
                                         * eg: customer added data on 12th aug and we are fetchechin them at 13th.
                                         * to resolve the issue of one day delivered
                                         * */
                                        Boolean isAddRecords = false;
                                        ConnectAPIBL objConnectApi = ConnectAPIBL.getDataByShopId(iShopId);
                                        if (objConnectApi != null)
                                        {
                                            isAddRecords = objFrequency.iDays >= DateTime.Now.Subtract(dtDeliveryDate).Days;
                                        }
                                        else
                                        {
                                            isAddRecords = objFrequency.iDays > DateTime.Now.Subtract(dtDeliveryDate).Days;
                                        }

                                        //schedule only if days are  not elasped  
                                        
                                        if (isAddRecords)
                                        {
                                            SummitShopApp.BL.ReocurringCampaignUsersBL ReoccuringUser = null;
                                            ReoccuringUser = SummitShopApp.BL.ReocurringCampaignUsersBL.getDataByShopIdUserIdAndFreqId(iShopId, iUserId, objFrequency.iID);
                                            if (ReoccuringUser == null)
                                                ReoccuringUser = new SummitShopApp.BL.ReocurringCampaignUsersBL();
                                            ReoccuringUser.bIsMailSent = true;
                                            ReoccuringUser.bIsSmsSent = true;
                                            ReoccuringUser.dtDeliveredDate = dtDeliveryDate;
                                            ReoccuringUser.iUserID = iUserId;
                                            ReoccuringUser.iShopID = iShopId;
                                            ReoccuringUser.iFrequencyID = objFrequency.iID;
                                            if (ReoccuringUser.Save())
                                            {
                                                //save the schedule user
                                                SummitShopApp.BL.ScheduledUsersBL objScheduleUser = SummitShopApp.BL.ScheduledUsersBL.getDataByUserIdShopIdAndFrequencyId(ReoccuringUser.iUserID.Value, ReoccuringUser.iShopID.Value, objFrequency.iID);
                                                if (objScheduleUser == null)
                                                    objScheduleUser = new SummitShopApp.BL.ScheduledUsersBL();
                                                objScheduleUser.iUserId = ReoccuringUser.iUserID.Value;
                                                objScheduleUser.iShopId = ReoccuringUser.iShopID.Value;
                                                objScheduleUser.iFrequency = objFrequency.iID;
                                                objScheduleUser.dtSendDate = dtDeliveryDate.AddDays(objFrequency.iDays);
                                                objScheduleUser.bIsMailSent = true;
                                                objScheduleUser.bIsSmsSent = true;
                                                objScheduleUser.Save();
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex, SummitShopApp.Utility.Constants.ExceptionPolicy);
                                    }
                                }
                            }

                            //Update AIManageRecurringActivity table
                            objAIManageRecurringActivityBL.IsProcessed = true;
                            objAIManageRecurringActivityBL.dtProcessedDate = DateTime.Now;
                            objAIManageRecurringActivityBL.Save();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                isRunning = false;
            }
        }

    }

}
