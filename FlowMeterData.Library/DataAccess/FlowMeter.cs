using FlowMeterData.Library.Internal.DataAccess;
using FlowMeterData.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowMeterData.Library.DataAccess
{
    public class FlowMeter : IFlowMeter
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataAccess"></param>
        public FlowMeter(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeter"></param>
        public void AddFlowMeter(FlowMeterModel flowMeter)
        {
            _sqlDataAccess.SaveData("dbo.spFlowMeter_Upsert", flowMeter, "FlowMeterDB");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FlowMeterModel> GetAllFlowMeters()
        {
            return _sqlDataAccess.LoadData<FlowMeterModel, dynamic>("dbo.spFlowMeter_GetAll", new { }, "FlowMeterDB");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        /// <returns></returns>
        public FlowMeterModel GetFlowMeterById(int flowMeterId)
        {
            return _sqlDataAccess.LoadData<FlowMeterModel, dynamic>("dbo.spFlowMeter_GetById", new { flowMeterId }, "FlowMeterDB").FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        public void DeleteByFlowMeterId(int flowMeterId)
        {
            _sqlDataAccess.SaveData("dbo.spFlowMeter_DeleteById", new { flowMeterId }, "FlowMeterDB");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        public void DeleteAllByFlowMeterId(int flowMeterId)
        {
            _sqlDataAccess.SaveData("dbo.spFlowMeter_DeleteByIdIncludeReadings", new { flowMeterId }, "FlowMeterDB");
        }

    }
}