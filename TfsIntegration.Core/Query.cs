using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace TfsIntegration.Core
{
    class Query : IAzureService
    {

        private Uri _uri;
        private string _token;
        VssConnection connection;
        WorkItemTrackingHttpClient witClient;


        public Query(Uri uri, string token)
        {
            _uri = uri;
            _token = token;
            connection = new VssConnection(_uri, new VssBasicCredential(string.Empty, _token));
            witClient = connection.GetClient<WorkItemTrackingHttpClient>();
        }
        public object GetAttachments(int idWorkItems)
        {
            throw new NotImplementedException();
        }

        public object GetField(int workItemId, string field)
        {
           
        }



        public  Dictionary<string, object> GetFields(int workItemId)
        {
           
        }

        public IEnumerable<int> GetWorkItemsIds(string wiql)
        {
            var credentials = new VssBasicCredential(string.Empty, this._token);

            var wi = new Wiql()
            {
                // NOTE: Even if other columns are specified, only the ID & URL are available in the WorkItemReference
                Query = wiql
            };

            using (var httpClient = new WorkItemTrackingHttpClient(_uri, credentials))
            {
                // execute the query to get the list of work items in the results
                var result =   httpClient.QueryByWiqlAsync(wi).Result;
                var ids = result.WorkItems.Select(item => item.Id).ToArray();

                return ids;
            }
        }
    }
}
