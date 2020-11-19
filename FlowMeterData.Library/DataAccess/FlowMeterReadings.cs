using FlowMeterData.Library.Internal.DataAccess;
using FlowMeterData.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowMeterData.Library.DataAccess
{
    public class FlowMeterReadings : IFlowMeterReadings
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public FlowMeterReadings(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        /// <summary>
        /// Save a flow meter reading
        /// </summary>
        /// <param name="reading"></param>
        public void SaveFlowMeterReading(FlowMeterReadingModel reading)
        {
            _sqlDataAccess.SaveData("dbo.spFlowMeterReading_Upsert", reading, "FlowMeterDB");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        /// <returns></returns>
        public List<FlowMeterReadingModel> GetFlowMeterReadingsByFlowMeterId(int flowMeterId)
        {
            return _sqlDataAccess.LoadData<FlowMeterReadingModel, dynamic>("dbo.spFlowMeterReading_GetByFlowMeterId", new { flowMeterId }, "FlowMeterDB");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<FlowMeterReadingModel> GetFlowMeterReadingsRangeByFlowMeterId(int flowMeterId, DateTime startTime, DateTime endTime)
        {
            return _sqlDataAccess.LoadData<FlowMeterReadingModel, dynamic>("dbo.spFlowMeterReading_GetRangeByFlowMeterId", new { flowMeterId, startTime, endTime }, "FlowMeterDB");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        public void DeleteFlowMeterReadingsById(int flowMeterId)
        {
            _sqlDataAccess.SaveData("dbo.spFlowMeterReading_DeleteAllByFlowMeterId", new { flowMeterId }, "FlowMeterDB");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public void DeleteFlowMeterReadingsRangeById(int flowMeterId, DateTime startTime, DateTime endTime)
        {
            _sqlDataAccess.SaveData("dbo.spFlowMeterReading_DeleteRangeByFlowMeterId", new { flowMeterId, startTime, endTime }, "FlowMeterDB");
        }
        
    }
}
