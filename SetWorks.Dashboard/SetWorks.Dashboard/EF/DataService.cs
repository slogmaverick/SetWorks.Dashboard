using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace SetWorks.Dashboard.EF
{
    public interface ICovidDataService
    {
        //Gotta be a better way to get the BaseAddress.  
        //Can't use NavManager as a dependency on class instantiation, it doesn't exist yet.  
        public Task<List<RonaStateSummary>> GetAllData();
    }
    class Helper
    {
        public async Task<List<RonaStateSummary>> GetAllData(HttpRequestMessage request, HttpClient client)
        {
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync
                    <IEnumerable<RonaStateSummary>>(responseStream);
                return (List<RonaStateSummary>)data;
            }
            else
            {
                return new List<RonaStateSummary>();
            }
        }
    }
    public class CovidDataService_File : ICovidDataService
    {
        private string baseAddress;
        public CovidDataService_File(NavigationManager navManager)
        {
            this.baseAddress = navManager.BaseUri;
        }
        public async Task<List<RonaStateSummary>> GetAllData()
        {
            var url = "test-data/allstates.json";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();
            client.BaseAddress = new Uri(this.baseAddress);

            var h = new Helper();
            return await h.GetAllData(request, client);
        }
    }
    public class CovidDataService_Feds : ICovidDataService
    {
        public async Task<List<RonaStateSummary>> GetAllData()
        {
            var url = "https://api.covidtracking.com/v1/states/current.json";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();

            var h = new Helper();
            return await h.GetAllData(request, client);
        }
    }
}
