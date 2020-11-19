using FlowMeterData.Library.DataAccess;
using FlowMeterData.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FlowMeterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FlowMeterReadingsController : ControllerBase
    {
        private readonly IFlowMeterReadings _flowMeterReadingsData;
        public FlowMeterReadingsController(IFlowMeterReadings flowMeterReadingsData)
        {
            _flowMeterReadingsData = flowMeterReadingsData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newFlowMeterReading"></param>
        [Route("Add")]
        [HttpPost]
        public void SaveFlowMeterReading(FlowMeterReadingModel newFlowMeterReading)
        {
            _flowMeterReadingsData.SaveFlowMeterReading(newFlowMeterReading);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        /// <returns></returns>
        [Route("FlowMeterId")]
        [HttpGet]
        public List<FlowMeterReadingModel> GetFlowMeterReadingsByFlowMeterId(int flowMeterId)
        {
            return _flowMeterReadingsData.GetFlowMeterReadingsByFlowMeterId(flowMeterId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [Route("Range/FlowMeterId")]
        [HttpGet]
        public List<FlowMeterReadingModel> GetFlowMeterReadingsRangeByFlowMeterId(int flowMeterId, DateTime startTime, DateTime endTime)
        {
            return _flowMeterReadingsData.GetFlowMeterReadingsRangeByFlowMeterId(flowMeterId, startTime, endTime);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        [Route("DeleteFlowMeterReadings")]
        [HttpDelete]
        public void DeleteFlowMeterReadingsById(int flowMeterId)
        {
            _flowMeterReadingsData.DeleteFlowMeterReadingsById(flowMeterId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        [Route("DeleteRangeFlowMeterReadings")]
        [HttpDelete]
        public void DeleteRangeByFlowMeterId(int flowMeterId, DateTime startTime, DateTime endTime)
        {
            _flowMeterReadingsData.DeleteFlowMeterReadingsRangeById(flowMeterId, startTime, endTime);
        }
    }
}
