using FlowMeterData.Library.Models;
using System;
using System.Collections.Generic;

namespace FlowMeterData.Library.DataAccess
{
    public interface IFlowMeterReadings
    {
        void SaveFlowMeterReading(FlowMeterReadingModel reading);
        List<FlowMeterReadingModel> GetFlowMeterReadingsByFlowMeterId(int id);
        List<FlowMeterReadingModel> GetFlowMeterReadingsRangeByFlowMeterId(int id, DateTime startTime, DateTime endTime);
        void DeleteFlowMeterReadingsById(int id);
        void DeleteFlowMeterReadingsRangeById(int id, DateTime startTime, DateTime endTime);
    }
}