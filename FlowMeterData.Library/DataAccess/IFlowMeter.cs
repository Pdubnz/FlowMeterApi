using FlowMeterData.Library.Models;
using System.Collections.Generic;

namespace FlowMeterData.Library.DataAccess
{
    public interface IFlowMeter
    {
        void AddFlowMeter(FlowMeterModel flowMeter);
        List<FlowMeterModel> GetAllFlowMeters();
        FlowMeterModel GetFlowMeterById(int meterId);
        void DeleteAllByFlowMeterId(int flowMeterId);
        void DeleteByFlowMeterId(int flowMeterId);
    }
}