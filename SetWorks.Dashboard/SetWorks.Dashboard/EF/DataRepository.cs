using Microsoft.AspNetCore.Components;

namespace SetWorks.Dashboard.EF
{
    public interface ICovidRepository
    {
        public Task<List<RonaStateSummary>> GetAllData();
    }
    public class CovidRepository : ICovidRepository
    {
        private ICovidDataService svc;
        public CovidRepository(ICovidDataService svc)
        {
            this.svc = svc;
            //If this code is used, the app will hang with no exceptions thrown.  
            //  Leaving it here to troubleshoot late.  

            //using (var context = new ApiContext())
            //{
            //    var data = svc.GetAllData().Result;
            //    context.CovidData.AddRange(data);
            //    context.SaveChanges();
            //}
        }
        public async Task<List<RonaStateSummary>> GetAllData()
        {
            using(var context = new ApiContext())
            {
                if (context.CovidData.Count() == 0)
                {
                    var data = await svc.GetAllData();
                    context.CovidData.AddRange(data);
                    context.SaveChanges();
                }
                return context.CovidData.ToList();
            }
        }
    }
}
