using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace TfsIntegration.Core
{
    class WorkTask : IWorkTask
    {
        private WorkItem _workItem;

        public int? Id { get { return _workItem.Id; } }

        public string Url { get { return _workItem.Url; } }


        public object GetAttachments()
        {
            try
            {
                // Output the work item's field values
                var keyValuePair = _workItem.Relations[0].;
                return keyValuePair.Value;
            }
            catch (AggregateException aex)
            {
                VssServiceException vssex = aex.InnerException as VssServiceException;
                if (vssex != null)
                {
                    Console.WriteLine(vssex.Message);
                }
            }
            return null;
        }

        public WorkTask(WorkItem workItem)
        {
            _workItem = workItem;
        }


        public object GetField(string fieldName)
        {
            try
            {
                // Output the work item's field values
                var keyValuePair = _workItem.Fields.Where(x => x.Key == fieldName).First();
                return keyValuePair.Value;
            }
            catch (AggregateException aex)
            {
                VssServiceException vssex = aex.InnerException as VssServiceException;
                if (vssex != null)
                {
                    Console.WriteLine(vssex.Message);
                }
            }
            return null;
        }

        public Dictionary<string, object> GetFields()
        {
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                // Output the work item's field values
                foreach (var field in _workItem.Fields)
                {
                    keyValuePairs.Add(field.Key, field.Value);
                }
                return keyValuePairs;
            }
            catch (AggregateException aex)
            {
                VssServiceException vssex = aex.InnerException as VssServiceException;
                if (vssex != null)
                {
                    Console.WriteLine(vssex.Message);
                }
            }
            return null;
        }

      
    }
}
