using FlowMeterData.Library.DataAccess;
using FlowMeterData.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlowMeterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FlowMeterController : ControllerBase
    {
        private readonly IFlowMeter _flowMeterData;
        public FlowMeterController(IFlowMeter flowMeterData)
        {
            _flowMeterData = flowMeterData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newFlowMeter"></param>
        [Route("Add")]
        [HttpPost]
        public void AddFlowMeter(FlowMeterModel newFlowMeter)
        {
            _flowMeterData.AddFlowMeter(newFlowMeter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("All")]
        [HttpGet]
        public List<FlowMeterModel> GetAllFlowMeter()
        {
            return _flowMeterData.GetAllFlowMeters();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        /// <returns></returns>
        [Route("Id")]
        [HttpGet]
        public FlowMeterModel GetFlowMeterById(int flowMeterId)
        {
            return _flowMeterData.GetFlowMeterById(flowMeterId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        [Route("DeleteFlowMeterReadings")]
        [HttpDelete]
        public void DeleteByFlowMeterId(int flowMeterId)
        {
            _flowMeterData.DeleteByFlowMeterId(flowMeterId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowMeterId"></param>
        [Route("DeleteAllFlowMeterReadings")]
        [HttpDelete]
        public void DeleteAllByFlowMeterId(int flowMeterId)
        {
            _flowMeterData.DeleteAllByFlowMeterId(flowMeterId);
        }
    }
}
